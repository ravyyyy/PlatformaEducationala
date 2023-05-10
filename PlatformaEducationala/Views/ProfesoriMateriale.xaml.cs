using Microsoft.Win32;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProfesoriMateriale.xaml
    /// </summary>
    public partial class ProfesoriMateriale : Window
    {
        private int profesorId;
        private ObservableCollection<Material> materiale = new ObservableCollection<Material>();

        public ProfesoriMateriale()
        {
            InitializeComponent();
        }

        public ProfesoriMateriale(int profesorId)
        {
            InitializeComponent();
            this.profesorId = profesorId;
            MaterialVM materialVM = this.DataContext as MaterialVM;
            materiale = materialVM.GetListaMaterialeProfesori(profesorId);
            gridMateriale.ItemsSource = materiale;
            Profesor profesor = materialVM.profesorBLL.ObtineProfesorDupaId(profesorId);
            materialVM.materieBLL.ObtineToateMateriileDupaProfesor(profesor);
            ObservableCollection<int> materii = new ObservableCollection<int>();
            foreach (Materie materie in materialVM.materieBLL.ListaMaterii)
            {
                if (!materii.Contains((int)materie.IdMaterie))
                {
                    materii.Add((int)materie.IdMaterie);
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
        }
    }
}
