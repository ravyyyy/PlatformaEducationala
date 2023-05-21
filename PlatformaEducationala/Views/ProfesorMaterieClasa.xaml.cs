using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ProfesorMaterieClasa.xaml
    /// </summary>
    public partial class ProfesorMaterieClasa : Window
    {
        public ProfesorMaterieClasa()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProfesorMaterieClasaVM profesorMaterieClasaVM = DataContext as ProfesorMaterieClasaVM;
            KeyValuePair<string, int>? pair = txtMaterie.SelectedItem as KeyValuePair<string, int>?;
            if (pair is KeyValuePair<string, int> keyValue)
            {
                int id = keyValue.Value;
                Materie materieSelectata = profesorMaterieClasaVM.materieBLL.ObtineMaterieDupaId(id);
                profesorMaterieClasaVM.ObtineAnStudiuDupaClasa((int)materieSelectata.IdMaterie);
                txtAnStudiu.Text = profesorMaterieClasaVM.anStudiu.ToString();
                string itemSelectat = "";
                foreach (Clasa clasa in profesorMaterieClasaVM.clasaBLL.ObtineToateClasele())
                {
                    if (clasa.AnStudiu == materieSelectata.AnStudiu)
                    {
                        foreach (KeyValuePair<string, int> pair2 in profesorMaterieClasaVM.ListaProfesori)
                        {
                            if (pair2.Value == materieSelectata.IdProfesor)
                            {
                                itemSelectat = pair2.Key;
                                break;
                            }
                        }
                    }
                }
                txtProfesor.SelectedItem = itemSelectat;
            }
        }

        private void Actualizare_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString);
            using (con)
            {
                SqlCommand command = new SqlCommand("ActualizareMaterieDupaProfesor", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                KeyValuePair<string, int>? pair = txtMaterie.SelectedItem as KeyValuePair<string, int>?;
                int anStudiu;
                if (int.TryParse(txtAnStudiu.Text, out anStudiu))
                {
                    command.Parameters.AddWithValue("@an_studiu", anStudiu);
                    KeyValuePair<string, int>? pair2 = txtProfesor.SelectedItem as KeyValuePair<string, int>?;
                    if (pair2 is KeyValuePair<string, int> kv2)
                    {
                        command.Parameters.AddWithValue("@profesor_id", kv2.Value);
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
