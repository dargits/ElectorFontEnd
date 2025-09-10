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
using System.Drawing.Drawing2D;

namespace Elector.Forms
{
    public partial class VoteForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private Poll _poll;
        private Panel _selectedOptionPanel;

        public VoteForm(Poll poll)
        {
            InitializeComponent();
            _poll = poll;
            LoadPollInfo();
        }

        private void LoadPollInfo()
        {
            lblPollTitle.Text = _poll.Title;
            lblPollDescription.Text = _poll.Description;

            flowLayoutPanelOptions.Controls.Clear();
            _selectedOptionPanel = null;

            foreach (var option in _poll.Options)
            {
                var optionPanel = CreateOptionPanel(option);
                flowLayoutPanelOptions.Controls.Add(optionPanel);
            }
        }

        private Panel CreateOptionPanel(Option option)
        {
            Panel panel = new Panel
            {
                Width = flowLayoutPanelOptions.ClientSize.Width - flowLayoutPanelOptions.Padding.Horizontal - 2,
                Height = 80,
                Tag = option,
                Margin = new Padding(0, 5, 0, 5),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Gắn sự kiện click cho Panel
            panel.Click += OptionPanel_Click;

            // Vẽ bo góc và đường viền
            panel.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int borderRadius = 10;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
                    path.AddArc(panel.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
                    path.AddArc(panel.Width - borderRadius * 2, panel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
                    path.AddArc(0, panel.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
                    path.CloseFigure();

                    panel.Region = new Region(path);

                    Color borderColor = panel == _selectedOptionPanel ? Color.DodgerBlue : Color.LightGray;
                    int borderWidth = panel == _selectedOptionPanel ? 3 : 1;

                    using (var pen = new Pen(borderColor, borderWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // Hiệu ứng hover
            Color originalColor = panel.BackColor;
            panel.MouseEnter += (sender, e) => { panel.BackColor = Color.FromArgb(245, 245, 245); };
            panel.MouseLeave += (sender, e) => { panel.BackColor = originalColor; };

            Label lblOptionText = new Label
            {
                Text = option.OptionText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(5),
                BackColor = Color.Transparent
            };

            // Gắn cùng một sự kiện click cho Label
            lblOptionText.Click += OptionPanel_Click;

            panel.Controls.Add(lblOptionText);

            return panel;
        }

        // Phương thức xử lý sự kiện click duy nhất cho cả Panel và Label
        private void OptionPanel_Click(object sender, EventArgs e)
        {
            // Tìm panel cha (nếu sender là Label)
            Panel clickedPanel = (sender as Panel) ?? ((Control)sender).Parent as Panel;

            // Bỏ chọn thẻ cũ
            if (_selectedOptionPanel != null)
            {
                _selectedOptionPanel.Invalidate();
            }

            // Chọn thẻ mới
            _selectedOptionPanel = clickedPanel;
            _selectedOptionPanel.Invalidate();
        }

        private void SetLoadingState(bool isLoading)
        {
            panelLoading.Visible = isLoading;
            btnSubmitVote.Enabled = !isLoading;
            btnCancel.Enabled = !isLoading;
        }

        private async void btnSubmitVote_Click(object sender, EventArgs e)
        {
            if (_selectedOptionPanel == null)
            {
                MessageBox.Show("Vui lòng chọn một lựa chọn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var option = _selectedOptionPanel.Tag as Option;
            SetLoadingState(true);

            try
            {
                var voteRequest = new
                {
                    pollId = _poll.Id,
                    optionId = option.Id,
                    userId = UserSession.UserId
                };

                string jsonContent = JsonConvert.SerializeObject(voteRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(
                    $"{Domain.name}/api/votes/submit", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bình chọn của bạn đã được gửi thành công. Cảm ơn bạn đã tham gia!", "Bình chọn thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Bạn đã bình chọn cho cuộc thăm dò này rồi!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không thể gửi bình chọn. Vui lòng thử lại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
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