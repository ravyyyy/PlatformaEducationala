namespace PlatformaEducationala.Models.EntityLayer
{
    public class Nota : BasePropertyChanged
    {
        private int? idNota;
        private int? idMaterie;
        private int valoare;
        private bool esteTeza;
        private bool medieIncheiata;

        public int? IdNota
        {
            get
            {
                return idNota;
            }
            set
            {
                idNota = value;
                NotifyPropertyChanged("IdNota");
            }
        }

        public int? IdMaterie
        {
            get
            {
                return idMaterie;
            }
            set
            {
                idMaterie = value;
                NotifyPropertyChanged("IdMaterie");
            }
        }

        public int Valoare
        {
            get
            { 
                return valoare; 
            }
            set
            {
                valoare = value;
                NotifyPropertyChanged("Valoare");
            }
        }

        public bool EsteTeza
        {
            get
            {
                return esteTeza;
            }
            set
            {
                esteTeza = value;
                NotifyPropertyChanged("EsteTeza");
            }
        }

        public bool MedieIncheiata
        {
            get
            {
                return medieIncheiata;
            }
            set
            {
                medieIncheiata = value;
                NotifyPropertyChanged("MedieIncheiata");
            }
        }
    }
}
