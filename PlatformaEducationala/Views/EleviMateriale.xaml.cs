using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for EleviMateriale.xaml
    /// </summary>
    public partial class EleviMateriale : Window
    {
        int elevId;
        MaterialVM materialVM;

        public EleviMateriale()
        {
            InitializeComponent();
        }

        public EleviMateriale(int elevId)
        {
            InitializeComponent();
            this.elevId = elevId;
            materialVM = DataContext as MaterialVM;
            ObservableCollection<Material> materiale = new ObservableCollection<Material>();
            Elev elev = materialVM.elevBLL.ObtineElevDupaId(elevId);
            int anStudiu = materialVM.clasaBLL.ObtineAnStudiuDupaClasa((int)elev.IdClasa);
            ObservableCollection<Materie> materii = materialVM.materieBLL.ObtineToateMateriile();
            ObservableCollection<Materie> materiiPentruElev = new ObservableCollection<Materie>();
            foreach (Materie materie in materii)
            {
                if (materie.AnStudiu == anStudiu && !materiiPentruElev.Contains(materie))
                {
                    materiiPentruElev.Add(materie);
                }
            }
            foreach (Material material in materialVM.ListaMateriale)
            {
                foreach (Materie materie in materiiPentruElev)
                {
                    if (material.IdMaterie == materie.IdMaterie && !materiale.Contains(material))
                    {
                        materiale.Add(material);
                    }
                }
            }
            gridMateriale.ItemsSource = materiale;
        }
    }
}
