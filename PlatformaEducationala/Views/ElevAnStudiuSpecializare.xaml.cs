using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            KeyValuePair<string, int>? pair = txtElev.SelectedItem as KeyValuePair<string, int>?;
            if (pair is KeyValuePair<string, int> keyValue)
            {
                int id = keyValue.Value;
                Elev elevSelectat = elevAnStudiuSpecializareVM.elevBLL.ObtineElevDupaId(id);
                elevAnStudiuSpecializareVM.ObtineAnStudiuDupaClasa((int)elevSelectat.IdClasa);
                txtAnStudiu.Text = elevAnStudiuSpecializareVM.anStudiu.ToString();
                txtSpecializare.ItemsSource = elevAnStudiuSpecializareVM.ObtineToateDenumirileSpecializarilor(elevAnStudiuSpecializareVM.specializareBLL.ObtineToateSpecializarile());
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
        }

        private void Actualizare_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString);
            using (con)
            {
                SqlCommand command = new SqlCommand("ActualizareSpecializareSiAnStudiuDupaElev", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                KeyValuePair<string, int>? pair = txtElev.SelectedItem as KeyValuePair<string, int>?;
                if (pair is KeyValuePair<string, int> kv)
                {
                    command.Parameters.AddWithValue("@elev_id", kv.Value);
                    int anStudiu;
                    if (int.TryParse(txtAnStudiu.Text, out anStudiu))
                    {
                        command.Parameters.AddWithValue("@studiu_an", anStudiu);
                        command.Parameters.AddWithValue("@denumire_specializare", txtSpecializare.SelectedItem.ToString());
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
