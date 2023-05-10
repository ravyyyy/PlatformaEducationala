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
            ObservableCollection<int> materii = new ObservableCollection<int>();
            foreach (Materie materie in notaVM.materieBLL.ListaMaterii)
            {
                if (!materii.Contains((int)materie.IdMaterie))
                {
                    materii.Add((int)materie.IdMaterie);
                }
            }
            txtIdMaterie.ItemsSource = materii;
            notaVM.elevBLL.ListaElevi = notaVM.elevBLL.ObtineTotiElevii();
            ObservableCollection<int> elevi = new ObservableCollection<int>();
            foreach (Elev elev in notaVM.elevBLL.ListaElevi)
            {
                if (!elevi.Contains((int)elev.IdElev))
                {
                    elevi.Add((int)elev.IdElev);
                }
            }
            txtIdElev.ItemsSource = elevi;
        }
    }
}
