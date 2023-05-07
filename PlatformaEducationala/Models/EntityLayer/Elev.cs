using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Elev : BasePropertyChanged
    {
        private int? idElev;
        private string nume;
        private string prenume;
        private DateTime dataNastere;
        private string adresa;
        private string numarTelefon;
        private string email;
        private int? idClasa;

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

        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }

        public string Prenume
        {
            get
            {
                return prenume;
            }
            set 
            { 
                prenume = value;
                NotifyPropertyChanged("Prenume");
            }
        }

        public DateTime DataNastere
        {
            get
            {
                return dataNastere;
            }
            set
            {
                dataNastere = value;
                NotifyPropertyChanged("DataNastere");
            }
        }

        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                NotifyPropertyChanged("Adresa");
            }
        }

        public string NumarTelefon
        {
            get
            {
                return numarTelefon;
            }
            set
            {
                numarTelefon = value;
                NotifyPropertyChanged("NumarTelefon");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public int? IdClasa
        { 
            get
            { 
                return idClasa; 
            }
            set
            {
                idClasa = value;
                NotifyPropertyChanged("IdClasa");
            }
        }
    }
}
