using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Elector.Forms
{
    public partial class CreatePollForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private List<TextBox> optionTextBoxes;

        public CreatePollForm()
        {
            InitializeComponent();
            optionTextBoxes = new List<TextBox>();

            // Bật auto scroll cho panel options
            panelOptions.AutoScroll = true;

            AddInitialOptions();
        }

        private void AddInitialOptions()
        {
            // Thêm 2 option mặc định
            AddOptionTextBox();
            AddOptionTextBox();
        }

        private void AddOptionTextBox()
        {
            TextBox optionTextBox = new TextBox
            {
                Width = panelOptions.Width - 100 - SystemInformation.VerticalScrollBarWidth, // Trừ độ rộng scrollbar
                Height = 30,
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 10 + (optionTextBoxes.Count * 40)),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                PlaceholderText = $"Lựa chọn {optionTextBoxes.Count + 1}"
            };

            Button removeButton = new Button
            {
                Text = "Xóa",
                Width = 60,
                Height = 30,
                Location = new Point(panelOptions.Width - 85 - SystemInformation.VerticalScrollBarWidth, optionTextBox.Location.Y),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = optionTextBox
            };
            removeButton.Click += RemoveOption_Click;

            // Chỉ hiện nút xóa nếu có nhiều hơn 2 option
            removeButton.Visible = optionTextBoxes.Count >= 2;

            optionTextBoxes.Add(optionTextBox);
            panelOptions.Controls.Add(optionTextBox);
            panelOptions.Controls.Add(removeButton);

            // Cập nhật visibility của tất cả nút xóa
            UpdateRemoveButtonsVisibility();

            // Không cần điều chỉnh chiều cao panel nữa vì đã có AutoScroll
            // Chỉ cần đảm bảo panel có thể hiển thị tất cả controls
            UpdatePanelScrollableArea();
        }

        private void RemoveOption_Click(object sender, EventArgs e)
        {
            Button removeButton = sender as Button;
            TextBox targetTextBox = removeButton.Tag as TextBox;

            if (optionTextBoxes.Count > 2) // Luôn giữ ít nhất 2 options
            {
                optionTextBoxes.Remove(targetTextBox);
                panelOptions.Controls.Remove(targetTextBox);
                panelOptions.Controls.Remove(removeButton);

                // Sắp xếp lại vị trí các textbox còn lại
                ReorganizeOptions();
                UpdateRemoveButtonsVisibility();

                // Cập nhật vùng cuộn
                UpdatePanelScrollableArea();
            }
        }

        private void ReorganizeOptions()
        {
            for (int i = 0; i < optionTextBoxes.Count; i++)
            {
                optionTextBoxes[i].Location = new Point(10, 10 + (i * 40));
                optionTextBoxes[i].PlaceholderText = $"Lựa chọn {i + 1}";

                // Tìm và di chuyển nút xóa tương ứng
                foreach (Control control in panelOptions.Controls)
                {
                    if (control is Button btn && btn.Tag == optionTextBoxes[i])
                    {
                        btn.Location = new Point(panelOptions.Width - 85 - SystemInformation.VerticalScrollBarWidth, optionTextBoxes[i].Location.Y);
                        break;
                    }
                }
            }
        }

        private void UpdateRemoveButtonsVisibility()
        {
            foreach (Control control in panelOptions.Controls)
            {
                if (control is Button btn && btn.Text == "Xóa")
                {
                    btn.Visible = optionTextBoxes.Count > 2;
                }
            }
        }

        private void UpdatePanelScrollableArea()
        {
            if (optionTextBoxes.Count > 0)
            {
                // Tính toán chiều cao cần thiết cho tất cả options
                int requiredHeight = (optionTextBoxes.Count * 40) + 20;

                // Thiết lập AutoScrollMinSize để panel biết cần scroll bao nhiều
                panelOptions.AutoScrollMinSize = new Size(0, requiredHeight);
            }
        }

        private void btnAddOption_Click(object sender, EventArgs e)
        {
            if (optionTextBoxes.Count < 10) // Giới hạn tối đa 10 options
            {
                AddOptionTextBox();
            }
            else
            {
                MessageBox.Show("Tối đa 10 lựa chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateForm()
        {
            // Kiểm tra title
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề bình chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            // Kiểm tra description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả bình chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            // Kiểm tra options
            var filledOptions = optionTextBoxes.Where(tb => !string.IsNullOrWhiteSpace(tb.Text)).ToList();
            if (filledOptions.Count < 2)
            {
                MessageBox.Show("Cần ít nhất 2 lựa chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra trùng lặp
            var optionTexts = filledOptions.Select(tb => tb.Text.Trim().ToLower()).ToList();
            if (optionTexts.Distinct().Count() != optionTexts.Count)
            {
                MessageBox.Show("Các lựa chọn không được trùng nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SetLoadingState(bool isLoading)
        {
            panelLoading.Visible = isLoading;
            btnCreate.Enabled = !isLoading;
            btnCancel.Enabled = !isLoading;
            txtTitle.Enabled = !isLoading;
            txtDescription.Enabled = !isLoading;
            panelOptions.Enabled = !isLoading;
            btnAddOption.Enabled = !isLoading;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            SetLoadingState(true);

            try
            {
                var optionTexts = optionTextBoxes
                  .Where(tb => !string.IsNullOrWhiteSpace(tb.Text))
                  .Select(tb => tb.Text.Trim())
                  .ToList();

                var createRequest = new
                {
                    title = txtTitle.Text.Trim(),
                    description = txtDescription.Text.Trim(),
                    userId = UserSession.UserId,
                    optionTexts = optionTexts
                };

                string jsonContent = JsonConvert.SerializeObject(createRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(
                  $"{Domain.name}/api/polls/create", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo bình chọn thành công!", "Thành công",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Không thể tạo bình chọn. Lỗi: {response.StatusCode}", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo bình chọn: {ex.Message}", "Lỗi",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}