namespace Elector.Forms
{
    partial class CreatePollForm
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
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblOptions = new Label();
            panelOptions = new Panel();
            btnAddOption = new Button();
            btnCreate = new Button();
            btnCancel = new Button();
            panelLoading = new Panel();
            lblLoading = new Label();
            panelLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(164, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tiêu đề bình chọn:";
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Font = new Font("Segoe UI", 11F);
            txtTitle.Location = new Point(20, 55);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Nhập tiêu đề cho bình chọn";
            txtTitle.Size = new Size(660, 32);
            txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescription.Location = new Point(20, 100);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 28);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(20, 135);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Nhập mô tả chi tiết cho bình chọn";
            txtDescription.Size = new Size(660, 60);
            txtDescription.TabIndex = 3;
            // 
            // lblOptions
            // 
            lblOptions.AutoSize = true;
            lblOptions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOptions.Location = new Point(20, 210);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(149, 28);
            lblOptions.TabIndex = 4;
            lblOptions.Text = "Các lựa chọn:";
            // 
            // panelOptions
            // 
            panelOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelOptions.AutoScroll = true;
            panelOptions.BackColor = Color.White;
            panelOptions.BorderStyle = BorderStyle.FixedSingle;
            panelOptions.Location = new Point(20, 245);
            panelOptions.Name = "panelOptions";
            panelOptions.Size = new Size(660, 150);
            panelOptions.TabIndex = 5;
            // 
            // btnAddOption
            // 
            btnAddOption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddOption.BackColor = Color.DodgerBlue;
            btnAddOption.FlatStyle = FlatStyle.Flat;
            btnAddOption.Font = new Font("Segoe UI Semibold", 10F);
            btnAddOption.ForeColor = Color.White;
            btnAddOption.Location = new Point(20, 410);
            btnAddOption.Name = "btnAddOption";
            btnAddOption.Size = new Size(120, 35);
            btnAddOption.TabIndex = 6;
            btnAddOption.Text = "Thêm lựa chọn";
            btnAddOption.UseVisualStyleBackColor = false;
            btnAddOption.Click += btnAddOption_Click;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreate.BackColor = Color.SeaGreen;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(450, 460);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(110, 45);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Tạo";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(570, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 45);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelLoading
            // 
            panelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLoading.BackColor = Color.FromArgb(150, 255, 255, 255);
            panelLoading.Controls.Add(lblLoading);
            panelLoading.Location = new Point(0, 0);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new Size(700, 520);
            panelLoading.TabIndex = 9;
            panelLoading.Visible = false;
            // 
            // lblLoading
            // 
            lblLoading.Anchor = AnchorStyles.None;
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(250, 240);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(200, 37);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Đang tạo...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CreatePollForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(700, 520);
            Controls.Add(panelLoading);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(btnAddOption);
            Controls.Add(panelOptions);
            Controls.Add(lblOptions);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreatePollForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo Bình Chọn Mới";
            panelLoading.ResumeLayout(false);
            panelLoading.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblOptions;
        private Panel panelOptions;
        private Button btnAddOption;
        private Button btnCreate;
        private Button btnCancel;
        private Panel panelLoading;
        private Label lblLoading;
    }
}