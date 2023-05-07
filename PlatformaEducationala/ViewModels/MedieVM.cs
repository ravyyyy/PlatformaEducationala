using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.DataAccessLayer;
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
    public class MedieVM : BasePropertyChanged
    {
        MedieBLL medieBLL = new MedieBLL();
        ElevBLL elevBLL = new ElevBLL();
        MaterieBLL materieBLL = new MaterieBLL();

        public ObservableCollection<int> ListaIdElevi { get; set; }
        public ObservableCollection<int> ListaIdMaterii { get; set; }

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
