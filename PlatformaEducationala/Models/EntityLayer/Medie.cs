using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Medie : BasePropertyChanged
    {
        private int? idMedie;
        private int? idElev;
        private int? idMaterie;
        private decimal nota;

        public int? IdMedie
        {
            get
            {
                return idMedie;
            }
            set
            {
                idMedie = value;
                NotifyPropertyChanged("IdMedie");
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

        public decimal Nota
        {
            get
            {
                return nota;
            }
            set
            {
                nota = value;
                NotifyPropertyChanged("Nota");
            }
        }

        public static implicit operator int(Medie v)
        {
            throw new NotImplementedException();
        }
    }
}
