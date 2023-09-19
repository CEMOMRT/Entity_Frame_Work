using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Frame_Work//Project fail
{
    //NuGet ekleyerek getirdiğimiz EntityNetwork ile daha kolay veri tabanı bağlantısı sağlanabilir.(Unit of Work tasarım deseni)
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Product _productDal = new Product();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = txtbName.Text,
                StockAmount = Convert.ToInt32(txtbStockAmount.Text),
                UnitPrice = Convert.ToDecimal(txtbUnitPrice.Text)
            });
            LoadProducts();
            MessageBox.Show("Added !");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name=txtbNameUpdate.Text,
                UnitPrice=Convert.ToDecimal(txtbUnitPriceUpdate.Text),
                StockAmount=Convert.ToInt32(txtbUnitPriceUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("Updated!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtbUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtbStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }
    }
}
