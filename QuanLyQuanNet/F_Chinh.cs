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
    public partial class F_Chinh : Form
    {
        private Form formCon;
        public F_Chinh()
        {
            InitializeComponent();
            setLogOut();
        }
        private void setLogOut()
        {
            logoutToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Text = "Đăng nhập";
            TrangChuToolStripMenuItem1.Enabled = false;
            qLThongTinToolStripMenuItem.Enabled = false;
            if (formCon != null)
                formCon.Close();
        }
        private void OpenChildForm(Form childForm)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            formCon = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void setLogIn()
        {
            logoutToolStripMenuItem.Enabled = true;
            loginToolStripMenuItem.Text = "Tài khoản";
            TrangChuToolStripMenuItem1.Enabled = true;
            qLThongTinToolStripMenuItem.Enabled = true;

        }
        private void runTrangChu()
        {
            OpenChildForm(new F_TrangChu());
        }
        private void TrangChuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            runTrangChu();
        }

        private void qLThongTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýMayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLMay());
        }

        private void qLyDichVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLDichVu());
        }

        private void qLyDonHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLHoaDon());
        }

        private void accountToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginToolStripMenuItem.Text == "Đăng nhập")
            {
                F_DangNhap f = new F_DangNhap();
                f.ShowDialog();
                if (f.Check==true)
                {
                    setLogIn();
                    pnBody.Show();
                    runTrangChu();
                }
            }
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Chinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát chương trình ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void qLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLKhachHang());
        }
    }
}
