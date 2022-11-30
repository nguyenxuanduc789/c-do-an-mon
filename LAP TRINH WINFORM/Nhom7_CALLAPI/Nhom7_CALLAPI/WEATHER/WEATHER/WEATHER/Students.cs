using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace WEATHER
{
    public partial class frmStudent : Form
    {
        private const String URI = "http://localhost:3000/student/";
        // ẩn background của các label
        public frmStudent()
        {
            InitializeComponent();
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor= System.Drawing.Color.Transparent;

        }
        //Check định dạng gmaill
        public bool CheckEmail(string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9]{0,250}@gmail.com$");
        }
         // đẩy dự liệu lên text box
        private void GetAll()
        {
            WebClient Clien = new WebClient();
            String json = Clien.DownloadString(URI);
            List<Student> St = JsonConvert.DeserializeObject<List<Student>>(json);
            dataGridView2.DataSource = St;         
            clear();
        }
    // form load
        private void Edit_Load(object sender, EventArgs e)
        {

            GetAll();
        }
        //hàm Clear dữ liệu trên text box
        private void clear()
        {
            txtName.Clear();
            txtad.Clear();
            txtEmail.Clear();
            txtPass.Clear();
        }
        // button Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Mã số sinh viên để tìm kiếm thông tin không được để trống");
                txtID.Focus();
            }
            else
            {
                try
                {
                  /*  tạo ra đối tưởng HTPP http request
                    HTPP GET DÙNG HÀM DownloadString
                    Parse json về List */
                    int code = int.Parse(txtID.Text.Trim());
                    WebClient Clien = new WebClient();
                    String json = Clien.DownloadString(URI + code);
                    Student Students = JsonConvert.DeserializeObject<Student>(json);
                    if (Students.password == txtPass.Text.Trim())
                    {
                        if (Students != null)
                        {
                            // lưu dữ liêu vào text box
                            txtID.Text = Students.id.ToString();
                            txtName.Text = Students.name;
                            cbmFaculty.Text = Students.faculty;
                            dateTimePicker1.Text = Students.date;
                            cbmgender.Text = Students.gender;
                            txtad.Text = Students.address;
                            txtPass.Text = Students.password;
                            txtEmail.Text = Students.email;
                            txtScore.Text = Students.score.ToString();
                            // Search hiện thị bảng 
                            dataGridView2.Visible = true;
                            dataGridView2.Rows[0].Cells["id"].Value = Students.id.ToString();
                            dataGridView2.Rows[0].Cells["name"].Value = Students.name;
                            dataGridView2.Rows[0].Cells["faculty"].Value = Students.faculty;
                            dataGridView2.Rows[0].Cells["date"].Value = Students.date;
                            dataGridView2.Rows[0].Cells["gender"].Value = Students.gender;
                            dataGridView2.Rows[0].Cells["address"].Value = Students.address;
                            dataGridView2.Rows[0].Cells["score"].Value = Students.score.ToString();
                            dataGridView2.Rows[0].Cells["email"].Value = Students.email;
                            dataGridView2.Rows[0].Cells["password"].Value = Students.password;
                        }
                    }
                    else
                    {
                        MessageBox.Show("tai khoan va mat khau khong hop le !");
                    }
                }
                catch
                {

                    MessageBox.Show("Không tìm thấy thông tin sinh viên của bạn!");
                }
            }
        }
        // button update
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // ràng buộc kiểm tra không đươc để trống
            if (txtName.Text == "" || cbmgender.Text == "" || txtad.Text == "" || txtEmail.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Thông tin thay đổi sinh viên không được để trống");
            }
            else if (!CheckEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng theo định dạng chuẩn ******@gmai.com", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else
            {
                try
                {
                    /*lưu vào text box trước khi đẩy lên API 
                     muốn đẩy dư liệu lên dùng UploadString
                     */
                    Student newSt = new Student()
                    {
                        name = txtName.Text.Trim(),
                        id = int.Parse(txtID.Text.Trim()),
                        date = dateTimePicker1.Text.Trim(),
                        gender = cbmgender.Text.Trim(),
                        address = txtad.Text.Trim(),
                        password = txtPass.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                        // ẩn không cho sv sữa 
                        faculty = cbmFaculty.Text.Trim(),
                        score = int.Parse(txtScore.Text.Trim()),
                    };
                    // từ đổi tượng qua Json
                    String data = JsonConvert.SerializeObject(newSt);
                    WebClient Clien = new WebClient();
                    Clien.Headers[HttpRequestHeader.ContentType] = "application/json";
                    String response = Clien.UploadString(URI + newSt.id, "PUT", data);
                    if (response == null)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thay đổi thông tin ");

                    }
                    else
                    { 
                        // Sữa dữ liệu thành công đẩy lên dataview
                        GetAll();
                        WebClient cl = new WebClient();
                        String js = cl.DownloadString(URI + newSt.id);
                        Student Students = JsonConvert.DeserializeObject<Student>(js);
                        if (Students != null)
                        {
                            dataGridView2.Visible = true;
                            dataGridView2.Rows[0].Cells["id"].Value = Students.id.ToString();
                            dataGridView2.Rows[0].Cells["name"].Value = Students.name;
                            dataGridView2.Rows[0].Cells["faculty"].Value = Students.faculty;
                            dataGridView2.Rows[0].Cells["date"].Value = Students.date;
                            dataGridView2.Rows[0].Cells["gender"].Value = Students.gender;
                            dataGridView2.Rows[0].Cells["address"].Value = Students.address;
                            dataGridView2.Rows[0].Cells["score"].Value = Students.score.ToString();
                            dataGridView2.Rows[0].Cells["email"].Value = Students.email;
                            dataGridView2.Rows[0].Cells["password"].Value = Students.password;
                        }
                    };
                }
                catch 
                {

                    MessageBox.Show("Không tìm thấy mã số sinh viên để thay đổi !!");
                }
            }
        }
        // thoát ra trang chủ
         private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
