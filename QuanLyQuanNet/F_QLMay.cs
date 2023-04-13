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
    public partial class F_QLMay : Form
    {
        public F_QLMay()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvMay.Rows.Clear();
            int stt = 0;
            List<May> l = MayDAO.Instance.loadDSMay();
            foreach (May i in l)
            {
                stt++;
                dgvMay.Rows.Add(stt, i.MaMay, i.TenMay, MayDAO.Instance.getTrangThai(i.TrangThai));
            }
        }



        private void btThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên máy không được để trống !", "Nhắc nhở");
                return;
            }
            if (MayDAO.Instance.GetMayByTen(tbTen.Text) != null)
            {
                MessageBox.Show("Tên máy đã được máy khác sử dụng !", "Nhắc nhở");
                return;
            }
            MayDAO.Instance.themMay(tbTen.Text);
            loadDS();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            May i = MayDAO.Instance.getByMa(tbMa.Text);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn máy cần xóa trước !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa máy '" + i.TenMay + "' ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                MayDAO.Instance.xoa(i.MaMay);
                loadDS();
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            May i = MayDAO.Instance.getByMa(tbMa.Text);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn máy cần cập nhật trước !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên máy không được để trống !", "Nhắc nhở");
                return;
            }
            May i_ = MayDAO.Instance.GetMayByTen(tbTen.Text);
            if (i_ != null && i_.MaMay != i.MaMay)
            {
                MessageBox.Show("Tên máy đã được máy khác sử dụng !", "Nhắc nhở");
                return;
            }
            MayDAO.Instance.SuaMay(i.MaMay, tbTen.Text);
            loadDS();
        }

        private void dgvMay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvMay.Rows[e.RowIndex];
                tbMa.Text = Convert.ToString(row.Cells[1].Value);
                May i = MayDAO.Instance.getByMa(tbMa.Text);
                if (i == null)
                    return;
                tbTen.Text = i.TenMay;
                tbTrangThai.Text = MayDAO.Instance.getTrangThai(i.TrangThai);
            }
            catch (Exception)
            { }
        }
    }
}
