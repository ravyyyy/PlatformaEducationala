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
    public class SpecializareVM : BasePropertyChanged
    {
        SpecializareBLL specializareBLL = new SpecializareBLL();

        public ObservableCollection<Specializare> ListaSpecializare
        {
            get => specializareBLL.ListaSpecializare;
            set => specializareBLL.ListaSpecializare = value;
        }

        #region Data Members

        public SpecializareVM()
        {
            ListaSpecializare = specializareBLL.ObtineToateSpecializarile();
        }

        #endregion

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Specializare>(specializareBLL.InserareSpecializare);
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
                    comandaActualizare = new RelayCommand<Specializare>(specializareBLL.ActualizareSpecializare);
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
                    comandaStergere = new RelayCommand<Specializare>(specializareBLL.StergereSpecializare);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
