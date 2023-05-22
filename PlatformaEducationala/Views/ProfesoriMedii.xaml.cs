using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ProfesoriMedii.xaml
    /// </summary>
    public partial class ProfesoriMedii : Window
    {
        private int profesorId;
        MedieVM medieVM;

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
                                        decimal medieNote = sumaNote / numarNote;
                                        decimal medieElev = ((medieNote * 3) + teza) / 4;
                                        int idUltimaMedie = (int)medieVM.ListaMedie[medieVM.ListaMedie.Count - 1].IdMedie + 1;
                                        Medie medie = new Medie
                                        {
                                            Nota = medieElev,
                                            IdElev = idElev,
                                            IdMedie = idUltimaMedie,
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
