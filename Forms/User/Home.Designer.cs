namespace Elector.Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            lblWelcome = new Label();
            lblUserAccount = new Label();
            btnRefresh = new Button();
            btnLogout = new Button();
            btnAdminPanel = new Button();
            flowLayoutPanelPolls = new FlowLayoutPanel();
            label1 = new Label();
            panelHeader = new Panel();
            panelLoading = new Panel();
            lblLoading = new Label();
            panelHeader.SuspendLayout();
            panelLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.DarkBlue;
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(174, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng!";
            // 
            // lblUserAccount
            // 
            lblUserAccount.AutoSize = true;
            lblUserAccount.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblUserAccount.Font = new Font("Segoe UI", 10F);
            lblUserAccount.Location = new Point(20, 65);
            lblUserAccount.Name = "lblUserAccount";
            lblUserAccount.Size = new Size(86, 23);
            lblUserAccount.TabIndex = 1;
            lblUserAccount.Text = "Tài khoản:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DodgerBlue;
            btnRefresh.Font = new Font("Segoe UI Semibold", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(15, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 40);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.Firebrick;
            btnLogout.Font = new Font("Segoe UI Semibold", 10F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1020, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 40);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdminPanel.BackColor = Color.Indigo;
            btnAdminPanel.Font = new Font("Segoe UI Semibold", 10F);
            btnAdminPanel.ForeColor = Color.White;
            btnAdminPanel.Location = new Point(900, 15);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new Size(110, 40);
            btnAdminPanel.TabIndex = 5;
            btnAdminPanel.Text = "Quản trị";
            btnAdminPanel.UseVisualStyleBackColor = false;
            btnAdminPanel.Visible = false;
            btnAdminPanel.Click += btnAdminPanel_Click;
            // 
            // flowLayoutPanelPolls
            // 
            flowLayoutPanelPolls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelPolls.AutoScroll = true;
            flowLayoutPanelPolls.BackColor = Color.White;
            flowLayoutPanelPolls.Location = new Point(20, 180);
            flowLayoutPanelPolls.Name = "flowLayoutPanelPolls";
            flowLayoutPanelPolls.Padding = new Padding(5);
            flowLayoutPanelPolls.Size = new Size(1138, 400);
            flowLayoutPanelPolls.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(20, 140);
            label1.Name = "label1";
            label1.Size = new Size(259, 32);
            label1.TabIndex = 7;
            label1.Text = "Danh sách bình chọn:";
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.LightSteelBlue;
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Controls.Add(btnAdminPanel);
            panelHeader.Location = new Point(20, 100);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1138, 70);
            panelHeader.TabIndex = 8;
            // 
            // panelLoading
            // 
            panelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLoading.BackColor = Color.FromArgb(0, 0, 0, 0);
            panelLoading.Controls.Add(lblLoading);
            panelLoading.Location = new Point(20, 180);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(1138, 400);
            panelLoading.TabIndex = 9;
            panelLoading.Visible = false;
            // 
            // lblLoading
            // 
            lblLoading.Anchor = AnchorStyles.None;
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(480, 180);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(137, 37);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Đang tải...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(1178, 600);
            Controls.Add(panelLoading);
            Controls.Add(panelHeader);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanelPolls);
            Controls.Add(lblUserAccount);
            Controls.Add(lblWelcome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elector Manager - Trang chủ";
            FormClosing += Home_FormClosing;
            panelHeader.ResumeLayout(false);
            panelLoading.ResumeLayout(false);
            panelLoading.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblUserAccount;
        private Button btnRefresh;
        private Button btnLogout;
        private Button btnAdminPanel;
        private FlowLayoutPanel flowLayoutPanelPolls;
        private Label label1;
        private Panel panelHeader;
        private Panel panelLoading;
        private Label lblLoading;
    }
}