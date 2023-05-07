using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Absenta : BasePropertyChanged
    {
        private int? idAbsenta;
        private int? idMaterie;
        private int? idElev;
        private DateTime dataAbsenta;
        private bool esteMotivata;

        public int? IdAbsenta
        {
            get
            { 
                return idAbsenta; 
            }
            set
            {
                idAbsenta = value;
                NotifyPropertyChanged("IdAbsenta");
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

        public DateTime DataAbsenta
        {
            get
            {
                return dataAbsenta;
            }
            set
            {
                dataAbsenta = value;
                NotifyPropertyChanged("DataAbsenta");
            }
        }

        public bool EsteMotivata
        {
            get
            {
                return esteMotivata;
            }
            set
            {
                esteMotivata = value;
                NotifyPropertyChanged("EsteMotivata");
            }
        }
    }
}
