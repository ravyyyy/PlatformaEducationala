namespace PlatformaEducationala.Models.EntityLayer
{
    public class Nota : BasePropertyChanged
    {
        private int? idNota;
        private int? idMaterie;
        private int valoare;
        private bool esteTeza;
        private int semestru;
        private bool medieIncheiata;
        private int? idElev;

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

        public int Semestru
        {
            get
            {
                return semestru;
            }
            set
            {
                semestru = value;
                NotifyPropertyChanged("Semestru");
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

        public int? IdElev
        {
            get
            {
                return idElev;
            }
            set
            {
                idElev = value;
                NotifyPropertyChanged("IdElev");
            }
        }
    }
}
