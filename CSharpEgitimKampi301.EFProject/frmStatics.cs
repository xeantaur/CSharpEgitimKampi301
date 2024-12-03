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
    public partial class frmStatics : Form
    {
        public frmStatics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void frmStatics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Locations.Count().ToString();

            lblSumCapacity.Text = db.Locations.Sum(x=> x.Capacity).ToString();

            lblGuideCount.Text = db.Guides.Count().ToString();

            lblAvgCapacity.Text = db.Locations.Average(x=> x.Capacity).ToString();

            lblAvgPrice.Text = ((double)db.Locations.Average(x => x.price)).ToString("N0") + " ₺";

            int lastCountryId = db.Locations.Max(x => x.LocationId);
            
            lblLastCountry.Text = db.Locations.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaCapacity.Text = db.Locations.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkeyCapacityAvg.Text = db.Locations.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var romeGuideId = db.Locations.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guides.Where(x => x.GuideId == romeGuideId).Select(y => y.Name +" "+  y.Surname).FirstOrDefault();

            var maxCapacity = db.Locations.Max(x => x.Capacity);
            lblMaxCapacityTour.Text = db.Locations.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault();

            var maxPrice = db.Locations.Max(x => x.price);
            lblMaxPrice.Text = db.Locations.Where(x => x.price == maxPrice).Select(y => y.City).FirstOrDefault();

            var AysegulCinarId = db.Guides.Where(x => x.Name == "Ayşegül" && x.Surname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinar.Text = db.Locations.Where(x => x.GuideId == AysegulCinarId).Count().ToString();
            
        }
    }
}
