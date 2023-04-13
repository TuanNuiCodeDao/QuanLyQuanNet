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
    public partial class F_TrangChu : Form
    {
        private string maMay;
        public F_TrangChu()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            maMay = "";
            loadCbKH();
            loadCbDichVu();
            loadDSMay();
        }
        private void loadCbKH()
        {
            cbKhachHang.Items.Clear();
            List<KhachHang> l = KhachHangDAO.Instance.loadDSTim(tbTim.Text);
            cbKhachHang.Items.Add("Khách vãn lai - 0000000000");
            foreach(KhachHang k in l)
            {
                if(k.SDT!= "0000000000")
                cbKhachHang.Items.Add(k.TenKH + " - " + k.SDT);
            }
            cbKhachHang.Text = cbKhachHang.Items[0].ToString();
        }
        private void loadCbDichVu()
        {
            cbDichVu.Items.Clear();
            List<DichVu> l = DichVuDAO.Instance.loadDS();
            foreach (DichVu i in l)
            {
                if (i.MaDV != "DV0001")
                    cbDichVu.Items.Add(i.TenDV);
            }
            if (cbDichVu.Items.Count > 0)
                cbDichVu.Text = cbDichVu.Items[0].ToString();
        }
        private void loadDSMay()
        {
            flpnMay.Controls.Clear();
            List<May> l = MayDAO.Instance.loadDSMay();
            foreach(May i in l)
            {
                Button bt = new Button() { Width = 90, Height = 90 };
                bt.Text = i.TenMay + "\n" + MayDAO.Instance.getTrangThai(i.TrangThai);
                bt.Click += bt_Click;
                bt.Tag = i.MaMay;
                if (i.TrangThai ==false)
                    bt.BackColor = Color.Aqua;
                else bt.BackColor = Color.Gold;
                flpnMay.Controls.Add(bt);
            }    
        }
        public void bt_Click(object sender, EventArgs e)
        {
            maMay = (sender as Button).Tag as string;
            showHoaDon();
        }
        private void showHoaDon()
        {
            tbThoiGianBatDau.Clear();
            tbTimeDaSD.Clear();
            tbTong.Clear();
            dgvCTHD.Rows.Clear();
            HoaDon hd = HoaDonDAO.Instance.getNowByMaMay(maMay);
            if (hd == null)
                return;
            tbThoiGianBatDau.Text = hd.ThoiGianBatDau.ToString();
            KhachHang kh = KhachHangDAO.Instance.getBySDT(hd.SDTKH);
            DichVu net = DichVuDAO.Instance.getDVTheoTen("NET");
            cbKhachHang.Text = kh.TenKH + " - " + kh.SDT;
            TimeSpan tam = DateTime.Now - hd.ThoiGianBatDau;
            tbTimeDaSD.Text = tam.Hours + tam.Days * 24 + " Giờ " + tam.Minutes + " Phút";
            float soGio = tam.Hours + tam.Days * 24 + (float)(tam.Minutes / 60.0);
            HoaDonDAO.Instance.capNhatTime(hd.MaHD,soGio);
            hd = HoaDonDAO.Instance.getByMa(hd.MaHD);
            List<ChiTietHoaDon> l=ChiTietHoaDonDAO.Instance.loadDSByMaDH(hd.MaHD);
            int stt = 0;
            foreach(ChiTietHoaDon i in l)
            {
                stt++;
                DichVu dv = DichVuDAO.Instance.getByMa(i.MaDV);
                dgvCTHD.Rows.Add(stt, dv.TenDV, dv.DonViTinh, i.SoLuong, i.DonGia, DataProvider.Instance.getDinhDanhHangNghin((int)(i.SoLuong * i.DonGia)) + " VNĐ");
            }
            tbTong.Text = DataProvider.Instance.getDinhDanhHangNghin(hd.TongTien) + " VNĐ";
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            May i = MayDAO.Instance.getByMa(maMay);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn máy cần mở trước !", "Nhắc nhở");
                return;
            }
            if (i.TrangThai == true)
            {
                MessageBox.Show("Máy hiện tại đang sử dụng !", "Nhắc nhở");
                return;
            }
            string kh = cbKhachHang.Text;
            string sdt = "";
            for (int j = kh.Length - 1; j >= 0; j--)
            {
                if (kh[j] == ' ')
                    break;
                sdt = kh[j] + sdt;
            }
            if(HoaDonDAO.Instance.getNowBySDTKH(sdt)!=null && sdt!= "0000000000")
            {
                MessageBox.Show("Khách hàng này đang sử dụng 1 máy khác !", "Nhắc nhở");
                return;
            }
            KhachHang k = KhachHangDAO.Instance.getBySDT(sdt);
            if (MessageBox.Show("Xác nhận mở máy '" + i.TenMay + "' cho khách hàng '"+k.TenKH+"'? !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDonDAO.Instance.them(new HoaDon(null,sdt, maMay, DateTime.Now,DateTime.Now,0,false));
                HoaDon hd = HoaDonDAO.Instance.getNowByMaMay(maMay);
                DataProvider.Instance.RunQuery("INSERT INTO ChiTietHoaDon(MaHD,MaDV,SoLuong,DonGia) VALUES (N'" + hd.MaHD + "',N'DV0001',0," + DichVuDAO.Instance.getByMa("DV0001").DonGia + ")");
                loadDSMay();
                showHoaDon();
                MessageBox.Show("Mở máy thành công !", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HoaDon hd = HoaDonDAO.Instance.getNowByMaMay(maMay);
            if(hd==null)
            {
                MessageBox.Show("Hãy chọn máy có hóa đơn trước !", "Nhắc nhở");
                return;
            }
            DichVu dv = DichVuDAO.Instance.getDVTheoTen(cbDichVu.Text);
            if (dv == null)
            {
                MessageBox.Show("Hãy chọn dịch vụ trước !", "Nhắc nhở");
                return;
            }
            ChiTietHoaDonDAO.Instance.them(new ChiTietHoaDon(null, hd.MaHD, dv.MaDV, dv.DonGia, (int)nudSoLuong.Value));
            showHoaDon();
        }

        private void tbTim_TextChanged(object sender, EventArgs e)
        {
            loadCbKH();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HoaDon hd = HoaDonDAO.Instance.getNowByMaMay(maMay);
            if (hd == null)
            {
                MessageBox.Show("Hãy chọn máy có hóa đơn trước !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận thanh toán háo đơn ? !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDonDAO.Instance.thanhToan(hd.MaHD);
                loadDSMay();
                showHoaDon();
                MessageBox.Show("Thanh toán thành công !", "Thông báo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HoaDon hd = HoaDonDAO.Instance.getNowByMaMay(maMay);
            if (hd == null)
            {
                MessageBox.Show("Hãy chọn máy có hóa đơn trước !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận hủy hóa đơn ? !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HoaDonDAO.Instance.xoa(hd.MaHD);
                loadDSMay();
                showHoaDon();
                MessageBox.Show("Hủy thành công !", "Thông báo");
            }
        }
    }
}
