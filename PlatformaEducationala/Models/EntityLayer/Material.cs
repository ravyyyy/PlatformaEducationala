using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Material : BasePropertyChanged
    {
        private int? idMaterial;
        private int? idMaterie;
        private byte[] fisier;

        public int? IdMaterial
        {
            get
            {
                return idMaterial;
            }
            set
            {
                idMaterial = value;
                NotifyPropertyChanged("IdMaterial");
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

        public byte[] Fisier
        {
            get
            {
                return fisier;
            }
            set
            {
                fisier = value;
                NotifyPropertyChanged("Fisier");
            }
        }
    }
}
