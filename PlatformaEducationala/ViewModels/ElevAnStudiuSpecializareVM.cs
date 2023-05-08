using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.ViewModels
{
    public class ElevAnStudiuSpecializareVM : BasePropertyChanged
    {
        public ElevBLL elevBLL = new ElevBLL();
        public ClasaBLL clasaBLL = new ClasaBLL();
        public SpecializareBLL specializareBLL = new SpecializareBLL();

        public ObservableCollection<int> ListaIdElevi { get; set; }
        public ObservableCollection<string> ListaSpecializari { get; set; }

        public int anStudiu { get; set; }
        //public string specializare { get; set; }

        private ObservableCollection<int> GetListaIdElevi()
        {
            ObservableCollection<int> listaIdElev = new ObservableCollection<int>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                if (!listaIdElev.Contains((int)elev.IdElev))
                {
                    listaIdElev.Add((int)elev.IdElev);
                }
            }
            return listaIdElev;
        }

        public ObservableCollection<string> ObtineToateDenumirileSpecializarilor(ObservableCollection<Specializare> specializari)
        {
            ObservableCollection<string> listaSpecializari = new ObservableCollection<string>();
            foreach (Specializare specializare in specializari)
            {
                if (!listaSpecializari.Contains(specializare.Denumire))
                {
                    listaSpecializari.Add(specializare.Denumire);
                }
            }
            return listaSpecializari;
        }

        //public void ObtineSpecializareDupaSpecializare(int specializareId)
        //{
        //    specializare = specializareBLL.ObtineSpecializareDupaSpecializare(specializareId);
        //}

        public void ObtineAnStudiuDupaClasa(int clasa)
        {
            anStudiu = clasaBLL.ObtineAnStudiuDupaClasa(clasa);
        }

        public ElevAnStudiuSpecializareVM()
        {
            ListaIdElevi = GetListaIdElevi();
        }
    }
}
