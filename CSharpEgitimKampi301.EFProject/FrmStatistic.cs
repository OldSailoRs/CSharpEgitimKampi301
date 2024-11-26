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
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db=new EgitimKampiEFTravelDbEntities();
        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            #region TOPLAM LOKASYON SAYISI
            lblLocationCount.Text = db.Location.Count().ToString();
            #endregion

            #region TOPLAM KAPASİTE SAYISI
            lblTotalCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();
            #endregion

            #region TOPLAM REHBER SAYISI
            lblTotalGuide.Text=db.Guide.Count().ToString();
            #endregion

            #region HER TURUN ORTALAMA KAPASİTESİ
            lblAvgCapacity.Text=db.Location.Average(x=>x.Capacity).ToString();
            #endregion

            #region ORTALAMA TUR FİYATI
            lblAvgLocPrice.Text = ((double)db.Location.Average(x => x.Price)).ToString("N0") + " ₺";
            #endregion

            #region EKLENEN SON ÜLKE
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x=>x.LocationId==lastCountryId).Select(y=>y.Country).FirstOrDefault();
            #endregion

            #region KAPADOKYA TUR KAPASİTESİ
            lblCapadociaLocCapacity.Text=db.Location.Where(x=>x.City=="Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();
            #endregion

            #region TÜRKİYENİN ORTALAMA TUR KAPASİTESİ
            lblTurkeyCapacityAvg.Text=db.Location.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();
            #endregion

            #region ROMA GEZİSİNİN REHBERİNİN İSMİ
            var romeGuideId=db.Location.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            #endregion

            #region EN YÜKSEK KAPASİTELİ TUR
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityTour.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();
            #endregion

            #region EN PAHALI TUR
            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceTour.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();
            #endregion

            #region BAHADIR DEĞİRMENCİ'NİN TUR SAYISI
            var guideIdByNameBahadir=db.Guide.Where(x=>x.GuideName=="Bahadır" && x.GuideSurname=="DEĞİRMENCİ").Select(y=>y.GuideId).FirstOrDefault();
            lblBahadirTourCount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameBahadir).Count().ToString();
            #endregion
        }
    }
}
