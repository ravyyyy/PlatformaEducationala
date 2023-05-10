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
    public class MaterialVM : BasePropertyChanged
    {
        MaterialBLL materialBLL = new MaterialBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public ProfesorBLL profesorBLL = new ProfesorBLL();

        public ObservableCollection<int> ListaIdMaterii { get; set; }

        public ObservableCollection<int> GetLIstaIdMaterii()
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
