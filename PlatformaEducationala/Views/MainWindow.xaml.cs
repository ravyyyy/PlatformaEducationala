using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void specializariMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Specializari specializari = new Specializari();
            specializari.Show();
        }

        private void profesoriMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Profesori profesori = new Profesori();
            profesori.Show();
        }

        private void materiiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Materii materii = new Materii();
            materii.Show();
        }

        private void claseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clase clase = new Clase();
            clase.Show();
        }

        private void eleviMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Elevi elevi = new Elevi();
            elevi.Show();
        }

        private void absenteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Absente absente = new Absente();
            absente.Show();
        }

        private void noteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note();
            note.Show();
        }

        private void mediiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Medii medii = new Medii();
            medii.Show();
        }

        private void materialeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Materiale materiale = new Materiale();
            materiale.Show();
        }

        private void elevAnStudiuSpecializareMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElevAnStudiuSpecializare elevAnStudiuSpecializare = new ElevAnStudiuSpecializare();
            elevAnStudiuSpecializare.Show();
        }

        private void profesoriAbsenteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (profesoriCB.SelectedItem != null)
            {
                ProfesoriAbsente profesoriAbsente = new ProfesoriAbsente((int)profesoriCB.SelectedItem);
                profesoriAbsente.Show();
            }
            else
            {
                MessageBox.Show("Trebuie selectat un profesor!", "Warning", MessageBoxButton.OK);
            }
        }
    }
}
