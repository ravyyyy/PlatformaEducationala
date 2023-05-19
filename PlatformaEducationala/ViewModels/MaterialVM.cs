using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class MaterialVM : BasePropertyChanged
    {
        MaterialBLL materialBLL = new MaterialBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public ProfesorBLL profesorBLL = new ProfesorBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdMaterii { get; set; }

        public ObservableCollection<KeyValuePair<string, int>> GetLIstaIdMaterii()
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

        public ObservableCollection<Material> GetListaMaterialeProfesori(int id)
        {
            return materialBLL.ObtineToateMaterialeleDupaMaterieDupaProfesor(id);
        }

        #region Data Members

        public ObservableCollection<Material> ListaMateriale
        {
            get => materialBLL.ListaMateriale;
            set => materialBLL.ListaMateriale = value;
        }

        #endregion

        public MaterialVM()
        {
            ListaMateriale = materialBLL.ObtineToateMaterialele();
            ListaIdMaterii = GetLIstaIdMaterii();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Material>(materialBLL.InserareMaterial);
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
                    comandaActualizare = new RelayCommand<Material>(materialBLL.ActualizareMaterial);
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
                    comandaStergere = new RelayCommand<Material>(materialBLL.StergereMaterial);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
