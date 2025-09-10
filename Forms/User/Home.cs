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
    public partial class Home : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Home()
        {
            InitializeComponent();
            InitializeHomeForm();
        }

        private void InitializeHomeForm()
        {
            LoadUserInfo();
            LoadActivePolls();
        }

        private void LoadUserInfo()
        {
            lblWelcome.Text = $"Chào mừng, {UserSession.FullName}!";
            lblUserAccount.Text = $"Tài khoản: {UserSession.Username}";
            btnAdminPanel.Visible = UserSession.IsAdmin;
        }

        private async void LoadActivePolls()
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

                    // Sắp xếp các cuộc bình chọn
                    var activePolls = polls.Where(p => p.IsActive == 1)
                                           .OrderByDescending(p => p.CreatedAt)
                                           .ToList();
                    var lockedPolls = polls.Where(p => p.IsActive != 1)
                                           .OrderByDescending(p => p.CreatedAt)
                                           .ToList();

                    var sortedPolls = activePolls.Concat(lockedPolls).ToList();

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

            foreach (var poll in polls)
            {
                var pollPanel = CreatePollPanel(poll);
                flowLayoutPanelPolls.Controls.Add(pollPanel);
            }
        }

        private Panel CreatePollPanel(Poll poll)
        {
            // Panel chính cho thẻ bình chọn
            Panel panel = new Panel
            {
                Width = flowLayoutPanelPolls.Width - 40,
                Height = 160,
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            // Vẽ hiệu ứng đổ bóng và bo góc
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

                    // Vẽ đổ bóng đơn giản
                    using (var pen = new Pen(Color.FromArgb(50, 0, 0, 0), 2))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // Hiệu ứng hover
            Color originalColor = panel.BackColor;
            panel.MouseEnter += (sender, e) => { panel.BackColor = Color.FromArgb(240, 240, 240); };
            panel.MouseLeave += (sender, e) => { panel.BackColor = originalColor; };

            // Nhãn trạng thái
            Label lblStatus = new Label
            {
                Text = poll.IsActive == 1 ? "Đang diễn ra" : "Đã khóa",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15),
                ForeColor = poll.IsActive == 1 ? Color.SeaGreen : Color.Firebrick
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
                Size = new Size(panel.Width - 40, 40),
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

            // Nút vote
            Button btnVote = new Button
            {
                Text = "Bình chọn",
                Location = new Point(panel.Width - 250, 105),
                Size = new Size(110, 40),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = poll
            };
            btnVote.Click += BtnVote_Click;

            // Nút xem kết quả
            Button btnResults = new Button
            {
                Text = "Xem kết quả",
                Location = new Point(panel.Width - 130, 105),
                Size = new Size(110, 40),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = poll
            };
            btnResults.Click += BtnResults_Click;

            // Kiểm tra trạng thái và cập nhật nút vote
            CheckIfUserVoted(poll, btnVote);

            panel.Controls.Add(lblStatus);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDescription);
            panel.Controls.Add(lblCreated);
            panel.Controls.Add(btnVote);
            panel.Controls.Add(btnResults);

            return panel;
        }

        // ... (Các phương thức khác giữ nguyên)

        private async void CheckIfUserVoted(Poll poll, Button btnVote)
        {
            if (poll.IsActive != 1)
            {
                btnVote.Text = "Đã đóng";
                btnVote.BackColor = Color.Gray;
                btnVote.Enabled = false;
                return;
            }

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(
                    $"{Domain.name}/api/votes/hasVoted/{UserSession.UserId}/{poll.Id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    bool hasVoted = JsonConvert.DeserializeObject<bool>(responseContent);

                    if (hasVoted)
                    {
                        btnVote.Text = "Đã bình chọn";
                        btnVote.BackColor = Color.Gray;
                        btnVote.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra trạng thái bình chọn: {ex.Message}");
            }
        }

        private async void BtnVote_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Poll poll = btn.Tag as Poll;

            // Tạo và mở form bình chọn
            using (var voteForm = new VoteForm(poll))
            {
                if (voteForm.ShowDialog() == DialogResult.OK)
                {
                    LoadActivePolls();
                }
            }
        }

        private async void BtnResults_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Poll poll = btn.Tag as Poll;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(
                    $"{Domain.name}/api/polls/{poll.Id}/results");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<PollResult>(responseContent);
                    // Mở form hiển thị kết quả
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadActivePolls();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            var loginForm = new Auth.Login();
            this.Hide();
            loginForm.Show();
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin panel chưa được implement!");
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

    public class Poll
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("isActive")]
        public int IsActive { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("optionText")]
        public string OptionText { get; set; }
    }

    public class PollResult
    {
        [JsonProperty("pollId")]
        public int PollId { get; set; }

        [JsonProperty("pollTitle")]
        public string PollTitle { get; set; }

        [JsonProperty("results")]
        public List<ResultOption> Results { get; set; }
    }

    public class ResultOption
    {
        [JsonProperty("optionId")]
        public int OptionId { get; set; }

        [JsonProperty("optionText")]
        public string OptionText { get; set; }

        [JsonProperty("voteCount")]
        public long VoteCount { get; set; }
    }
}