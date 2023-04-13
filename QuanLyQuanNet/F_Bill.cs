using QuanLyQuanNet.DAO;
using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet
{
    public partial class F_Bill : Form
    {
        public F_Bill(string maHD)
        {
            InitializeComponent();
            showThongTin(maHD);
        }
        private void showThongTin(string maHD)
        {
            HoaDon hd = HoaDonDAO.Instance.getByMa(maHD);
            KhachHang kh = KhachHangDAO.Instance.getBySDT(hd.SDTKH);
            lbSDTKH.Text = kh.SDT;
            lbTenKH.Text = kh.TenKH;
            lbTimeIn.Text = hd.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
            if (hd.TrangThai == false)
                lbTimeOut.Text = "Chưa";
            else
                lbTimeOut.Text = hd.ThoiGianKetThuc.ToString("dd/MM/yyyy HH:mm");
            lbTrangThai.Text = HoaDonDAO.Instance.getTrangThai(hd.TrangThai);
            lbMaDH.Text = hd.MaHD;
            lbTongHoaDon.Text = DataProvider.Instance.getDinhDanhHangNghin(hd.TongTien) + " VNĐ";
            dgvCTHD.Rows.Clear();
            int stt = 0;
            List<ChiTietHoaDon> l = ChiTietHoaDonDAO.Instance.loadDSByMaDH(hd.MaHD);
            foreach (ChiTietHoaDon i in l)
            {
                DataGridViewRow row = (DataGridViewRow)dgvCTHD.Rows[0].Clone();
                stt++;
                row.Cells[0].Value = stt + "";
                DichVu dv = DichVuDAO.Instance.getByMa(i.MaDV);
                row.Cells[1].Value = dv.TenDV;
                row.Cells[2].Value = dv.DonViTinh;
                row.Cells[3].Value = i.SoLuong;
                row.Cells[4].Value = i.DonGia;
                row.Cells[5].Value = DataProvider.Instance.getDinhDanhHangNghin((int)(i.DonGia * i.SoLuong)) + " VNĐ";
                dgvCTHD.Rows.Add(row);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void F_Bill_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
