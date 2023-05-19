using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for EleviNote.xaml
    /// </summary>
    public partial class EleviNote : Window
    {
        int elevId;

        public EleviNote()
        {
            InitializeComponent();
        }

        public EleviNote(int elevId)
        {
            InitializeComponent();
            this.elevId = elevId;
            NotaVM notaVM = DataContext as NotaVM;
            ObservableCollection<Nota> note = new ObservableCollection<Nota>();
            Elev elev = notaVM.elevBLL.ObtineElevDupaId(elevId);
            foreach (Nota nota in notaVM.ListaNote)
            {
                if (!note.Contains(nota) && nota.IdElev == elev.IdElev)
                {
                    note.Add(nota);
                }
            }
            gridNote.ItemsSource = note;
        }
    }
}
