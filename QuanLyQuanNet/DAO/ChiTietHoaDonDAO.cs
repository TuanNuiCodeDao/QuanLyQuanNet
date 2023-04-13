using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;
        public static ChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null) ChiTietHoaDonDAO.instance = new ChiTietHoaDonDAO();
                return ChiTietHoaDonDAO.instance;
            }
            private set
            {
                ChiTietHoaDonDAO.instance = value;
            }
        }
        public void xoa(string maCT)
        {
            ChiTietHoaDon ct = getByMa(maCT);
            DataProvider.Instance.RunQuery("DELETE FROM ChiTietHoaDon WHERE MaCT=N'" + maCT + "'");
            HoaDonDAO.Instance.capNhatTongTien(ct.MaHD);
        }
        public ChiTietHoaDon getByMaDH_MaSP_DonGia(string maHD, string maDV, int donGia)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM ChiTietHoaDon WHERE MaHD=N'" + maHD + "' AND MaDV=N'" + maDV + "' AND DonGia=" + donGia);
            foreach (DataRow item in d.Rows)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon(item);
                return ct;
            }
            return null;
        }
        public void them(ChiTietHoaDon i)
        {
            if (i.SoLuong==0)
                return;
            ChiTietHoaDon ct_ = getByMaDH_MaSP_DonGia(i.MaHD,i.MaDV,i.DonGia);
            if (ct_ != null)
            {

                float soLuongNew = ct_.SoLuong + i.SoLuong;
                if (soLuongNew <= 0)
                    xoa(ct_.MaCT);
                    DataProvider.Instance.RunQuery("UPDATE ChiTietHoaDon SET SoLuong=" + soLuongNew + " WHERE MaCT=N'" + ct_.MaCT + "'");
            }
            else
            {
                if (i.SoLuong < 0)
                    return;
                DataProvider.Instance.RunQuery("INSERT INTO ChiTietHoaDon(MaHD,MaDV,SoLuong,DonGia) VALUES (N'" + i.MaHD + "',N'" + i.MaDV + "'," + i.SoLuong + "," + i.DonGia + ")");
            }
            HoaDonDAO.Instance.capNhatTongTien(i.MaHD);
        }
        public List<ChiTietHoaDon> loadDSByMaDH(string maHD)
        {
            List<ChiTietHoaDon> l = new List<ChiTietHoaDon>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM ChiTietHoaDon WHERE MaHD=N'" + maHD + "'");
            foreach (DataRow item in d.Rows)
            {
                ChiTietHoaDon i = new ChiTietHoaDon(item);
                l.Add(i);
            }
            return l;
        }
        public List<ChiTietHoaDon> loadDSByMaDV(string maDV)
        {
            List<ChiTietHoaDon> l = new List<ChiTietHoaDon>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM ChiTietHoaDon WHERE MaDV=N'" + maDV + "'");
            foreach (DataRow item in d.Rows)
            {
                ChiTietHoaDon i = new ChiTietHoaDon(item);
                l.Add(i);
            }
            return l;
        }
        public ChiTietHoaDon getByMa(string maCT)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM ChiTietHoaDon WHERE MaCT=N'" + maCT + "'");
            foreach (DataRow item in d.Rows)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon(item);
                return ct;
            }
            return null;
        }
        public ChiTietHoaDon getByMaHD_MaDV(string maHD,string maDV)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM ChiTietHoaDon WHERE MaDV=N'"+maDV+"' AND MaHD=N'" + maHD + "'");
            foreach (DataRow item in d.Rows)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon(item);
                return ct;
            }
            return null;
        }

    }
}
