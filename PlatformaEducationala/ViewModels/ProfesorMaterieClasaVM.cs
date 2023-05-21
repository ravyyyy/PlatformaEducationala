using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.ViewModels
{
    public class ProfesorMaterieClasaVM
    {
        public ProfesorBLL profesorBLL = new ProfesorBLL();
        public MaterieBLL materieBLL = new MaterieBLL();
        public ClasaBLL clasaBLL = new ClasaBLL();

        public ObservableCollection<KeyValuePair<string, int>> ListaIdMaterii { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ListaProfesori { get; set; }

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

        private ObservableCollection<KeyValuePair<string, int>> GetListaProfesori()
        {
            ObservableCollection<KeyValuePair<string, int>> listaProfesori = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Profesor profesor in profesorBLL.ObtineTotiProfesorii())
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(profesor.Nume, (int)profesor.IdProfesor);
                if (!listaProfesori.Contains(pair))
                {
                    listaProfesori.Add(pair);
                }
            }
            return listaProfesori;
        }

        public ProfesorMaterieClasaVM()
        {
            ListaIdMaterii = GetListaIdMaterii();
            ListaProfesori = GetListaProfesori();
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
    }
}
