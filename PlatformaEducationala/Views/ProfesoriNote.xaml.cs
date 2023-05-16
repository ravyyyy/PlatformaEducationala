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
    /// Interaction logic for ProfesoriNote.xaml
    /// </summary>
    public partial class ProfesoriNote : Window
    {
        private int profesorId;
        private ObservableCollection<Nota> note = new ObservableCollection<Nota>();

        public ProfesoriNote()
        {
            InitializeComponent();
        }

        public ProfesoriNote(int profesorId)
        {
            InitializeComponent();
            this.profesorId = profesorId;
            NotaVM notaVM = this.DataContext as NotaVM;
            note = notaVM.GetListaNoteProfesori(profesorId);
            noteDG.ItemsSource = note;
            Profesor profesor = notaVM.profesorBLL.ObtineProfesorDupaId(profesorId);
            notaVM.materieBLL.ObtineToateMateriileDupaProfesor(profesor);
            ObservableCollection<KeyValuePair<string, int>> materii = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Materie materie in notaVM.materieBLL.ListaMaterii)
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(materie.Nume, (int)materie.IdMaterie);
                if (!materii.Contains(pair))
                {
                    materii.Add(pair);
                }
            }
            txtIdMaterie.ItemsSource = materii;
            notaVM.elevBLL.ListaElevi = notaVM.elevBLL.ObtineTotiElevii();
            ObservableCollection<KeyValuePair<string, int>> elevi = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Elev elev in notaVM.elevBLL.ListaElevi)
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(elev.Nume, (int)elev.IdElev);
                if (!elevi.Contains(pair))
                {
                    elevi.Add(pair);
                }
            }
            txtIdElev.ItemsSource = elevi;
        }
    }
}
