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
    public partial class F_QLDichVu : Form
    {
        public F_QLDichVu()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvDichVu.Rows.Clear();
            int stt = 0;
            List<DichVu> l = DichVuDAO.Instance.loadDS();
            foreach (DichVu i in l)
            {
                stt++;
                dgvDichVu.Rows.Add(stt, i.MaDV, i.TenDV, i.DonViTinh, i.DonGia);
            }
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống !", "Nhắc nhở");
                return;
            }
            if (DichVuDAO.Instance.getDVTheoTen(tbTen.Text) != null)
            {
                MessageBox.Show("Tên dịch vụ đã được sử dụng !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbDonViTinh.Text))
            {
                MessageBox.Show("Đơn vị tính không được để trống !", "Nhắc nhở");
                return;
            }
            DichVuDAO.Instance.themDichVu(new DichVu(null, tbTen.Text, tbDonViTinh.Text, (int)nudDonGia.Value));
            loadDS();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DichVu i = DichVuDAO.Instance.getByMa(tbMa.Text);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn dịch vụ cần xóa trước !", "Nhắc nhở");
                return;
            }
            if (i.MaDV == "DV0001")
            {
                MessageBox.Show("Không thể xóa dịch vụ mặc định !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa dịch vụ '" + i.TenDV + "' ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                DichVuDAO.Instance.xoa(i.MaDV);
                loadDS();
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            DichVu i = DichVuDAO.Instance.getByMa(tbMa.Text);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn dịch vụ cần cập nhật trước !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbDonViTinh.Text))
            {
                MessageBox.Show("Đơn vị tính không được để trống !", "Nhắc nhở");
                return;
            }
            DichVu i_ = DichVuDAO.Instance.getDVTheoTen(tbTen.Text);
            if (i_ != null && i_.MaDV != i.MaDV)
            {
                MessageBox.Show("Tên dịch vụ đã được dịch vụ khác sử dụng !", "Nhắc nhở");
                return;
            }
            if (i.MaDV == "DV0001")
                i = new DichVu(i.MaDV, i.TenDV, i.DonViTinh, (int)nudDonGia.Value);
            else
                i = new DichVu(i.MaDV, tbTen.Text, tbDonViTinh.Text, (int)nudDonGia.Value);
            DichVuDAO.Instance.sua(i);
            loadDS();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbMa.Text = dgvDichVu.Rows[e.RowIndex].Cells[1].Value.ToString();
                DichVu i = DichVuDAO.Instance.getByMa(tbMa.Text);
                if (i == null)
                    return;
                tbDonViTinh.Text = i.DonViTinh;
                tbTen.Text = i.TenDV;
                nudDonGia.Value = i.DonGia;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
