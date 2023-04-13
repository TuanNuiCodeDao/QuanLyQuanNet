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
    public partial class F_QLHoaDon : Form
    {
        private bool check;
        public F_QLHoaDon()
        {
            InitializeComponent();
            check = false;
            load();
            check = true;
            loadDS();
        }
        private void load()
        {
            loadCbKhachHang();
            loadCbTime();
        }
        private void loadCbKhachHang()
        {
            List<KhachHang> l = KhachHangDAO.Instance.loadDS();
            cbKhachHang.Items.Clear();
            cbKhachHang.Items.Add("Tất cả");
            foreach (KhachHang i in l)
            {
                cbKhachHang.Items.Add(i.TenKH + " - " + i.SDT);
            }
            cbKhachHang.Text = "Tất cả";
        }
        private void loadCbTime()
        {
            cbTime.Items.Clear();
            cbTime.Items.Add("Tất cả");
            cbTime.Items.Add("Từ " + dateDuoi.Text + " đến " + dateTren.Text);
            cbTime.Text = "Từ " + dateDuoi.Text + " đến " + dateTren.Text;
        }
        private void loadDS()
        {
            if (check == false)
                return;
            string s = "";
            if (cbKhachHang.Text != "Tất cả")
            {
                string kh = cbKhachHang.Text;
                    string sdt = "";
                    for (int i = kh.Length - 1; i >= 0; i--)
                    {
                        if (kh[i] == ' ')
                            break;
                        sdt = kh[i] + sdt;
                    }
                    s += " HoaDon.SDTKH=N'" + sdt + "'";
            }
            if (cbTime.Text != "Tất cả")
            {
                if (string.IsNullOrEmpty(s) == false)
                    s += " AND ";
                s += " HoaDon.ThoiGianBatDau>='" + (DateTime)dateDuoi.Value + "'" +
                    " AND HoaDon.ThoiGianBatDau<='" + (DateTime)dateTren.Value + "'";
            }
            if (string.IsNullOrEmpty(s) == false)
                s = "WHERE " + s;
            dgvHoaDon.Rows.Clear();
            tbMaDH.Text = "";
            int stt = 0;
            List<HoaDon> l = HoaDonDAO.Instance.loaDSbyDieuKien(s);
            int tongHD = 0, tongGiamGia=0;
            foreach (HoaDon i in l)
            {
                stt++;
                KhachHang kh = KhachHangDAO.Instance.getBySDT(i.SDTKH);
                string ut= "";
                if(i.TrangThai==false)
                    ut = "Chưa";
                else
                    ut = i.ThoiGianKetThuc.ToString("dd/MM/yyyy HH:mm");
                dgvHoaDon.Rows.Add(stt,i.MaHD,kh.SDT,kh.TenKH, i.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm"),ut,
                    DataProvider.Instance.getDinhDanhHangNghin(i.TongTien) + " VNĐ", HoaDonDAO.Instance.getTrangThai(i.TrangThai));
                tongHD += i.TongTien;
            }
            tbSoDon.Text = l.Count + "";
            tbTongHoaDon.Text = DataProvider.Instance.getDinhDanhHangNghin(tongHD)+" VNĐ";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            HoaDon hd = HoaDonDAO.Instance.getByMa(tbMaDH.Text);
            if (hd == null)
            {
                MessageBox.Show("Hãy chọn hóa đơn cần xóa trước !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa đơn hàng " + hd.MaHD + " ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDonDAO.Instance.xoa(hd.MaHD);
                loadDS();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            HoaDon hd = HoaDonDAO.Instance.getByMa(tbMaDH.Text);
            if (hd == null)
            {
                MessageBox.Show("Hãy chọn hóa đơn xem chi tiết trước !", "Nhắc nhở");
                return;
            }
            F_Bill f = new F_Bill(hd.MaHD);
            f.ShowDialog();
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = new DataGridViewRow();
                row = dgvHoaDon.Rows[e.RowIndex];
                tbMaDH.Text = Convert.ToString(row.Cells[1].Value);
            }
            catch (Exception)
            { }
        }

        private void dateDuoi_ValueChanged(object sender, EventArgs e)
        {
            loadCbTime();
            loadDS();
        }

        private void dateTren_ValueChanged(object sender, EventArgs e)
        {
            loadCbTime();
            loadDS();
        }

        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void cbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
