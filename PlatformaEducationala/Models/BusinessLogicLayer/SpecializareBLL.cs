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
    public class SpecializareBLL
    {
        public ObservableCollection<Specializare> ListaSpecializare { get; set; }

        SpecializareDAL specializareDAL = new SpecializareDAL();

        public SpecializareBLL()
        {
            ListaSpecializare = new ObservableCollection<Specializare>();
        }

        public ObservableCollection<Specializare> ObtineToateSpecializarile()
        {
            return specializareDAL.ObtineToateSpecializarile();
        }

        public void InserareSpecializare(Specializare specializare)
        {
            if (string.IsNullOrEmpty(specializare.Denumire))
            {
                throw new AgendaException("Denumirea specializarii trebuie sa fie precizata.");
            }
            specializareDAL.InserareSpecializare(specializare);
            ListaSpecializare.Add(specializare);
        }

        public void ActualizareSpecializare(Specializare specializare)
        {
            if (specializare == null)
            {
                throw new AgendaException("Trebuie selectata o specializare.");
            }
            
            if (string.IsNullOrEmpty(specializare.Denumire))
            {
                throw new AgendaException("Trebuie precizata denumirea specializarii.");
            }
            specializareDAL.ActualizareSpecializare(specializare);
        }

        public void StergereSpecializare(Specializare specializare)
        {
            if (specializare == null)
            {
                throw new AgendaException("Trebuie selectata o specializare.");
            }
            else
            {
                //completare cu verificare in celelalte clase daca exista
                ClasaDAL clasaDAL = new ClasaDAL();
                if (clasaDAL.ObtineToateClaseleDupaSpecializare(specializare).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai clasele cu specializarea " + specializare.Denumire);
                }
            }
            specializareDAL.StergereSpecializare(specializare);
            ListaSpecializare.Remove(specializare);
        }
    }
}
