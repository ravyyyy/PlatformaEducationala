﻿using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class AbsentaVM : BasePropertyChanged
    {
        AbsentaBLL absentaBLL = new AbsentaBLL();
        MaterieBLL materieBLL = new MaterieBLL();
        ElevBLL elevBLL = new ElevBLL();

        public ObservableCollection<int> ListaIdMaterie { get; set; }
        public ObservableCollection<int> ListaIdElev { get; set; }

        private ObservableCollection<int> GetListaIdMaterii()
        {
            ObservableCollection<int> listaIdClase = new ObservableCollection<int>();
            foreach (Materie materie in materieBLL.ObtineToateMateriile())
            {
                if (!listaIdClase.Contains((int)materie.IdMaterie))
                {
                    listaIdClase.Add((int)materie.IdMaterie);
                }
            }
            return listaIdClase;
        }

        private ObservableCollection<int> GetListaIdElevi()
        {
            ObservableCollection<int> listaIdClase = new ObservableCollection<int>();
            foreach (Elev elev in elevBLL.ObtineTotiElevii())
            {
                if (!listaIdClase.Contains((int)elev.IdElev))
                {
                    listaIdClase.Add((int)elev.IdElev);
                }
            }
            return listaIdClase;
        }

        #region Data Members

        public ObservableCollection<Absenta> ListaAbsente
        {
            get => absentaBLL.ListaAbsente;
            set => absentaBLL.ListaAbsente = value;
        }

        #endregion

        public AbsentaVM()
        {
            ListaAbsente = absentaBLL.ObtineToateAbsentele();
            ListaIdMaterie = GetListaIdMaterii();
            ListaIdElev = GetListaIdElevi();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Absenta>(absentaBLL.InserareAbsenta);
                }
                return comandaInserare;
            }
        }

        private ICommand comandaStergere;
        public ICommand ComandaStergere
        {
            get
            {
                if (comandaStergere == null)
                {
                    comandaStergere = new RelayCommand<Absenta>(absentaBLL.StergereAbsenta);
                }
                return comandaStergere;
            }
        }

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Absenta>(absentaBLL.ActualizareAbsenta);
                }
                return comandaActualizare;
            }
        }

        #endregion
    }
}
