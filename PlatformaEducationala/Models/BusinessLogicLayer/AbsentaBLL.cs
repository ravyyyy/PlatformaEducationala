﻿using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class AbsentaBLL
    {
        public ObservableCollection<Absenta> ListaAbsente { get; set; }

        AbsentaDAL absentaDAL = new AbsentaDAL();

        public AbsentaBLL()
        {
            ListaAbsente = new ObservableCollection<Absenta>();
        }

        public ObservableCollection<Absenta> ObtineToateAbsentele()
        {
            return absentaDAL.ObtineToateAbsentele();
        }

        public ObservableCollection<Absenta> ObtineToateAbsenteleDupaMaterieDupaProfesor(int idProfesor)
        {
            return absentaDAL.ObtineToateAbsenteleDupaMaterieDupaProfesor(idProfesor);
        }

        public void InserareAbsenta(Absenta absenta)
        {
            if (string.IsNullOrEmpty(absenta.IdMaterie.ToString()))
            {
                throw new AgendaException("Id-ul materiei la care este absenta trebuie precizat.");
            }
            if (string.IsNullOrEmpty(absenta.IdElev.ToString()))
            {
                throw new AgendaException("Id-ul elevului care a primit absenta trebuie precizat.");
            }
            absentaDAL.InserareAbsenta(absenta);
            ListaAbsente.Add(absenta);
        }

        public void ActualizareAbsenta(Absenta absenta)
        {
            if (absenta == null)
            {
                throw new AgendaException("Trebuie selectata o absenta.");
            }
            if (string.IsNullOrEmpty(absenta.IdMaterie.ToString()))
            {
                throw new AgendaException("Id-ul materiei la care este absenta trebuie precizat.");
            }
            if (string.IsNullOrEmpty(absenta.IdElev.ToString()))
            {
                throw new AgendaException("Id-ul elevului care a primit absenta trebuie precizat.");
            }
            absentaDAL.ActualizareAbsenta(absenta);
        }

        public void StergereAbsenta(Absenta absenta)
        {
            if (absenta == null)
            {
                throw new AgendaException("Trebuie selectata o absenta.");
            }
            absentaDAL.StergereAbsenta(absenta);
            ListaAbsente.Remove(absenta);
        }

        public void ObtineToateAbsenteleDupaElev(Elev elev)
        {
            ListaAbsente.Clear();
            var absente = absentaDAL.ObtineToateAbsenteleDupaElev(elev);
            foreach (var absenta in absente)
            {
                ListaAbsente.Add(absenta);
            }
        }

        public void ObtineToateAbsenteleDupaMaterie(Materie materie)
        {
            ListaAbsente.Clear();
            var absente = absentaDAL.ObtineToateAbsenteleDupaMaterie(materie);
            foreach (var absenta in absente)
            {
                ListaAbsente.Add(absenta);
            }
        }
    }
}
