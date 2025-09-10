using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elector.Forms
{
    public partial class ResultsForm : Form
    {
        private PollResult _pollResults;

        public ResultsForm(PollResult results)
        {
            InitializeComponent();
            _pollResults = results;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            DisplayResults();
        }

        private void DisplayResults()
        {
            lblPollTitle.Text = _pollResults.PollTitle;
            long totalVotes = _pollResults.Results.Sum(r => r.VoteCount);
            lblTotalVotes.Text = $"Tổng số phiếu: {totalVotes}";

            flowLayoutPanelResults.Controls.Clear();

            // Sắp xếp kết quả theo số phiếu giảm dần
            var sortedResults = _pollResults.Results.OrderByDescending(r => r.VoteCount).ToList();

            foreach (var option in sortedResults)
            {
                var resultPanel = CreateResultPanel(option, totalVotes);
                flowLayoutPanelResults.Controls.Add(resultPanel);
            }
        }

        private Panel CreateResultPanel(ResultOption option, long totalVotes)
        {
            Panel panel = new Panel
            {
                Width = flowLayoutPanelResults.Width - 25,
                Height = 60,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.White
            };

            // Tên lựa chọn
            Label lblOptionText = new Label
            {
                Text = option.OptionText,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(10, 5),
                Size = new Size(panel.Width - 120, 25),
                AutoEllipsis = true
            };

            // Số phiếu
            Label lblVoteCount = new Label
            {
                Text = $"{option.VoteCount} phiếu",
                Font = new Font("Segoe UI", 10),
                Location = new Point(panel.Width - 110, 5),
                AutoSize = true
            };

            // Thanh tiến trình
            ProgressBar progress = new ProgressBar
            {
                Location = new Point(10, 35),
                Size = new Size(panel.Width - 20, 15),
                Maximum = (int)totalVotes,
                Value = (int)option.VoteCount,
                Style = ProgressBarStyle.Continuous
            };

            // Hiển thị phần trăm trên thanh tiến trình (tùy chọn)
            Label lblPercentage = new Label
            {
                Text = totalVotes > 0 ? $"{(double)option.VoteCount / totalVotes:P0}" : "0%",
                Location = new Point(progress.Location.X + progress.Width + 5, progress.Location.Y),
                Font = new Font("Segoe UI", 9),
                AutoSize = true
            };

            panel.Controls.Add(lblOptionText);
            panel.Controls.Add(lblVoteCount);
            panel.Controls.Add(progress);
            panel.Controls.Add(lblPercentage);

            return panel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}