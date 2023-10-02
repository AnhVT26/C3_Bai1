using C3_Bai1.Controller.Services;
using C3_Bai1.Model.Context.DomainClass;

namespace C3_Bai1
{
    public partial class Form1 : Form
    {
        XeMayService _service;
        Guid _id;
        public Form1()
        {
            InitializeComponent();
            _service = new XeMayService();
            LoadComboBox();
            LoadGrid(null);
        }
        public void LoadComboBox()
        {
            for (int i = 1; i <= 1000; i++)
            {
                cmbSoLuong.Items.Add(i);
            }
        }
        public void LoadGrid(string input)
        {
            int stt = 1;
            dtgXeMay.ColumnCount = 5;
            dtgXeMay.Columns[0].Name = "ID";
            dtgXeMay.Columns[1].Name = "STT";
            dtgXeMay.Columns[2].Name = "Tên xe";
            dtgXeMay.Columns[3].Name = "Mô tả";
            dtgXeMay.Columns[4].Name = "Số lượng";
            dtgXeMay.Rows.Clear();
            foreach (var item in _service.GetXeMays(input))
            {
                dtgXeMay.Rows.Add(item.Id, stt++, item.Ten, item.Mota, item.SoLuong);
            }
        }


        private void btnHienThi_Click(object sender, EventArgs e)
        {
            //dtgXeMay.DataSource = _service.GetAllXe();
        }

        private void dtgXeMay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                _id = Guid.Parse(dtgXeMay.Rows[rowIndex].Cells[0].Value.ToString());
                var obj = _service.GetXeMays(null).FirstOrDefault(x => x.Id == _id);
                txtTen.Text = obj.Ten;
                txtMoTa.Text = obj.Mota;
                txtGiaNhap.Text = obj.GiaNhap.ToString();
                cmbSoLuong.SelectedItem = obj.SoLuong;
            }

        }

        public bool CheckTextBox()
        {
            if (string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtMoTa.Text) || string.IsNullOrEmpty(txtGiaNhap.Text))
            {
                MessageBox.Show("Các trường ko được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckTextBox())
            {
                return;
            }
            XeMay obj = new XeMay();
            obj.Ten = txtTen.Text;
            obj.Mota = txtMoTa.Text;
            obj.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text);
            obj.SoLuong = Convert.ToInt32(cmbSoLuong.SelectedItem);
            _service.ThemXeMay(obj);
            LoadGrid(null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _service.XoaXeMay(_id);
            LoadGrid(null);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadGrid(txtTimKiem.Text);
        }

        private void btnXoaForm_Click(object sender, EventArgs e)
        {
            txtTen.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            cmbSoLuong.SelectedIndex = 5;
            txtTimKiem.Text = string.Empty;
        }
    }
}


