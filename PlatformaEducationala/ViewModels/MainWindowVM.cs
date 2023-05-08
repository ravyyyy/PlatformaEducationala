using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.ViewModels
{
    public class MainWindowVM : BasePropertyChanged
    {
        public ProfesorBLL profesorBLL = new ProfesorBLL();
        public ElevBLL elevBLL = new ElevBLL();

        public ObservableCollection<int> Profesori { get; set; }
        public ObservableCollection<int> Diriginti { get; set; }
        public ObservableCollection<int> Elevi { get; set; }

        private ObservableCollection<int> GetProfesori()
        {
            ObservableCollection<int> profesori = new ObservableCollection<int>();
            foreach (Profesor profesor in profesorBLL.ObtineTotiProfesorii())
            {
                if (!profesori.Contains((int)profesor.IdProfesor))
                {
                    profesori.Add((int)profesor.IdProfesor);
                }
            }
            return profesori;
        }

        private ObservableCollection<int> GetDiriginti()
        {
            ObservableCollection<int> diriginti = new ObservableCollection<int>();
            foreach (Profesor diriginte in profesorBLL.ObtineTotiProfesorii())
            {
                if (!diriginti.Contains((int)diriginte.IdProfesor) && diriginte.EsteDiriginte)
                {
                    diriginti.Add((int)diriginte.IdProfesor);
                }
            }
            return diriginti;
        }

        private ObservableCollection<int> GetElevi()
        {
            ObservableCollection<int> elevi = new ObservableCollection<int>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                if (!elevi.Contains((int)elev.IdElev))
                {
                    elevi.Add((int)elev.IdElev);
                }
            }
            return elevi;
        }

        public MainWindowVM()
        {
            Profesori = GetProfesori();
            Diriginti = GetDiriginti();
            Elevi = GetElevi();
        }
    }
}
