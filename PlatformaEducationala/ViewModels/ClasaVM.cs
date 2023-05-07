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
    public class ClasaVM : BasePropertyChanged
    {
        ClasaBLL clasaBLL = new ClasaBLL();
        SpecializareBLL specializareBLL = new SpecializareBLL();
        ProfesorBLL profesorBLL = new ProfesorBLL();

        public ObservableCollection<int> ListaIdSpecializari { get; set; }
        public ObservableCollection<int> ListaIdProfesori { get; set; }

        private ObservableCollection<int> GetListaIdSpecializari()
        {
            ObservableCollection<int> listaIdSpecializari = new ObservableCollection<int>();
            foreach (Specializare specializare in specializareBLL.ObtineToateSpecializarile())
            {
                if (!listaIdSpecializari.Contains((int)specializare.IdSpecializare))
                {
                    listaIdSpecializari.Add((int)specializare.IdSpecializare);
                }
            }
            return listaIdSpecializari;
        }

        private ObservableCollection<int> GetListaIdProfesori()
        {
            ObservableCollection<int> listaIdSpecializari = new ObservableCollection<int>();
            foreach (Profesor profesor in profesorBLL.ObtineTotiProfesorii())
            {
                if (!listaIdSpecializari.Contains((int)profesor.IdProfesor))
                {
                    listaIdSpecializari.Add((int)profesor.IdProfesor);
                }
            }
            return listaIdSpecializari;
        }

        #region Data Members

        public ObservableCollection<Clasa> ListaClase
        {
            get => clasaBLL.ListaClase;
            set => clasaBLL.ListaClase = value;
        }

        #endregion

        public ClasaVM()
        {
            ListaClase = clasaBLL.ObtineToateClasele();
            ListaIdSpecializari = GetListaIdSpecializari();
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
                    comandaInserare = new RelayCommand<Clasa>(clasaBLL.InserareClasa);
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
                    comandaStergere = new RelayCommand<Clasa>(clasaBLL.StergereClasa);
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
                    comandaActualizare = new RelayCommand<Clasa>(clasaBLL.ActualizareClasa);
                }
                return comandaActualizare;
            }
        }

        #endregion
    }
}
