using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class NotaVM : BasePropertyChanged
    {
        public NotaBLL notaBLL = new NotaBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public ElevBLL elevBLL = new ElevBLL();
        public ProfesorBLL profesorBLL = new ProfesorBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdMaterii { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaIdElevi { get; set; }

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

        public ObservableCollection<Nota> GetListaNoteProfesori(int profesorId)
        {
            return notaBLL.ObtineToateNoteleDupaMaterieDupaProfesor(profesorId);
        }

        #region Data Members

        public ObservableCollection<Nota> ListaNote
        {
            get => notaBLL.ListaNote;
            set => notaBLL.ListaNote = value;
        }

        #endregion

        public NotaVM()
        {
            ListaNote = notaBLL.ObtineToateNotele();
            ListaIdMaterii = GetListaIdMaterii();
            ListaIdElevi = GetListaIdElevi();
        }

        #region Command Members

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Nota>(notaBLL.ActualizareNota);
                }
                return comandaActualizare;
            }
        }

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Nota>(notaBLL.InserareNota);
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
                    comandaStergere = new RelayCommand<Nota>(notaBLL.StergereNota);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
