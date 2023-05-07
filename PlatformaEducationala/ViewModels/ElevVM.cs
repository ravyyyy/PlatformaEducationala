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
    public class ElevVM : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();
        ClasaBLL clasaBLL = new ClasaBLL();

        public ObservableCollection<int> ListaIdClase {  get; set; }

        private ObservableCollection<int> GetListaIdClase()
        {
            ObservableCollection<int> listaIdClase = new ObservableCollection<int>();
            foreach (Clasa clasa in clasaBLL.ObtineToateClasele())
            {
                if (!listaIdClase.Contains((int)clasa.IdClasa))
                {
                    listaIdClase.Add((int)clasa.IdClasa);
                }
            }
            return listaIdClase;
        }

        #region Data Members

        public ObservableCollection<Elev> ListaElevi
        {
            get => elevBLL.ListaElevi;
            set => elevBLL.ListaElevi = value;
        }

        #endregion

        public ElevVM()
        {
            ListaElevi = elevBLL.ObtineTotiElevii();
            ListaIdClase = GetListaIdClase();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Elev>(elevBLL.InserareElev);
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
                    comandaActualizare = new RelayCommand<Elev>(elevBLL.ActualizareElev);
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
                    comandaStergere = new RelayCommand<Elev>(elevBLL.StergereElev);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
