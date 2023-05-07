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
    public class NotaBLL
    {
        public ObservableCollection<Nota> ListaNote { get; set; }

        NotaDAL notaDAL = new NotaDAL();

        public NotaBLL()
        {
            ListaNote = new ObservableCollection<Nota>();
        }

        public ObservableCollection<Nota> ObtineToateNotele()
        {
            return notaDAL.ObtineToateNotele();
        }

        public void ObtineToateNoteleDupaMaterie(Materie materie)
        {
            ListaNote.Clear();
            var note = notaDAL.ObtineToateNoteleDupaMaterie(materie);
            foreach (var nota in note)
            {
                ListaNote.Add(nota);
            }
        }

        public void InserareNota(Nota nota)
        {
            if (string.IsNullOrEmpty(nota.IdMaterie.ToString()))
            {
                throw new AgendaException("ID-ul materiei notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(nota.Valoare.ToString()))
            {
                throw new AgendaException("Valoarea notei trebuie precizata.");
            }
            if (string.IsNullOrEmpty(nota.Semestru.ToString()))
            {
                throw new AgendaException("Semestrul notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(nota.IdElev.ToString()))
            {
                throw new AgendaException("ID-ul elevului trebuie precizat.");
            }
            notaDAL.InserareNota(nota);
            ListaNote.Add(nota);
        }

        public void ActualizareNota(Nota nota)
        {
            if (nota == null)
            {
                throw new AgendaException("Trebuie selectat o nota.");
            }
            if (string.IsNullOrEmpty(nota.IdMaterie.ToString()))
            {
                throw new AgendaException("ID-ul materiei notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(nota.Valoare.ToString()))
            {
                throw new AgendaException("Valoarea notei trebuie precizata.");
            }
            if (string.IsNullOrEmpty(nota.Semestru.ToString()))
            {
                throw new AgendaException("Semestrul notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(nota.IdElev.ToString()))
            {
                throw new AgendaException("ID-ul elevului trebuie precizat.");
            }
            notaDAL.ActualizareNota(nota);
        }

        public void StergereNota(Nota nota)
        {
            if (nota == null)
            {
                throw new AgendaException("Trebuie selectat o nota.");
            }
            notaDAL.StergereNota(nota);
            ListaNote.Remove(nota);
        }
    }
}
