using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
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
    /// Interaction logic for ProfesoriMedii.xaml
    /// </summary>
    public partial class ProfesoriMedii : Window
    {
        private int profesorId;
        MedieVM medieVM;
        private ObservableCollection<Medie> medii = new ObservableCollection<Medie>();

        public ProfesoriMedii()
        {
            InitializeComponent();
        }

        public ProfesoriMedii(int profesorId)
        {
            InitializeComponent();
            this.profesorId = profesorId;
            medieVM = DataContext as MedieVM;
            mediiDG.ItemsSource = medieVM.ListaMedie;
            Profesor profesor = medieVM.profesorBLL.ObtineProfesorDupaId(profesorId);
            medieVM.materieBLL.ObtineToateMateriileDupaProfesor(profesor);
            txtIdMaterie.ItemsSource = medieVM.GetListaIdMateriiProfesor(profesor);
        }

        private void CalculareMedieButton(object sender, RoutedEventArgs e)
        {
            if (txtIdElev.SelectedItem != null)
            {
                if (txtIdMaterie.SelectedItem != null)
                {
                    string[] parts2 = txtIdMaterie.SelectedItem.ToString().Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] parts = txtIdElev.SelectedItem.ToString().Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts2.Length > 1)
                    {
                        string lastPart2 = parts2[1].Trim();
                        if (int.TryParse(lastPart2, out int idMaterie))
                        {
                            if (parts.Length > 1)
                            {
                                string lastPart = parts[1].Trim();
                                if (int.TryParse(lastPart, out int idElev))
                                {
                                    int sumaNote = 0;
                                    int numarNote = 0;
                                    int teza = 0;
                                    foreach (Nota nota in medieVM.notaBLL.ObtineToateNotele())
                                    {
                                        if (nota.IdElev == idElev && !nota.EsteTeza && nota.IdMaterie == idMaterie)
                                        {
                                            sumaNote += nota.Valoare;
                                            numarNote++;
                                        }
                                        if (nota.IdElev == idElev && nota.EsteTeza && nota.IdMaterie == idMaterie)
                                        {
                                            teza = nota.Valoare;
                                        }
                                    }
                                    if (numarNote > 2 && teza != 0)
                                    {
                                        double medieNote = (double)sumaNote / numarNote;
                                        double medieElev = ((medieNote * 3.0) + teza) / 4.0;
                                        int idUltimaMedie = (int)medieVM.ListaMedie[medieVM.ListaMedie.Count - 1].IdMedie;
                                        Medie medie = new Medie
                                        {
                                            Nota = (decimal)medieElev,
                                            IdElev = idElev,
                                            IdMedie = idUltimaMedie + 1,
                                            IdMaterie = idMaterie
                                        };
                                        medieVM.medieBLL.InserareMedie(medie);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Elevul nu are cel putin 3 note sau nu are nota la teza.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Te rog selecteaza o materie pentru a ii calcula media.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Te rog selecteaza un elev pentru a ii calcula media.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InsertButtonClick(object sender, RoutedEventArgs e)
        {
            mediiDG.ItemsSource = medieVM.ListaMedie;
        }

        private void InsertButtonPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Command != null && button.Command.CanExecute(button.CommandParameter))
                {
                    button.Command.Execute(button.CommandParameter);
                }
            }
            InsertButtonClick(sender, e);
        }
    }
}
