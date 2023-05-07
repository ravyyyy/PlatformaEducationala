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
    public class AbsentaVM : BasePropertyChanged
    {
        AbsentaBLL absentaBLL = new AbsentaBLL();

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
