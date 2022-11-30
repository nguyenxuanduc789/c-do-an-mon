namespace WEATHER
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.otpHidePass = new System.Windows.Forms.CheckBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdoStudent = new System.Windows.Forms.RadioButton();
            this.rdoTeacher = new System.Windows.Forms.RadioButton();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPass
            // 
            this.lblPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblPass.Location = new System.Drawing.Point(237, 258);
            this.lblPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(106, 24);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Passwords:";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(350, 240);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(250, 42);
            this.txtPass.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(350, 188);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 41);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Location = new System.Drawing.Point(237, 206);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(105, 24);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "UserName:";
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblLogin.Location = new System.Drawing.Point(206, 154);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(117, 37);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.Text = "LOGIN";
            // 
            // otpHidePass
            // 
            this.otpHidePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.otpHidePass.AutoSize = true;
            this.otpHidePass.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.otpHidePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otpHidePass.ForeColor = System.Drawing.SystemColors.Desktop;
            this.otpHidePass.Location = new System.Drawing.Point(350, 298);
            this.otpHidePass.Margin = new System.Windows.Forms.Padding(2);
            this.otpHidePass.Name = "otpHidePass";
            this.otpHidePass.Size = new System.Drawing.Size(128, 21);
            this.otpHidePass.TabIndex = 7;
            this.otpHidePass.Text = "Hide Passwords";
            this.otpHidePass.UseVisualStyleBackColor = false;
            this.otpHidePass.CheckedChanged += new System.EventHandler(this.otpHidePass_CheckedChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblQuery.AutoSize = true;
            this.lblQuery.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblQuery.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblQuery.Location = new System.Drawing.Point(185, 469);
            this.lblQuery.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(180, 17);
            this.lblQuery.TabIndex = 10;
            this.lblQuery.Text = "Don\'t have an account?";
            // 
            // btnSignUp
            // 
            this.btnSignUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSignUp.BackColor = System.Drawing.Color.White;
            this.btnSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSignUp.Location = new System.Drawing.Point(377, 455);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(100, 36);
            this.btnSignUp.TabIndex = 12;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WEATHER.Properties.Resources.dh_cong_nghe_tphcm;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 88);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // rdoStudent
            // 
            this.rdoStudent.AutoSize = true;
            this.rdoStudent.Checked = true;
            this.rdoStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStudent.Location = new System.Drawing.Point(350, 341);
            this.rdoStudent.Margin = new System.Windows.Forms.Padding(2);
            this.rdoStudent.Name = "rdoStudent";
            this.rdoStudent.Size = new System.Drawing.Size(91, 24);
            this.rdoStudent.TabIndex = 16;
            this.rdoStudent.TabStop = true;
            this.rdoStudent.Text = "Student";
            this.rdoStudent.UseVisualStyleBackColor = true;
            this.rdoStudent.Click += new System.EventHandler(this.rdoStudent_Click);
            // 
            // rdoTeacher
            // 
            this.rdoTeacher.AutoSize = true;
            this.rdoTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTeacher.Location = new System.Drawing.Point(496, 341);
            this.rdoTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.rdoTeacher.Name = "rdoTeacher";
            this.rdoTeacher.Size = new System.Drawing.Size(92, 24);
            this.rdoTeacher.TabIndex = 17;
            this.rdoTeacher.Text = "Teacher";
            this.rdoTeacher.UseVisualStyleBackColor = true;
            this.rdoTeacher.Click += new System.EventHandler(this.rdoTeacher_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.SystemColors.Window;
            this.btnStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.Location = new System.Drawing.Point(350, 387);
            this.btnStudent.Margin = new System.Windows.Forms.Padding(2);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(88, 34);
            this.btnStudent.TabIndex = 18;
            this.btnStudent.Text = "Student";
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnTeacher
            // 
            this.btnTeacher.BackColor = System.Drawing.SystemColors.Window;
            this.btnTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacher.Location = new System.Drawing.Point(496, 387);
            this.btnTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(85, 34);
            this.btnTeacher.TabIndex = 19;
            this.btnTeacher.Text = "Teacher";
            this.btnTeacher.UseVisualStyleBackColor = false;
            this.btnTeacher.Visible = false;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(544, 477);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(97, 13);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "QUÊN MẬT KHẨU";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WEATHER.Properties.Resources.fb1480fa7083c7b337cf4660f1d35a571;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(798, 539);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnTeacher);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.rdoTeacher);
            this.Controls.Add(this.rdoStudent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.otpHidePass);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.CheckBox otpHidePass;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdoStudent;
        private System.Windows.Forms.RadioButton rdoTeacher;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnTeacher;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

