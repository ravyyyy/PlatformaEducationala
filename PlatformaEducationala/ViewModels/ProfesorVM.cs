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
    public class ProfesorVM : BasePropertyChanged
    {
        ProfesorBLL profesorBLL = new ProfesorBLL();

        #region Data Members

        public ObservableCollection<Profesor> ListaProfesori
        {
            get => profesorBLL.ListaProfesori;
            set => profesorBLL.ListaProfesori = value;
        }

        #endregion

        public ProfesorVM()
        {
            ListaProfesori = profesorBLL.ObtineTotiProfesorii();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Profesor>(profesorBLL.InserareProfesor);
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
                    comandaActualizare = new RelayCommand<Profesor>(profesorBLL.ActualizareProfesor);
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
                    comandaStergere = new RelayCommand<Profesor>(profesorBLL.StergereProfesor);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
