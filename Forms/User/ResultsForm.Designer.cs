namespace Elector.Forms
{
    partial class ResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsForm));
            lblPollTitle = new Label();
            lblTotalVotes = new Label();
            flowLayoutPanelResults = new FlowLayoutPanel();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblPollTitle
            // 
            lblPollTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPollTitle.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblPollTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPollTitle.ForeColor = Color.DarkBlue;
            lblPollTitle.Location = new Point(20, 20);
            lblPollTitle.Name = "lblPollTitle";
            lblPollTitle.Size = new Size(760, 45);
            lblPollTitle.TabIndex = 0;
            lblPollTitle.Text = "Tên Bình Chọn";
            lblPollTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalVotes
            // 
            lblTotalVotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalVotes.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblTotalVotes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalVotes.Location = new Point(20, 75);
            lblTotalVotes.Name = "lblTotalVotes";
            lblTotalVotes.Size = new Size(760, 28);
            lblTotalVotes.TabIndex = 1;
            lblTotalVotes.Text = "Tổng số phiếu: 0";
            lblTotalVotes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelResults
            // 
            flowLayoutPanelResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelResults.AutoScroll = true;
            flowLayoutPanelResults.BackColor = Color.FromArgb(0, 0, 0, 0);
            flowLayoutPanelResults.Location = new Point(20, 110);
            flowLayoutPanelResults.Name = "flowLayoutPanelResults";
            flowLayoutPanelResults.Padding = new Padding(5);
            flowLayoutPanelResults.Size = new Size(760, 420);
            flowLayoutPanelResults.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.Gray;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 10F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(680, 545);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(800, 600);
            Controls.Add(btnClose);
            Controls.Add(flowLayoutPanelResults);
            Controls.Add(lblTotalVotes);
            Controls.Add(lblPollTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(700, 500);
            Name = "ResultsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kết quả Bình chọn";
            Load += ResultsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblPollTitle;
        private Label lblTotalVotes;
        private FlowLayoutPanel flowLayoutPanelResults;
        private Button btnClose;
    }
}