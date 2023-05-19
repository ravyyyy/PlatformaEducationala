using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class AbsentaVM : BasePropertyChanged
    {
        AbsentaBLL absentaBLL = new AbsentaBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public ProfesorBLL profesorBLL = new ProfesorBLL();
        ElevBLL elevBLL = new ElevBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdMaterie { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaIdElev { get; set; }
        public ObservableCollection<Absenta> ListaAbsenteProfesori { get; set; }

        private ObservableCollection<KeyValuePair<string, int>> GetListaIdMaterii()
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdClase = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Materie materie in materieBLL.ObtineToateMateriile())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(materie.Nume, (int)materie.IdMaterie);
                if (!listaIdClase.Contains(pair))
                {
                    listaIdClase.Add(pair);
                }
            }
            return listaIdClase;
        }

        private ObservableCollection<KeyValuePair<string, int>> GetListaIdElevi()
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdClase = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(elev.Nume, (int)elev.IdElev);
                if (!listaIdClase.Contains(pair))
                {
                    listaIdClase.Add(pair);
                }
            }
            return listaIdClase;
        }

        public ObservableCollection<Absenta> GetListaAbsenteProfesori(int id)
        {
            return absentaBLL.ObtineToateAbsenteleDupaMaterieDupaProfesor(id);
        }

        #region Data Members

        public ObservableCollection<Absenta> ListaAbsente
        {
            get => absentaBLL.ListaAbsente;
            set => absentaBLL.ListaAbsente = value;
        }

        #endregion

        public AbsentaVM()
        {
            ListaAbsente = absentaBLL.ObtineToateAbsentele();
            ListaIdMaterie = GetListaIdMaterii();
            ListaIdElev = GetListaIdElevi();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Absenta>(absentaBLL.InserareAbsenta);
                }
                return comandaInserare;
            }
        }

        private ICommand comandaStergere;
        public ICommand ComandaStergere
        {
            get
            {
                if (comandaStergere == null)
                {
                    comandaStergere = new RelayCommand<Absenta>(absentaBLL.StergereAbsenta);
                }
                return comandaStergere;
            }
        }

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Absenta>(absentaBLL.ActualizareAbsenta);
                }
                return comandaActualizare;
            }
        }

        #endregion
    }
}
