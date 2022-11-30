using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WEATHER
{
    public partial class frmLogin : Form
    {
        private const String URIst = "http://localhost:3000/student/";
        private const String URItc = "  http://localhost:3000/Teacher/";
        // ẩn background của các label
        public frmLogin()
        {
            InitializeComponent();
            lblLogin.BackColor = System.Drawing.Color.Transparent; 
            lblQuery.BackColor = System.Drawing.Color.Transparent;
            lblName.BackColor = System.Drawing.Color.Transparent;
            lblPass.BackColor = System.Drawing.Color.Transparent;
            otpHidePass.BackColor = System.Drawing.Color.Transparent;  
            rdoStudent.BackColor =  System.Drawing.Color.Transparent;
            rdoTeacher.BackColor = System.Drawing.Color.Transparent;
            linkLabel1.BackColor = System.Drawing.Color.Transparent;
        }
        // mở ra trang đăng kí gv
        private void btnSignUp_Click(object sender, EventArgs e)
        {
             frmRegister DK = new frmRegister();
             DK.FormClosed += new FormClosedEventHandler(DK_FormClosed);
             Visible = false;
             DK.Show();

        }
        // ẩn trang đăng nhập
        void DK_FormClosed( object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
        // che mật khẩu *****
        private void otpHidePass_CheckedChanged(object sender, EventArgs e)
        {

            if (otpHidePass.Checked)
            {
                txtPass.PasswordChar = '*';
               
            }
            else
            {
                txtPass.PasswordChar = (char)0;
            }
        }
        // đăng nhập sinh viên
        private void btnStudent_Click(object sender, EventArgs e)
        {
            /*kiểm tra để trống
             * dùng id HTPP GET so sánh id vs password người dùng nhâp 
             */
           try
           {
                if (txtName.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Tên tài khoản và mật khẩu không được để trống!!");
                }
                int code = int.Parse(txtName.Text.Trim());
                WebClient Clien = new WebClient();
                String json = Clien.DownloadString(URIst + code);
                Student Students = JsonConvert.DeserializeObject<Student>(json);
                if (Students.id.ToString() == txtName.Text)
                {
                    if (Students.password == txtPass.Text)
                    {
                        MessageBox.Show("Chào mừng User đăng nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmStudent student = new frmStudent();
                        student.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác ");
                    }
                }
           }
            catch
           {

                MessageBox.Show("Tên tài khoản không chính xác");
           }
        }
        // đăng nhập giáo viên
        private void btnTeacher_Click(object sender, EventArgs e)
        {
            /*kiểm tra để trống
             * dùng id HTPP GET so sánh id vs password người dùng nhâp 
            */
            try
            {
                if (txtName.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Tên tài khoản và mật khẩu không được để trống!!");
                }
                int code = int.Parse(txtName.Text.Trim());
                WebClient Clien = new WebClient();
                String json = Clien.DownloadString(URItc + code);
                Teachers Teacher = JsonConvert.DeserializeObject<Teachers>(json);
                if (Teacher.id.ToString() == txtName.Text)
                {
                    if (Teacher.password == txtPass.Text)
                    {
                        MessageBox.Show("Chào mừng User đăng nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Teacher t = new Teacher();
                        t.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác ");
                    }
                }
            }
            catch
            {

                MessageBox.Show("Tên tài khoản không chính xác");
            }
        }
        // hiện thi nút đăng nhập sinh viên
        private void rdoStudent_Click(object sender, EventArgs e)
        {
            btnStudent.Visible = true;
            btnTeacher.Visible = false;

        }
        // hiện thi nút đăng nhập giáo viên
        private void rdoTeacher_Click(object sender, EventArgs e)
        {
            btnStudent.Visible = false;
            btnTeacher.Visible = true;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget s = new Forget();
            s.ShowDialog();
        }
    }
}
