using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class MedieVM : BasePropertyChanged
    {
        public MedieBLL medieBLL = new MedieBLL();
        public ProfesorBLL profesorBLL = new ProfesorBLL();
        public ElevBLL elevBLL = new ElevBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public NotaBLL notaBLL = new NotaBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdElevi { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaIdMaterii { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaIdEleviDupaProfesor { get; set; }

        public ObservableCollection<KeyValuePair<string, int>> GetListaIdElevi()
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdElevi = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(elev.Nume, (int)elev.IdElev);
                if (!listaIdElevi.Contains(pair))
                {
                    listaIdElevi.Add(pair);
                }
            }
            return listaIdElevi;
        }

        public ObservableCollection<KeyValuePair<string, int>> GetListaIdEleviProfesor(Profesor profesor)
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdElevi = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(elev.Nume, (int)elev.IdElev);
                if (!listaIdElevi.Contains(pair))
                {
                    listaIdElevi.Add(pair);
                }
            }
            return listaIdElevi;
        }

        public ObservableCollection<KeyValuePair<string, int>> GetListaIdMaterii()
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdMaterii = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Materie materie in materieBLL.ObtineToateMateriile())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(materie.Nume, (int)materie.IdMaterie);
                if (!listaIdMaterii.Contains(pair))
                {
                    listaIdMaterii.Add(pair);
                }
            }
            return listaIdMaterii;
        }

        public ObservableCollection<KeyValuePair<string, int>> GetListaIdMateriiProfesor(Profesor profesor)
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdMaterii = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Materie materie in materieBLL.ObtineToateMateriile())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(materie.Nume, (int)materie.IdMaterie);
                if (!listaIdMaterii.Contains(pair) && profesor.IdProfesor == materie.IdProfesor)
                {
                    listaIdMaterii.Add(pair);
                }
            }
            return listaIdMaterii;
        }

        #region Data Members

        public ObservableCollection<Medie> ListaMedie
        {
            get => medieBLL.ListaMedii;
            set => medieBLL.ListaMedii = value;
        }

        #endregion

        public MedieVM()
        {
            ListaMedie = medieBLL.ObtineToateMediile();
            ListaIdElevi = GetListaIdElevi();
            ListaIdMaterii = GetListaIdMaterii();
        }

        #region

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Medie>(medieBLL.InserareMedie);
                }
                return comandaInserare;
            }
        }

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Medie>(medieBLL.ActualizareMedie);
                }
                return comandaActualizare;
            }
        }

        private ICommand comandaStergere;
        public ICommand ComandaStergere
        {
            get
            {
                if (comandaStergere == null)
                {
                    comandaStergere = new RelayCommand<Medie>(medieBLL.StergereMedie);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
