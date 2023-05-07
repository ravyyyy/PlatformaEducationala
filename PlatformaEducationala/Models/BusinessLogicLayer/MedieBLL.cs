using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class MedieBLL
    {
        public ObservableCollection<Medie> ListaMedii { get; set; }

        MedieDAL medieDAL = new MedieDAL();

        public MedieBLL()
        {
            ListaMedii = new ObservableCollection<Medie>();
        }

        public ObservableCollection<Medie> ObtineToateMediile()
        {
            return medieDAL.ObtineToateMediile();
        }

        public void InserareMedie(Medie medie)
        {
            if (string.IsNullOrEmpty(medie.IdMaterie.ToString()))
            {
                throw new AgendaException("ID-ul materiei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(medie.IdElev.ToString()))
            {
                throw new AgendaException("ID-ul elevului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(medie.Nota.ToString()))
            {
                throw new AgendaException("Nota medieo trebuie precizata.");
            }
            medieDAL.InserareMedie(medie);
            ListaMedii.Add(medie);
        }

        public void ActualizareMedie(Medie medie)
        {
            if (medie == null)
            {
                throw new AgendaException("Trebuie selectata o medie.");
            }
            if (string.IsNullOrEmpty(medie.IdMaterie.ToString()))
            {
                throw new AgendaException("ID-ul materiei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(medie.IdElev.ToString()))
            {
                throw new AgendaException("ID-ul elevului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(medie.Nota.ToString()))
            {
                throw new AgendaException("Nota mediei trebuie precizata.");
            }
            medieDAL.ActualizareMedie(medie);
        }

        public void StergereMedie(Medie medie)
        {
            if (medie == null)
            {
                throw new AgendaException("Nota mediei trebuie precizata.");
            }
            medieDAL.StergereMedie(medie);
            ListaMedii.Remove(medie);
        }
    }
}
