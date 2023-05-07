namespace PlatformaEducationala.Models.EntityLayer
{
    public class Materie : BasePropertyChanged
    {
        private int? idMaterie;
        private string nume;
        private int? idProfesor;
        private bool areTeza;
        private int anStudiu;

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

        public bool AreTeza
        {
            get
            {
                return areTeza;
            }
            set
            {
                areTeza = value;
                NotifyPropertyChanged("AreTeza");
            }
        }

        public int AnStudiu
        {
            get
            {
                return anStudiu;
            }
            set
            { 
                anStudiu = value;
                NotifyPropertyChanged("AnStudiu");
            }
        }
    }
}
