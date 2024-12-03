using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class frmLocation : Form
    {
        public frmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities(); 
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Locations.ToList();
            dataGridView1.DataSource = values;

        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guides.Select(x => new
            {
                FullName = x.Name + " " + x.Surname,
                x.GuideId
            }).ToList();

            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text; 
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Locations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.Locations.Find(id);
            db.Locations.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Silme Başarılı");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Locations.Find(id);
            updateValue.City = txtCity.Text;
            updateValue.Country = txtCountry.Text;
            updateValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updateValue.price = decimal.Parse(txtPrice.Text);
            updateValue.DayNight= txtDayNight.Text;
            updateValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı");
        }
    }
}
