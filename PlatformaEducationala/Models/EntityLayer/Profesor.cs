using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Profesor : BasePropertyChanged
    {
        private int? idProfesor;
        private string nume;
        private string prenume;
        private DateTime dataNastere;
        private string adresa;
        private string numarTelefon;
        private string email;
        private bool esteDiriginte;

        public int? IdProfesor
        {
            get
            {
                return idProfesor;
            }
            set
            {
                idProfesor = value;
                NotifyPropertyChanged("IdProfesor");
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

        public bool EsteDiriginte
        {
            get
            {
                return esteDiriginte;
            }
            set
            {
                esteDiriginte = value;
                NotifyPropertyChanged("EsteDiriginte");
            }
        }
    }
}
