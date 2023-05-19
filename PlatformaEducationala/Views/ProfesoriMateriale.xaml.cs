using Microsoft.Win32;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ProfesoriMateriale.xaml
    /// </summary>
    public partial class ProfesoriMateriale : Window
    {
        private int profesorId;
        MaterialVM materialVM;
        private ObservableCollection<Material> materiale = new ObservableCollection<Material>();

        public ProfesoriMateriale()
        {
            InitializeComponent();
        }

        public ProfesoriMateriale(int profesorId)
        {
            InitializeComponent();
            this.profesorId = profesorId;
            materialVM = DataContext as MaterialVM;
            materiale = materialVM.GetListaMaterialeProfesori(profesorId);
            gridMateriale.ItemsSource = materiale;
            Profesor profesor = materialVM.profesorBLL.ObtineProfesorDupaId(profesorId);
            materialVM.materieBLL.ObtineToateMateriileDupaProfesor(profesor);
            ObservableCollection<KeyValuePair<string, int>> materii = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Materie materie in materialVM.materieBLL.ListaMaterii)
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(materie.Nume, (int)materie.IdMaterie);
                if (!materii.Contains(pair))
                {
                    materii.Add(pair);
                }
            }
            txtIdMaterie.ItemsSource = materii;
        }

        private void IncarcaFisier_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Filter = "txt files (*.txt)|*txt|All files (*.*)|*.*";
            ofd.DefaultExt = ".txt";
            if (ofd.ShowDialog() == true)
            {
                string filePath = ofd.FileName;
                byte[] fileContent = File.ReadAllBytes(filePath);
                txtFisier.Text = System.IO.Path.GetFileName(filePath);
            }
        }

        private void InsertButtonClick(object sender, RoutedEventArgs e)
        {
            materiale = materialVM.GetListaMaterialeProfesori(profesorId);
            gridMateriale.ItemsSource = materiale;
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
