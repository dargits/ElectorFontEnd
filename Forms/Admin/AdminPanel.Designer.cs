namespace Elector.Forms
{
    partial class AdminPanel
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
            lblTitle = new Label();
            btnCreatePoll = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            flowLayoutPanelPolls = new FlowLayoutPanel();
            lblPollCount = new Label();
            panelHeader = new Panel();
            panelLoading = new Panel();
            lblLoading = new Label();
            panelHeader.SuspendLayout();
            panelLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bảng Quản Trị";
            // 
            // btnCreatePoll
            // 
            btnCreatePoll.BackColor = Color.SeaGreen;
            btnCreatePoll.Font = new Font("Segoe UI Semibold", 11F);
            btnCreatePoll.ForeColor = Color.White;
            btnCreatePoll.Location = new Point(15, 15);
            btnCreatePoll.Name = "btnCreatePoll";
            btnCreatePoll.Size = new Size(130, 45);
            btnCreatePoll.TabIndex = 1;
            btnCreatePoll.Text = "Tạo Bình Chọn";
            btnCreatePoll.UseVisualStyleBackColor = false;
            btnCreatePoll.Click += btnCreatePoll_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DodgerBlue;
            btnRefresh.Font = new Font("Segoe UI Semibold", 11F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(155, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm Mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Firebrick;
            btnClose.Font = new Font("Segoe UI Semibold", 11F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(976, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(157, 45);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đăng xuất";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // flowLayoutPanelPolls
            // 
            flowLayoutPanelPolls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelPolls.AutoScroll = true;
            flowLayoutPanelPolls.BackColor = Color.White;
            flowLayoutPanelPolls.Location = new Point(20, 150);
            flowLayoutPanelPolls.Name = "flowLayoutPanelPolls";
            flowLayoutPanelPolls.Padding = new Padding(5);
            flowLayoutPanelPolls.Size = new Size(1138, 450);
            flowLayoutPanelPolls.TabIndex = 4;
            // 
            // lblPollCount
            // 
            lblPollCount.AutoSize = true;
            lblPollCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPollCount.Location = new Point(20, 115);
            lblPollCount.Name = "lblPollCount";
            lblPollCount.Size = new Size(210, 28);
            lblPollCount.TabIndex = 5;
            lblPollCount.Text = "Tổng số bình chọn: 0";
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.LightSteelBlue;
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(btnCreatePoll);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Location = new Point(20, 70);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1138, 75);
            panelHeader.TabIndex = 6;
            // 
            // panelLoading
            // 
            panelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLoading.BackColor = Color.White;
            panelLoading.Controls.Add(lblLoading);
            panelLoading.Location = new Point(20, 150);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(1138, 450);
            panelLoading.TabIndex = 7;
            panelLoading.Visible = false;
            // 
            // lblLoading
            // 
            lblLoading.Anchor = AnchorStyles.None;
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(490, 215);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(137, 37);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Đang tải...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1178, 620);
            Controls.Add(panelLoading);
            Controls.Add(panelHeader);
            Controls.Add(lblPollCount);
            Controls.Add(flowLayoutPanelPolls);
            Controls.Add(lblTitle);
            MinimumSize = new Size(1000, 600);
            Name = "AdminPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elector Manager - Bảng Quản Trị";
            FormClosing += AdminPanel_FormClosing;
            FormClosed += AdminPanel_FormClosed;
            Load += AdminPanel_Load;
            panelHeader.ResumeLayout(false);
            panelLoading.ResumeLayout(false);
            panelLoading.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnCreatePoll;
        private Button btnRefresh;
        private Button btnClose;
        private FlowLayoutPanel flowLayoutPanelPolls;
        private Label lblPollCount;
        private Panel panelHeader;
        private Panel panelLoading;
        private Label lblLoading;
    }
}