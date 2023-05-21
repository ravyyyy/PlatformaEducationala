using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ClasaSpecializareMaterie.xaml
    /// </summary>
    public partial class ClasaSpecializareMaterie : Window
    {
        public ClasaSpecializareMaterie()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ClasaSpecializareMaterieVM clasaSpecializareMaterieVM = DataContext as ClasaSpecializareMaterieVM;
            KeyValuePair<string, int>? pair = txtMaterie.SelectedItem as KeyValuePair<string, int>?;
            if (pair is KeyValuePair<string, int> keyValue)
            {
                int id = keyValue.Value;
                Materie materieSelectata = clasaSpecializareMaterieVM.materieBLL.ObtineMaterieDupaId(id);
                clasaSpecializareMaterieVM.ObtineAnStudiuDupaClasa((int)materieSelectata.IdMaterie);
                txtAnStudiu.Text = clasaSpecializareMaterieVM.anStudiu.ToString();
                txtSpecializare.ItemsSource = clasaSpecializareMaterieVM.ObtineToateDenumirileSpecializarilor(clasaSpecializareMaterieVM.specializareBLL.ObtineToateSpecializarile());
                string itemSelectat = "";
                foreach (Clasa clasa in clasaSpecializareMaterieVM.clasaBLL.ObtineToateClasele())
                {
                    if (clasa.AnStudiu == materieSelectata.AnStudiu)
                    {
                        foreach (Specializare specializare in clasaSpecializareMaterieVM.specializareBLL.ObtineToateSpecializarile())
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
                SqlCommand command = new SqlCommand("ActualizareAnStudiuDupaMaterie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                KeyValuePair<string, int>? pair = txtMaterie.SelectedItem as KeyValuePair<string, int>?;
                if (pair is KeyValuePair<string, int> kv)
                {
                    command.Parameters.AddWithValue("@materie_id", kv.Value);
                    int anStudiu;
                    if (int.TryParse(txtAnStudiu.Text, out anStudiu))
                    {
                        command.Parameters.AddWithValue("@studiu_an", anStudiu);
                        KeyValuePair<string, int>? pair2 = txtSpecializare.SelectedItem as KeyValuePair<string, int>?;
                        if (pair2 is KeyValuePair<string, int> kv2)
                        {
                            command.Parameters.AddWithValue("@specializare_id", kv2.Value);
                            con.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
