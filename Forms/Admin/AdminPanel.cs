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
    public partial class AdminPanel : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public AdminPanel()
        {
            InitializeComponent();
            LoadAllPolls();
        }

        private async void LoadAllPolls()
        {
            panelLoading.Visible = true;
            flowLayoutPanelPolls.Visible = false;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{Domain.name}/api/polls/all");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var polls = JsonConvert.DeserializeObject<List<Poll>>(responseContent);

                    // Sắp xếp theo trạng thái (đang hoạt động lên trước) và sau đó theo ngày tạo mới nhất
                    var sortedPolls = polls.OrderByDescending(p => p.IsActive).ThenByDescending(p => p.CreatedAt).ToList();
                    DisplayPolls(sortedPolls);
                }
                else
                {
                    MessageBox.Show("Không thể tải danh sách bình chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bình chọn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                panelLoading.Visible = false;
                flowLayoutPanelPolls.Visible = true;
            }
        }

        private void DisplayPolls(List<Poll> polls)
        {
            flowLayoutPanelPolls.Controls.Clear();
            lblPollCount.Text = $"Tổng số bình chọn: {polls.Count}";

            foreach (var poll in polls)
            {
                var pollPanel = CreateAdminPollPanel(poll);
                flowLayoutPanelPolls.Controls.Add(pollPanel);
            }
        }

        private Panel CreateAdminPollPanel(Poll poll)
        {
            Panel panel = new Panel
            {
                Width = flowLayoutPanelPolls.Width - 40,
                Height = 180,
                BackColor = Color.White,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Nhãn trạng thái
            Label lblStatus = new Label
            {
                Text = poll.IsActive == 1 ? "Đang hoạt động" : "Đã khóa",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15),
                ForeColor = poll.IsActive == 1 ? Color.SeaGreen : Color.Firebrick
            };

            // ID Poll
            Label lblId = new Label
            {
                Text = $"ID: {poll.Id}",
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(panel.Width - 80, 15),
                ForeColor = Color.Gray
            };

            // Tiêu đề poll
            Label lblTitle = new Label
            {
                Text = poll.Title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 40),
                Size = new Size(panel.Width - 40, 25),
                ForeColor = Color.DarkBlue,
                AutoEllipsis = true
            };

            // Mô tả poll
            Label lblDescription = new Label
            {
                Text = poll.Description,
                Location = new Point(20, 70),
                Size = new Size(panel.Width - 40, 35),
                Font = new Font("Segoe UI", 9),
                AutoEllipsis = true
            };

            // Ngày tạo
            Label lblCreated = new Label
            {
                Text = $"Tạo lúc: {DateTime.Parse(poll.CreatedAt).ToString("dd/MM/yyyy HH:mm")}",
                Location = new Point(20, 115),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray
            };

            // Số lượng options
            Label lblOptionsCount = new Label
            {
                Text = $"Số lựa chọn: {poll.Options?.Count ?? 0}",
                Location = new Point(230, 115),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray
            };

            // Nút xem chi tiết
            Button btnDetails = new Button
            {
                Text = "Chi tiết",
                Location = new Point(panel.Width - 370, 135),
                Size = new Size(80, 35),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = poll
            };
            btnDetails.Click += BtnDetails_Click;

            // Nút xem kết quả
            Button btnResults = new Button
            {
                Text = "Kết quả",
                Location = new Point(panel.Width - 280, 135),
                Size = new Size(80, 35),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = poll
            };
            btnResults.Click += BtnResults_Click;

            // Nút toggle trạng thái
            Button btnToggle = new Button
            {
                Text = poll.IsActive == 1 ? "Khóa" : "Mở",
                Location = new Point(panel.Width - 190, 135),
                Size = new Size(80, 35),
                BackColor = poll.IsActive == 1 ? Color.Orange : Color.LimeGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = poll
            };
            btnToggle.Click += BtnToggle_Click;

            // Nút xóa
            Button btnDelete = new Button
            {
                Text = "Xóa",
                Location = new Point(panel.Width - 100, 135),
                Size = new Size(80, 35),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = poll
            };
            btnDelete.Click += BtnDelete_Click;

            panel.Controls.Add(lblStatus);
            panel.Controls.Add(lblId);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDescription);
            panel.Controls.Add(lblCreated);
            panel.Controls.Add(lblOptionsCount);
            panel.Controls.Add(btnDetails);
            panel.Controls.Add(btnResults);
            panel.Controls.Add(btnToggle);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private async void BtnDetails_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Poll poll = btn.Tag as Poll;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{Domain.name}/api/polls/{poll.Id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var pollDetails = JsonConvert.DeserializeObject<Poll>(responseContent);

                    using (var detailsForm = new PollDetailsForm(pollDetails))
                    {
                        detailsForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể tải chi tiết bình chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnResults_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Poll poll = btn.Tag as Poll;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{Domain.name}/api/polls/{poll.Id}/results");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<PollResult>(responseContent);

                    using (var resultsForm = new ResultsForm(results))
                    {
                        resultsForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể tải kết quả bình chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải kết quả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnToggle_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Poll poll = btn.Tag as Poll;

            string action = poll.IsActive == 1 ? "khóa" : "mở khóa";
            string endpoint = poll.IsActive == 1 ? "lock" : "unlock";
            string successMessage = poll.IsActive == 1 ? "đã khóa" : "đã mở khóa";

            var result = MessageBox.Show($"Bạn có chắc chắn muốn {action} bình chọn '{poll.Title}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.PutAsync($"{Domain.name}/api/polls/{poll.Id}/{endpoint}", null);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Bình chọn {successMessage} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllPolls(); // Làm mới danh sách để cập nhật trạng thái và sắp xếp
                    }
                    else
                    {
                        MessageBox.Show($"Không thể {action} bình chọn! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi {action} bình chọn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Poll poll = btn.Tag as Poll;

            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa bình chọn '{poll.Title}'?\nHành động này không thể hoàn tác!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{Domain.name}/api/polls/{poll.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa bình chọn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllPolls(); // Làm mới danh sách bình chọn
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa bình chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa bình chọn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCreatePoll_Click(object sender, EventArgs e)
        {
            using (var createForm = new CreatePollForm())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllPolls(); // Refresh danh sách sau khi tạo mới
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllPolls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form login = new Forms.Auth.Login();
            this.Hide();
            login.Show();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}