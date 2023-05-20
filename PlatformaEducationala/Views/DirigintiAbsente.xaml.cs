using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiAbsente.xaml
    /// </summary>
    public partial class DirigintiAbsente : Window
    {
        int diriginteId;
        int elevId;
        int materieId;

        public DirigintiAbsente()
        {
            InitializeComponent();
        }

        public DirigintiAbsente(int diriginteId, int elevId, int materieId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            this.elevId = elevId;
            this.materieId = materieId;
            AbsentaVM absentaVM = DataContext as AbsentaVM;
            ObservableCollection<Absenta> absente = new ObservableCollection<Absenta>();
            foreach (Absenta absenta in absentaVM.ListaAbsente)
            {
                if (absenta.IdMaterie == materieId && absenta.IdElev == elevId && !absente.Contains(absenta))
                {
                    absente.Add(absenta);
                }
            }
            gridAbsente.ItemsSource = absente;
        }
    }
}
