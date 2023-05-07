using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class MaterieBLL
    {
        public ObservableCollection<Materie> ListaMaterii { get; set; }

        MaterieDAL materieDAL = new MaterieDAL();

        public MaterieBLL()
        {
            ListaMaterii = new ObservableCollection<Materie>();
        }

        public ObservableCollection<Materie> ObtineToateMateriile()
        {
            return materieDAL.ObtineToateMateriile();
        }

        public void ObtineToateMateriileDupaProfesor(Profesor profesor)
        {
            ListaMaterii.Clear();
            var materii = materieDAL.ObtineToateMateriileDupaProfesor(profesor);
            foreach (var materie in materii)
            {
                ListaMaterii.Add(materie);
            }
        }

        public void InserareMaterie(Materie materie)
        {
            if (string.IsNullOrEmpty(materie.Nume))
            {
                throw new AgendaException("Numele materiei trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(materie.IdProfesor.ToString()))
            {
                throw new AgendaException("ID-ul profesurului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(materie.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu trebuie precizat.");
            }
            materieDAL.InserareMaterie(materie);
            ListaMaterii.Add(materie);
        }

        public void ActualizareMaterie(Materie materie)
        {
            if (materie == null)
            {
                throw new AgendaException("Trebuie selectata o materie.");
            }
            if (string.IsNullOrEmpty(materie.Nume))
            {
                throw new AgendaException("Numele materiei trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(materie.IdProfesor.ToString()))
            {
                throw new AgendaException("ID-ul profesurului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(materie.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu trebuie precizat.");
            }
            materieDAL.ActualizareMaterie(materie);
        }

        public void StergereMaterie(Materie materie)
        {
            if (materie == null)
            {
                throw new AgendaException("Trebuie selectata o materie.");
            }
            else
            {
                AbsentaDAL absentaDAL = new AbsentaDAL();
                if (absentaDAL.ObtineToateAbsenteleDupaMaterie(materie).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai absentele pentru materia cu ID-ul " + materie.IdMaterie);
                }
                //verificare in medie
                NotaDAL notaDAL = new NotaDAL();
                if (notaDAL.ObtineToateNoteleDupaMaterie(materie).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai notele pentru materia cu ID-ul " + materie.IdMaterie);
                }
            }
            materieDAL.StergereMaterie(materie);
            ListaMaterii.Remove(materie);
        }
    }
}
