﻿using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ProfesoriAbsente.xaml
    /// </summary>
    public partial class ProfesoriAbsente : Window
    {
        private int profesorId;
        private ObservableCollection<Absenta> absente = new ObservableCollection<Absenta>();

        public ProfesoriAbsente()
        {
            InitializeComponent();
        }

        public ProfesoriAbsente(int profesorId)
        {
            InitializeComponent();
            this.profesorId = profesorId;
            AbsentaVM absentaVM = this.DataContext as AbsentaVM;
            absente = absentaVM.GetListaAbsenteProfesori(profesorId);
            absenteDG.ItemsSource = absente;
            Profesor profesor = absentaVM.profesorBLL.ObtineProfesorDupaId(profesorId);
            absentaVM.materieBLL.ObtineToateMateriileDupaProfesor(profesor);
            ObservableCollection<KeyValuePair<string, int>> materii = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (Materie materie in absentaVM.materieBLL.ListaMaterii)
            {
                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(materie.Nume, (int)materie.IdMaterie);
                if (!materii.Contains(pair))
                {
                    materii.Add(pair);
                }
            }
            txtIdMaterie.ItemsSource = materii;
        }
    }
}
