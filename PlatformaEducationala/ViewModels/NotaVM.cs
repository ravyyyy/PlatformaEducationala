using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class NotaVM : BasePropertyChanged
    {
        public NotaBLL notaBLL = new NotaBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public ElevBLL elevBLL = new ElevBLL();
        public ProfesorBLL profesorBLL = new ProfesorBLL();

        public ObservableCollection<int> ListaIdMaterii { get; set; }
        public ObservableCollection<int> ListaIdElevi { get; set; }

        public ObservableCollection<int> GetListaIdMaterii()
        {
            ObservableCollection<int> listaIdMaterii = new ObservableCollection<int>();
            foreach (Materie materie in materieBLL.ObtineToateMateriile())
            {
                if (!listaIdMaterii.Contains((int)materie.IdMaterie))
                {
                    listaIdMaterii.Add((int)materie.IdMaterie);
                }
            }
            return listaIdMaterii;
        }

        public ObservableCollection<int> GetListaIdElevi()
        {
            ObservableCollection<int> listaIdElevi = new ObservableCollection<int>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                if (!listaIdElevi.Contains((int)elev.IdElev))
                {
                    listaIdElevi.Add((int)elev.IdElev);
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
