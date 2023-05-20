using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class ClasaVM : BasePropertyChanged
    {
        ClasaBLL clasaBLL = new ClasaBLL();
        SpecializareBLL specializareBLL = new SpecializareBLL();
        ProfesorBLL profesorBLL = new ProfesorBLL();
        public ElevBLL elevBLL = new ElevBLL();
        public MedieBLL medieBLL = new MedieBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public AbsentaBLL absentaBLL = new AbsentaBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdSpecializari { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaIdProfesori { get; set; }

        private ObservableCollection<KeyValuePair<string, int>> GetListaIdSpecializari()
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdSpecializari = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Specializare specializare in specializareBLL.ObtineToateSpecializarile())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(specializare.Denumire, (int)specializare.IdSpecializare);
                if (!listaIdSpecializari.Contains(pair))
                {
                    listaIdSpecializari.Add(pair);
                }
            }
            return listaIdSpecializari;
        }

        private ObservableCollection<KeyValuePair<string, int>> GetListaIdProfesori()
        {
            ObservableCollection<KeyValuePair<string, int>> listaIdSpecializari = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Profesor profesor in profesorBLL.ObtineTotiProfesorii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(profesor.Nume, (int)profesor.IdProfesor);
                if (!listaIdSpecializari.Contains(pair))
                {
                    listaIdSpecializari.Add(pair);
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
