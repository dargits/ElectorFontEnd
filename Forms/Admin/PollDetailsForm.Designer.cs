using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Elector.Forms
{
    partial class PollDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PollDetailsForm));
            lblPollTitle = new Label();
            lblPollId = new Label();
            lblDescription = new Label();
            lblStatus = new Label();
            lblCreatedAt = new Label();
            lblOptionsCount = new Label();
            flowLayoutPanelOptions = new FlowLayoutPanel();
            btnClose = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblPollTitle
            // 
            lblPollTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPollTitle.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblPollTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPollTitle.ForeColor = Color.DarkBlue;
            lblPollTitle.Location = new Point(20, 25);
            lblPollTitle.Name = "lblPollTitle";
            lblPollTitle.Size = new Size(560, 40);
            lblPollTitle.TabIndex = 0;
            lblPollTitle.Text = "Tiêu đề bình chọn";
            // 
            // lblPollId
            // 
            lblPollId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPollId.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblPollId.Font = new Font("Segoe UI", 10F);
            lblPollId.ForeColor = Color.Gray;
            lblPollId.Location = new Point(480, 65);
            lblPollId.Name = "lblPollId";
            lblPollId.Size = new Size(100, 20);
            lblPollId.TabIndex = 1;
            lblPollId.Text = "ID: 1";
            lblPollId.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblDescription.Font = new Font("Segoe UI", 11F);
            lblDescription.Location = new Point(20, 70);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(450, 60);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Mô tả bình chọn";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.Location = new Point(15, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(108, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Trạng thái";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Font = new Font("Segoe UI", 10F);
            lblCreatedAt.ForeColor = Color.Gray;
            lblCreatedAt.Location = new Point(15, 50);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(111, 23);
            lblCreatedAt.TabIndex = 4;
            lblCreatedAt.Text = "Tạo lúc: ngày";
            // 
            // lblOptionsCount
            // 
            lblOptionsCount.AutoSize = true;
            lblOptionsCount.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblOptionsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOptionsCount.Location = new Point(20, 210);
            lblOptionsCount.Name = "lblOptionsCount";
            lblOptionsCount.Size = new Size(146, 28);
            lblOptionsCount.TabIndex = 5;
            lblOptionsCount.Text = "Số lựa chọn: 0";
            // 
            // flowLayoutPanelOptions
            // 
            flowLayoutPanelOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelOptions.AutoScroll = true;
            flowLayoutPanelOptions.BackColor = Color.FromArgb(0, 0, 0, 0);
            flowLayoutPanelOptions.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelOptions.Location = new Point(20, 250);
            flowLayoutPanelOptions.Name = "flowLayoutPanelOptions";
            flowLayoutPanelOptions.Padding = new Padding(5);
            flowLayoutPanelOptions.Size = new Size(560, 250);
            flowLayoutPanelOptions.TabIndex = 6;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 11F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(480, 515);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LightSteelBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblCreatedAt);
            panel1.Location = new Point(20, 140);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 55);
            panel1.TabIndex = 8;
            // 
            // PollDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(600, 570);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(flowLayoutPanelOptions);
            Controls.Add(lblOptionsCount);
            Controls.Add(lblDescription);
            Controls.Add(lblPollId);
            Controls.Add(lblPollTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(500, 400);
            Name = "PollDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết Bình chọn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPollTitle;
        private Label lblPollId;
        private Label lblDescription;
        private Label lblStatus;
        private Label lblCreatedAt;
        private Label lblOptionsCount;
        private FlowLayoutPanel flowLayoutPanelOptions;
        private Button btnClose;
        private Panel panel1;
    }
}