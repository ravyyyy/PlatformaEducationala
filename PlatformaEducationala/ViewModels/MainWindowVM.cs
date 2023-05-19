using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.ViewModels
{
    public class MainWindowVM : BasePropertyChanged
    {
        public ProfesorBLL profesorBLL = new ProfesorBLL();
        public ElevBLL elevBLL = new ElevBLL();

        public ObservableCollection<KeyValuePair<string, int>> Profesori { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> Diriginti { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> Elevi { get; set; }

        private ObservableCollection<KeyValuePair<string, int>> GetProfesori()
        {
            ObservableCollection<KeyValuePair<string, int>> profesori = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Profesor profesor in profesorBLL.ObtineTotiProfesorii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(profesor.Nume, (int)profesor.IdProfesor);
                if (!profesori.Contains(pair))
                {
                    profesori.Add(pair);
                }
            }
            return profesori;
        }

        private ObservableCollection<KeyValuePair<string, int>> GetDiriginti()
        {
            ObservableCollection<KeyValuePair<string, int>> diriginti = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Profesor diriginte in profesorBLL.ObtineTotiProfesorii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(diriginte.Nume, (int)diriginte.IdProfesor);
                if (!diriginti.Contains(pair))
                {
                    diriginti.Add(pair);
                }
            }
            return diriginti;
        }

        private ObservableCollection<KeyValuePair<string, int>> GetElevi()
        {
            ObservableCollection<KeyValuePair<string, int>> elevi = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(elev.Nume, (int)elev.IdElev);
                if (!elevi.Contains(pair))
                {
                    elevi.Add(pair);
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
