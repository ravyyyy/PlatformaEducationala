using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ElevAnStudiuSpecializare.xaml
    /// </summary>
    public partial class ElevAnStudiuSpecializare : Window
    {
        public ElevAnStudiuSpecializare()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ElevAnStudiuSpecializareVM elevAnStudiuSpecializareVM = this.DataContext as ElevAnStudiuSpecializareVM;
            Elev elevSelectat = elevAnStudiuSpecializareVM.elevBLL.ObtineElevDupaId((int)txtElev.SelectedItem);
            elevAnStudiuSpecializareVM.ObtineAnStudiuDupaClasa((int)elevSelectat.IdClasa);
            txtAnStudiu.Text = elevAnStudiuSpecializareVM.anStudiu.ToString();
            txtSpecializare.ItemsSource =  elevAnStudiuSpecializareVM.ObtineToateDenumirileSpecializarilor(elevAnStudiuSpecializareVM.specializareBLL.ObtineToateSpecializarile());
            string itemSelectat = "";
            foreach (Clasa clasa in elevAnStudiuSpecializareVM.clasaBLL.ObtineToateClasele())
            {
                if (clasa.IdClasa == elevSelectat.IdClasa)
                {
                    foreach (Specializare specializare in elevAnStudiuSpecializareVM.specializareBLL.ObtineToateSpecializarile())
                    {
                        if (specializare.IdSpecializare == clasa.IdSpecializare)
                        {
                            itemSelectat = specializare.Denumire;
                            break;
                        }
                    }
                }
            }
            txtSpecializare.SelectedItem = itemSelectat;
        }

        private void Actualizare_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
