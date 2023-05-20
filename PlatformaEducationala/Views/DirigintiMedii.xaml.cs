using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiMedii.xaml
    /// </summary>
    public partial class DirigintiMedii : Window
    {
        int diriginteId;
        int elevId;

        public DirigintiMedii()
        {
            InitializeComponent();
        }

        public DirigintiMedii(int diriginteId, int elevId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            this.elevId = elevId;
            double medieFinala = 0.0;
            ObservableCollection<Medie> medii = new ObservableCollection<Medie>();
            MedieVM medieVM = DataContext as MedieVM;
            foreach (Medie medie in medieVM.ListaMedie)
            {
                if (!medii.Contains(medie) && medie.IdElev == elevId)
                {
                    medii.Add(medie);
                }
            }
            foreach (Medie medie in medii)
            {
                medieFinala += medie.Nota;
            }
            txtMedieGenerala.Text = (medieFinala / medii.Count - 1).ToString();
        }
    }
}
