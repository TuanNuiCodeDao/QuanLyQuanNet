using QuanLyQuanNet.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet
{
    public partial class F_DangNhap : Form
    {
        private bool check;

        public bool Check { get => check; set => check = value; }

        public F_DangNhap()
        {
            InitializeComponent();
            Check = false;
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            if (btShow.Text == "Hiện")
            {
                tbMatKhau.UseSystemPasswordChar = false;
                btShow.Text = "Ẩn";
            }
            else
            {
                tbMatKhau.UseSystemPasswordChar = true;
                btShow.Text = "Hiện";
            }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (DangNhapDAO.Instance.Check(tbTaiKhoan.Text,tbMatKhau.Text)==true)
            {
                Check = true;
                MessageBox.Show("Đăng nhập thành công ", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !", "Nhắc nhở");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
