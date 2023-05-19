using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for EleviMedii.xaml
    /// </summary>
    public partial class EleviMedii : Window
    {
        int elevId;

        public EleviMedii()
        {
            InitializeComponent();
        }

        public EleviMedii(int elevId)
        {
            InitializeComponent();
            this.elevId = elevId;
            MedieVM medieVM = DataContext as MedieVM;
            ObservableCollection<Medie> medii = new ObservableCollection<Medie>();
            Elev elev = medieVM.elevBLL.ObtineElevDupaId(elevId);
            double sumaMedii = 0.0;
            int numarMedii = 0;
            foreach (Medie medie in medieVM.ListaMedie)
            {
                if (!medii.Contains(medie) && medie.IdElev == elev.IdElev)
                {
                    medii.Add(medie);
                    sumaMedii += (double)medie.Nota;
                    numarMedii++;
                }
            }
            gridMedii.ItemsSource = medii;
            txtMedie.Text = (sumaMedii / numarMedii).ToString();
        }
    }
}
