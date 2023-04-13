namespace QuanLyQuanNet
{
    partial class F_Chinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Chinh));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pnTong = new System.Windows.Forms.Panel();
            this.pnBody = new System.Windows.Forms.Panel();
            this.TrangChuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.qLThongTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýMayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyDichVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyKhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyHoaDonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.pnTong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrangChuToolStripMenuItem1,
            this.qLThongTinToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.thoátToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1546, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pnTong
            // 
            this.pnTong.Controls.Add(this.pnBody);
            this.pnTong.Controls.Add(this.menuStrip1);
            this.pnTong.Location = new System.Drawing.Point(1, 1);
            this.pnTong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTong.Name = "pnTong";
            this.pnTong.Size = new System.Drawing.Size(1546, 776);
            this.pnTong.TabIndex = 1;
            // 
            // pnBody
            // 
            this.pnBody.Location = new System.Drawing.Point(3, 34);
            this.pnBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1541, 740);
            this.pnBody.TabIndex = 2;
            // 
            // TrangChuToolStripMenuItem1
            // 
            this.TrangChuToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.TrangChuToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TrangChuToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangChuToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("TrangChuToolStripMenuItem1.Image")));
            this.TrangChuToolStripMenuItem1.Name = "TrangChuToolStripMenuItem1";
            this.TrangChuToolStripMenuItem1.Size = new System.Drawing.Size(140, 28);
            this.TrangChuToolStripMenuItem1.Text = "Trang chủ";
            this.TrangChuToolStripMenuItem1.Click += new System.EventHandler(this.TrangChuToolStripMenuItem1_Click);
            // 
            // qLThongTinToolStripMenuItem
            // 
            this.qLThongTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýMayToolStripMenuItem,
            this.qLyDichVuToolStripMenuItem,
            this.qLyKhachHangToolStripMenuItem,
            this.qLyHoaDonToolStripMenuItem});
            this.qLThongTinToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qLThongTinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("qLThongTinToolStripMenuItem.Image")));
            this.qLThongTinToolStripMenuItem.Name = "qLThongTinToolStripMenuItem";
            this.qLThongTinToolStripMenuItem.Size = new System.Drawing.Size(214, 28);
            this.qLThongTinToolStripMenuItem.Text = "Quản lý Thông tin";
            this.qLThongTinToolStripMenuItem.Click += new System.EventHandler(this.qLThongTinToolStripMenuItem_Click);
            // 
            // quảnLýMayToolStripMenuItem
            // 
            this.quảnLýMayToolStripMenuItem.Image = global::QuanLyQuanNet.Properties.Resources.iCoinPC;
            this.quảnLýMayToolStripMenuItem.Name = "quảnLýMayToolStripMenuItem";
            this.quảnLýMayToolStripMenuItem.Size = new System.Drawing.Size(286, 28);
            this.quảnLýMayToolStripMenuItem.Text = "Quản lý Máy";
            this.quảnLýMayToolStripMenuItem.Click += new System.EventHandler(this.quảnLýMayToolStripMenuItem_Click);
            // 
            // qLyDichVuToolStripMenuItem
            // 
            this.qLyDichVuToolStripMenuItem.Image = global::QuanLyQuanNet.Properties.Resources.cart;
            this.qLyDichVuToolStripMenuItem.Name = "qLyDichVuToolStripMenuItem";
            this.qLyDichVuToolStripMenuItem.Size = new System.Drawing.Size(286, 28);
            this.qLyDichVuToolStripMenuItem.Text = "Quản lý Dịch vụ";
            this.qLyDichVuToolStripMenuItem.Click += new System.EventHandler(this.qLyDichVuToolStripMenuItem_Click);
            // 
            // qLyKhachHangToolStripMenuItem
            // 
            this.qLyKhachHangToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("qLyKhachHangToolStripMenuItem.Image")));
            this.qLyKhachHangToolStripMenuItem.Name = "qLyKhachHangToolStripMenuItem";
            this.qLyKhachHangToolStripMenuItem.Size = new System.Drawing.Size(286, 28);
            this.qLyKhachHangToolStripMenuItem.Text = "Quản lý Khách hàng";
            this.qLyKhachHangToolStripMenuItem.Click += new System.EventHandler(this.qLyKhachHangToolStripMenuItem_Click);
            // 
            // qLyHoaDonToolStripMenuItem
            // 
            this.qLyHoaDonToolStripMenuItem.Image = global::QuanLyQuanNet.Properties.Resources.chart;
            this.qLyHoaDonToolStripMenuItem.Name = "qLyHoaDonToolStripMenuItem";
            this.qLyHoaDonToolStripMenuItem.Size = new System.Drawing.Size(286, 28);
            this.qLyHoaDonToolStripMenuItem.Text = "Quản lý Hóa đơn";
            this.qLyHoaDonToolStripMenuItem.Click += new System.EventHandler(this.qLyDonHangToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.loginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.loginToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loginToolStripMenuItem.Image")));
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(146, 28);
            this.loginToolStripMenuItem.Text = "Đăng nhập";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem1
            // 
            this.thoátToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.thoátToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.thoátToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátToolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            this.thoátToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("thoátToolStripMenuItem1.Image")));
            this.thoátToolStripMenuItem1.Name = "thoátToolStripMenuItem1";
            this.thoátToolStripMenuItem1.Size = new System.Drawing.Size(99, 28);
            this.thoátToolStripMenuItem1.Text = "Thoát";
            this.thoátToolStripMenuItem1.Click += new System.EventHandler(this.thoátToolStripMenuItem1_Click);
            // 
            // F_Chinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 779);
            this.Controls.Add(this.pnTong);
            this.Name = "F_Chinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Chinh_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnTong.ResumeLayout(false);
            this.pnTong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýMayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyHoaDonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyKhachHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem qLyDichVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLThongTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrangChuToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnTong;
        private System.Windows.Forms.Panel pnBody;
    }
}