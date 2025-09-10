using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elector.Forms
{
    public partial class PollDetailsForm : Form
    {
        private Poll _poll;

        public PollDetailsForm(Poll poll)
        {
            InitializeComponent();
            _poll = poll;
            LoadPollDetails();
        }

        private void LoadPollDetails()
        {
            // Thông tin cơ bản
            lblPollTitle.Text = _poll.Title;
            lblPollId.Text = $"ID: {_poll.Id}";
            lblDescription.Text = _poll.Description;
            lblStatus.Text = _poll.IsActive == 1 ? "Đang hoạt động" : "Đã khóa";
            lblStatus.ForeColor = _poll.IsActive == 1 ? Color.SeaGreen : Color.Firebrick;
            lblCreatedAt.Text = $"Tạo lúc: {DateTime.Parse(_poll.CreatedAt).ToString("dd/MM/yyyy HH:mm:ss")}";

            // Hiển thị các lựa chọn
            LoadOptions();
        }

        private void LoadOptions()
        {
            flowLayoutPanelOptions.Controls.Clear();

            if (_poll.Options != null && _poll.Options.Any())
            {
                lblOptionsCount.Text = $"Số lựa chọn: {_poll.Options.Count}";

                foreach (var option in _poll.Options)
                {
                    var optionPanel = CreateOptionPanel(option);
                    flowLayoutPanelOptions.Controls.Add(optionPanel);
                }
            }
            else
            {
                lblOptionsCount.Text = "Số lựa chọn: 0";

                Label noOptionsLabel = new Label
                {
                    Text = "Không có lựa chọn nào",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                flowLayoutPanelOptions.Controls.Add(noOptionsLabel);
            }
        }

        private Panel CreateOptionPanel(Option option)
        {
            Panel panel = new Panel
            {
                Width = flowLayoutPanelOptions.Width - 25,
                Height = 50,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.White
            };

            // ID lựa chọn
            Label lblId = new Label
            {
                Text = $"ID: {option.Id}",
                Font = new Font("Segoe UI", 8),
                Location = new Point(panel.Width - 80, 5),
                AutoSize = true,
                ForeColor = Color.Gray
            };

            // Nội dung lựa chọn
            Label lblOptionText = new Label
            {
                Text = option.OptionText,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(10, 15),
                Size = new Size(panel.Width - 100, 25),
                AutoEllipsis = true,
                ForeColor = Color.DarkBlue
            };

            panel.Controls.Add(lblId);
            panel.Controls.Add(lblOptionText);

            return panel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}