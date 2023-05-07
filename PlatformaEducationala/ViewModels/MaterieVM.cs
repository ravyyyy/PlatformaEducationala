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
    public class MaterieVM : BasePropertyChanged
    {
        MaterieBLL materieBLL = new MaterieBLL();
        ProfesorBLL profesorBLL = new ProfesorBLL();

        public ObservableCollection<int> ListaIdProfesori { get; set; }

        public ObservableCollection<int> GetListaIdProfesori()
        {
            ObservableCollection<int> listaIdProfesori = new ObservableCollection<int>();
            foreach (Profesor profesor in profesorBLL.ObtineTotiProfesorii())
            {
                if (!listaIdProfesori.Contains((int)profesor.IdProfesor))
                {
                    listaIdProfesori.Add((int)profesor.IdProfesor);
                }
            }
            return listaIdProfesori;
        }

        #region Data Members

        public ObservableCollection<Materie> ListaMaterie
        {
            get => materieBLL.ListaMaterii;
            set => materieBLL.ListaMaterii = value;
        }

        #endregion

        public MaterieVM()
        {
            ListaMaterie = materieBLL.ObtineToateMateriile();
            ListaIdProfesori = GetListaIdProfesori();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Materie>(materieBLL.InserareMaterie);
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
                    comandaActualizare = new RelayCommand<Materie>(materieBLL.ActualizareMaterie);
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
                    comandaStergere = new RelayCommand<Materie>(materieBLL.StergereMaterie);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
