using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;

namespace WEATHER
{
    public partial class frmRegister : Form
    {
        private const String URI = "http://localhost:3000/Teacher/";
       // ẩn background của các label
        public frmRegister()
        {
            InitializeComponent();
            panel1.BackColor =  System.Drawing.Color.Transparent;
            
        }
        // hàm clear
        private void clear()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPass.Clear();
        }
        // ràng buộc về kí tự yêu cầu nhập đúng đinh dạng mới được đăng kí 
        public bool CheckName (string q)
        {
            return Regex.IsMatch(q, "^[a-zA-Z]{0,2500}$");
        }
        public bool CheckEmail (string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9]{0,250}@gmail.com$");
        }
        public bool CheckPass (string pass)
        {
            return Regex.IsMatch(pass, "^[a-zA-Z0-9]{6,250}$");
        }
        // ràng buộc người dùng ko được để trống khi đăng kí tài khoản
        public bool KiemTraThongTin()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            if (cbmPosition.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chức vụ của mình ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbmPosition.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên email ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass.Focus();
                return false;
            }
            if (txtReturn.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thêm lại mật khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReturn.Focus();
                return false;
            }
            if (txtReturn.Text != txtPass.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReturn.Focus();
                return false;
            }
            if (!CheckName(txtName.Text))
            {
                MessageBox.Show("Họ và tên không được chứa các kí tự đặc biệt và kí tự chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            if (!CheckEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng theo định dạng chuẩn ******@gmai.com", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            if(!CheckPass(txtPass.Text))
            {
                MessageBox.Show("Mật khẩu tối thiểu 6 kí tự và không được quá 250 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass.Focus();
                return false;
            }
            return true;
        }
        // btn thêm tài khoản mới
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                Teachers newteacher = new Teachers()
                {
                    name = txtName.Text.Trim(),
                    id = 0,
                    position = cbmPosition.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    password = txtPass.Text.Trim(),
                };
                String data = JsonConvert.SerializeObject(newteacher);
                WebClient Clien = new WebClient();
                Clien.Headers[HttpRequestHeader.ContentType] = "application/json";
                String response = Clien.UploadString(URI, "POST", data);
                Teachers teacher = JsonConvert.DeserializeObject<Teachers>(response);
                if (response == null)
                {
                    MessageBox.Show("Dự liệu không tồn tại");

                }
                else clear();
                {
                    MessageBox.Show("Tài khoản của bạn là : " + teacher.id.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // btn check người dùng đã dùng gmail này đki trên API chưa nếu chưa thì cho đăng kí 
        private void btnCheck_Click(object sender, EventArgs e)
        {
            /*
             * người dùng nhâp dữ liệu lên text box trước khi check
             * khi báo i là MSGV đầu tiên ràng buộc id chỉ dới hạng 20 gv đăng kí 
             * dự HTPP GET  (DownloadString) parse string thành json để kiểm tra 
             * */
            try
            {
                Teachers newteacher = new Teachers()
                {
                    name = txtName.Text.Trim(),
                    id = 20020,
                    position = cbmPosition.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    password = txtPass.Text.Trim(),
                };
                int i = 20001;
                for (i = 20001; i < newteacher.id; i++)
                {
                    WebClient cl = new WebClient();
                    String json = cl.DownloadString(URI + i);
                    Teachers Teacher = JsonConvert.DeserializeObject<Teachers>(json);
                    if (Teacher.email == newteacher.email)
                    {
                        MessageBox.Show("Email nay da dang ki tai khoan ! vui long nhap lai");
                        break;
                    }
                }
            } 
            // nếu kiểm tra không thành công thì hiện nút signup cho người dùng đăng kí mới 
            catch
            {
                if (KiemTraThongTin())
                {
                    btnSignUp.Visible = true;
                }
            }
        }
        // btn thoát
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
 }

