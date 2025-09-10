namespace Elector.Forms
{
    partial class VoteForm
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
            lblPollTitle = new Label();
            lblPollDescription = new Label();
            flowLayoutPanelOptions = new FlowLayoutPanel();
            btnSubmitVote = new Button();
            btnCancel = new Button();
            label1 = new Label();
            panelLoading = new Panel();
            lblLoading = new Label();
            panelLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblPollTitle
            // 
            lblPollTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPollTitle.ForeColor = Color.DarkBlue;
            lblPollTitle.Location = new Point(20, 20);
            lblPollTitle.Name = "lblPollTitle";
            lblPollTitle.Size = new Size(660, 35);
            lblPollTitle.TabIndex = 0;
            lblPollTitle.Text = "Tiêu đề bình chọn";
            // 
            // lblPollDescription
            // 
            lblPollDescription.Font = new Font("Segoe UI", 10F);
            lblPollDescription.Location = new Point(20, 65);
            lblPollDescription.Name = "lblPollDescription";
            lblPollDescription.Size = new Size(660, 45);
            lblPollDescription.TabIndex = 1;
            lblPollDescription.Text = "Mô tả bình chọn";
            // 
            // flowLayoutPanelOptions
            // 
            flowLayoutPanelOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelOptions.AutoScroll = true;
            flowLayoutPanelOptions.Location = new Point(20, 155);
            flowLayoutPanelOptions.Name = "flowLayoutPanelOptions";
            flowLayoutPanelOptions.Padding = new Padding(5);
            flowLayoutPanelOptions.Size = new Size(660, 220);
            flowLayoutPanelOptions.TabIndex = 2;
            // 
            // btnSubmitVote
            // 
            btnSubmitVote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSubmitVote.BackColor = Color.SeaGreen;
            btnSubmitVote.FlatAppearance.BorderSize = 0;
            btnSubmitVote.FlatStyle = FlatStyle.Flat;
            btnSubmitVote.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSubmitVote.ForeColor = Color.White;
            btnSubmitVote.Location = new Point(445, 390);
            btnSubmitVote.Name = "btnSubmitVote";
            btnSubmitVote.Size = new Size(110, 40);
            btnSubmitVote.TabIndex = 3;
            btnSubmitVote.Text = "Bình chọn";
            btnSubmitVote.UseVisualStyleBackColor = false;
            btnSubmitVote.Click += btnSubmitVote_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(570, 390);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(20, 125);
            label1.Name = "label1";
            label1.Size = new Size(196, 25);
            label1.TabIndex = 5;
            label1.Text = "Chọn lựa chọn của bạn:";
            // 
            // panelLoading
            // 
            panelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLoading.BackColor = Color.FromArgb(150, 255, 255, 255);
            panelLoading.Controls.Add(lblLoading);
            panelLoading.Location = new Point(0, 0);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(700, 450);
            panelLoading.TabIndex = 6;
            panelLoading.Visible = false;
            // 
            // lblLoading
            // 
            lblLoading.Anchor = AnchorStyles.None;
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(270, 210);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(160, 37);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Đang gửi...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VoteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(700, 450);
            Controls.Add(panelLoading);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmitVote);
            Controls.Add(flowLayoutPanelOptions);
            Controls.Add(lblPollDescription);
            Controls.Add(lblPollTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VoteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bình chọn";
            panelLoading.ResumeLayout(false);
            panelLoading.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPollTitle;
        private Label lblPollDescription;
        private FlowLayoutPanel flowLayoutPanelOptions;
        private Button btnSubmitVote;
        private Button btnCancel;
        private Label label1;
        private Panel panelLoading;
        private Label lblLoading;
    }
}