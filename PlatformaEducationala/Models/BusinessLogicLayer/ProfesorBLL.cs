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
    public class ProfesorBLL
    {
        public ObservableCollection<Profesor> ListaProfesori { get; set; }

        ProfesorDAL profesoriDAL = new ProfesorDAL();

        public ProfesorBLL()
        {
            ListaProfesori = new ObservableCollection<Profesor>();
        }

        public ObservableCollection<Profesor> ObtineTotiProfesorii()
        {
            return profesoriDAL.ObtineTotiProfesorii();
        }

        public void InserareProfesor(Profesor profesor)
        {
            if (string.IsNullOrEmpty(profesor.Nume))
            {
                throw new AgendaException("Numele profesorului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(profesor.Prenume))
            {
                throw new AgendaException("Prenumele profesorului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(profesor.Adresa))
            {
                throw new AgendaException("Adresa profesorului trebuie sa fie precizata.");
            }
            if (string.IsNullOrEmpty(profesor.NumarTelefon))
            {
                throw new AgendaException("Numarul de telefon al profesorului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(profesor.Email))
            {
                throw new AgendaException("Email-ul profesorului trebuie sa fie precizat.");
            }
            profesoriDAL.InserareProfesor(profesor);
            ListaProfesori.Add(profesor);
        }

        public void ActualizareProfesor(Profesor profesor)
        {
            if (profesor == null)
            {
                throw new AgendaException("Trebuie selectat un profesor.");
            }
            if (string.IsNullOrEmpty(profesor.Nume))
            {
                throw new AgendaException("Numele profesorului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(profesor.Prenume))
            {
                throw new AgendaException("Prenumele profesorului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(profesor.Adresa))
            {
                throw new AgendaException("Adresa profesorului trebuie sa fie precizata.");
            }
            if (string.IsNullOrEmpty(profesor.NumarTelefon))
            {
                throw new AgendaException("Numarul de telefon al profesorului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(profesor.Email))
            {
                throw new AgendaException("Email-ul profesorului trebuie sa fie precizat.");
            }
            profesoriDAL.ActualizareProfesor(profesor);
        }

        public void StergereProfesor(Profesor profesor)
        {
            if (profesor == null)
            {
                throw new AgendaException("Trebuie selectat un profesor.");
            }
            else
            {
                ClasaDAL clasaDAL = new ClasaDAL();
                if(clasaDAL.ObtineToateClaseleDupaProfesor(profesor).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai Clasele acestui Profesor!");
                }
                MaterieDAL materieDAL = new MaterieDAL();
                if (materieDAL.ObtineToateMateriileDupaProfesor(profesor).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai Materiile acestui Profesor!");
                }
            }
            profesoriDAL.StergereProfesor(profesor);
            ListaProfesori.Remove(profesor);
        }
    }
}
