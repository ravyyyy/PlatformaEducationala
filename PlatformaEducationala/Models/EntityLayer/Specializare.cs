namespace PlatformaEducationala.Models.EntityLayer
{
    public class Specializare : BasePropertyChanged
    {
        private int? idSpecializare;
        private string denumire;

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

        public string Denumire
        {
            get
            { 
                return denumire;
            }
            set
            {
                denumire = value;
                NotifyPropertyChanged("Denumire");
            }
        }
    }
}
