using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for EleviAbsente.xaml
    /// </summary>
    public partial class EleviAbsente : Window
    {
        int elevId;

        public EleviAbsente()
        {
            InitializeComponent();
        }

        public EleviAbsente(int elevId)
        {
            InitializeComponent();
            this.elevId = elevId;
            AbsentaVM absentaVM = DataContext as AbsentaVM;
            ObservableCollection<Absenta> absente = new ObservableCollection<Absenta>();
            Elev elev = absentaVM.elevBLL.ObtineElevDupaId(elevId);
            foreach (Absenta absenta in absentaVM.ListaAbsente)
            {
                if (!absente.Contains(absenta) && absenta.IdElev == elev.IdElev)
                {
                    absente.Add(absenta);
                }
            }
            gridAbsente.ItemsSource = absente;
        }
    }
}
