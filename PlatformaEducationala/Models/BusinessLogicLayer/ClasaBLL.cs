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
    public class ClasaBLL
    {
        public ObservableCollection<Clasa> ListaClase { get; set; }

        ClasaDAL clasaDAL = new ClasaDAL();

        public ClasaBLL()
        {
            ListaClase = new ObservableCollection<Clasa>();
        }

        public ObservableCollection<Clasa> ObtineToateClasele()
        {
            return clasaDAL.ObtineToateClasele();
        }

        public void ObtineToateClaseleDupaSpecializare(Specializare specializare)
        {
            ListaClase.Clear();
            var clase = clasaDAL.ObtineToateClaseleDupaSpecializare(specializare);
            foreach (var clasa in clase)
            {
                ListaClase.Add(clasa);
            }
        }

        public void ObtineToateClaseleDupaProfesor(Profesor profesor)
        {
            ListaClase.Clear();
            var clase = clasaDAL.ObtineToateClaseleDupaProfesor(profesor);
            foreach (var clasa in clase)
            {
                ListaClase.Add(clasa);
            }
        }

        public void InserareClasa(Clasa clasa)
        {
            if (string.IsNullOrEmpty(clasa.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu al clasei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(clasa.Grupa.ToString()))
            {
                throw new AgendaException("Grupa clasei trebuie precizata.");
            }
            clasaDAL.InserareClasa(clasa);
            ListaClase.Add(clasa);
        }

        public void ActualizareClasa(Clasa clasa)
        {
            if (clasa == null)
            {
                throw new AgendaException("Trebuie selectata o clasa.");
            }
            if (string.IsNullOrEmpty(clasa.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu al clasei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(clasa.Grupa.ToString()))
            {
                throw new AgendaException("Grupa clasei trebuie precizata.");
            }
            clasaDAL.ActualizareClasa(clasa);
        }

        public void StergereClasa(Clasa clasa)
        {
            if (clasa == null)
            {
                throw new AgendaException("Trebuie selectata o clasa.");
            }
            else
            {
                ElevDAL elevDAL = new ElevDAL();
                if (elevDAL.ObtineTotiEleviiDupaClasa(clasa).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai elevii din clasa " + clasa.Grupa);
                }
            }
            clasaDAL.StergereClasa(clasa);
            ListaClase.Remove(clasa);
        }
    }
}
