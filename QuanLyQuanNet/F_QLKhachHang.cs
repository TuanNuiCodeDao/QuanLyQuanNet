using QuanLyQuanNet.DAO;
using QuanLyQuanNet.DTO;
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
    public partial class F_QLKhachHang : Form
    {
        public F_QLKhachHang()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvKhachHang.Rows.Clear();
            int stt = 0;
            List<KhachHang> l = KhachHangDAO.Instance.loadDS();
            foreach (KhachHang i in l)
            {
                stt++;
                dgvKhachHang.Rows.Add(stt,i.SDT,i.TenKH,i.DiaChi);
            }
            tbSoLuong.Text = l.Count + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataProvider.Instance.checkSDT(tbSDT.Text) == false)
            {
                MessageBox.Show("SĐT phải là chuỗi 9->12 ký tự số !", "Nhắc nhở");
                return;
            }
            if (KhachHangDAO.Instance.getBySDT(tbSDT.Text) != null)
            {
                MessageBox.Show("SĐT đã được khách hàng khác sử dụng !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống !", "Nhắc nhở");
                return;
            }
            KhachHangDAO.Instance.them(new KhachHang(tbSDT.Text, tbHoTen.Text, tbDiaChi.Text));
            loadDS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KhachHang kh = KhachHangDAO.Instance.getBySDT(tbSDT.Text);
            if (kh==null)
            {
                MessageBox.Show("Hãy chọn khách hàng cần xóa trước !", "Nhắc nhở");
                return;
            }
            if (kh.SDT=="0000000000")
            {
                MessageBox.Show("Không thể xóa khách hàng mặc định !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa khách hàng " + kh.TenKH + " ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                KhachHangDAO.Instance.xoa(kh.SDT);
                loadDS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachHang kh = KhachHangDAO.Instance.getBySDT(tbSDT.Text);
            if (kh == null)
            {
                MessageBox.Show("Hãy chọn khách hàng cần sửa trước !", "Nhắc nhở");
                return;
            }
            if (kh.SDT == "0000000000")
            {
                MessageBox.Show("Không thể sửa khách hàng mặc định !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống !", "Nhắc nhở");
                return;
            }
            KhachHangDAO.Instance.sua(new KhachHang(tbSDT.Text, tbHoTen.Text, tbDiaChi.Text));
            loadDS();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvKhachHang.Rows[e.RowIndex];
                tbSDT.Text = Convert.ToString(row.Cells[1].Value);
                KhachHang i = KhachHangDAO.Instance.getBySDT(tbSDT.Text);
                if (i==null)    
                    return;
                tbHoTen.Text = i.TenKH;
                tbDiaChi.Text = i.DiaChi;
            }
            catch (Exception)
            { }
        }

        private void F_QLKhachHang_Load(object sender, EventArgs e)
        {

        }
        private void loadTim()
        {
            dgvKhachHang.Rows.Clear();
            int stt = 0;
            List<KhachHang> l = KhachHangDAO.Instance.loadDSTim(tbTim.Text);
            foreach (KhachHang i in l)
            {
                stt++;
                dgvKhachHang.Rows.Add(stt, i.SDT, i.TenKH, i.DiaChi);
            }
            tbSoLuong.Text = l.Count + "";
        }    

        private void tbTim_TextChanged(object sender, EventArgs e)
        {
            loadTim();
        }
    }
}
