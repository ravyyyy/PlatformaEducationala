using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiSituatieExmatriculare.xaml
    /// </summary>
    public partial class DirigintiSituatieExmatriculare : Window
    {
        int diriginteId;

        public DirigintiSituatieExmatriculare()
        {
            InitializeComponent();
        }

        public DirigintiSituatieExmatriculare(int diriginteId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            ClasaVM clasaVM = DataContext as ClasaVM;
            Clasa clasa = new Clasa();
            foreach (Clasa clasaAux in clasaVM.ListaClase)
            {
                if (clasaAux.IdDiriginte == diriginteId)
                {
                    clasa = clasaAux;
                    break;
                }
            }
            ObservableCollection<Elev> elevi = new ObservableCollection<Elev>();
            foreach (Elev elev in clasaVM.elevBLL.ObtineTotiElevii())
            {
                if (elev.IdClasa == clasa.IdClasa && !elevi.Contains(elev))
                {
                    elevi.Add(elev);
                }
            }
            ObservableCollection<Absenta> absente = new ObservableCollection<Absenta>();
            foreach (Absenta absenta in clasaVM.absentaBLL.ObtineToateAbsentele())
            {
                if (!absente.Contains(absenta) && !absenta.EsteMotivata)
                {
                    absente.Add(absenta);
                }
            }
            foreach (Elev elev in elevi)
            {
                int numarAbsente = 0;
                foreach (Absenta absenta in absente)
                {
                    if (absenta.IdElev == elev.IdElev)
                    {
                        numarAbsente++;
                    }
                }
                if (numarAbsente > 9)
                {
                    txtSituatieExmatriculare.Text += elev.Nume + '\n';
                }
            }
        }
    }
}
