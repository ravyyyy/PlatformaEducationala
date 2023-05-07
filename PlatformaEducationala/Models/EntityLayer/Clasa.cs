namespace PlatformaEducationala.Models.EntityLayer
{
    public class Clasa : BasePropertyChanged
    {
        private int? idClasa;
        private int? idSpecializare;
        private int? idDiriginte;
        private int anStudiu;
        private string grupa;

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

        public int? IdSpecializare
        {
            get
            {
                return idSpecializare;
            }
            set
            {
                idSpecializare = value;
                NotifyPropertyChanged("IdSpecializare");
            }
        }

        public int? IdDiriginte
        {
            get
            { 
                return idDiriginte;
            }
            set
            {
                idDiriginte = value;
                NotifyPropertyChanged("IdDiriginte");
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

        public string Grupa
        {
            get
            {
                return grupa;
            }
            set
            {
                grupa = value;
                NotifyPropertyChanged("Grupa");
            }
        }
    }
}
