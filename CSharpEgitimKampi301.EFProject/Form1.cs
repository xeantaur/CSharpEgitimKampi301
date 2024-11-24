using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.Name = txtName.Text;
            guide.Surname = txtSurname.Text;
            db.Guides.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla eklendi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var RemoveValue = db.Guides.Find(id);
            db.Guides.Remove(RemoveValue);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Guides.Find(id);
            updateValue.Name = txtName.Text;
            updateValue.Surname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guides.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
