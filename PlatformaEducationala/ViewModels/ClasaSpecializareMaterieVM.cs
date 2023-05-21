using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.ViewModels
{
    public class ClasaSpecializareMaterieVM : BasePropertyChanged
    {
        public ClasaBLL clasaBLL = new ClasaBLL();
        public SpecializareBLL specializareBLL = new SpecializareBLL();
        public MaterieBLL materieBLL = new MaterieBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdMaterii { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaSpecializari { get; set; }

        public int anStudiu { get; set; }

        private ObservableCollection<KeyValuePair<string, int>> GetListaIdMaterii()
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

        public void ObtineAnStudiuDupaClasa(int clasa)
        {
            anStudiu = clasaBLL.ObtineAnStudiuDupaClasa(clasa);
        }

        public ObservableCollection<KeyValuePair<string, int>> ObtineToateDenumirileSpecializarilor(ObservableCollection<Specializare> specializari)
        {
            ObservableCollection<KeyValuePair<string, int>> listaSpecializari = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Specializare specializare in specializari)
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(specializare.Denumire, (int)specializare.IdSpecializare);
                if (!listaSpecializari.Contains(pair))
                {
                    listaSpecializari.Add(pair);
                }
            }
            return listaSpecializari;
        }

        public ClasaSpecializareMaterieVM()
        {
            ListaIdMaterii = GetListaIdMaterii();
        }
    }
}
