using System.Collections.Generic;
using System.Windows;

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
                KeyValuePair<string, int>? pair = profesoriCB.SelectedItem as KeyValuePair<string, int>?;
                if (pair is KeyValuePair<string, int> kv)
                {
                    ProfesoriAbsente profesoriAbsente = new ProfesoriAbsente(kv.Value);
                    profesoriAbsente.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un profesor!", "Warning", MessageBoxButton.OK);
            }
        }

        private void profesoriNoteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (profesoriCB.SelectedItem != null)
            {
                KeyValuePair<string, int>? pair = profesoriCB.SelectedItem as KeyValuePair<string, int>?;
                if (pair is KeyValuePair<string, int> kv)
                {
                    ProfesoriNote profesoriNote = new ProfesoriNote(kv.Value);
                    profesoriNote.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un profesor!", "Warning", MessageBoxButton.OK);
            }
        }

        private void profesoriMaterialeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (profesoriCB.SelectedItem != null)
            {
                KeyValuePair<string, int>? pair = profesoriCB.SelectedItem as KeyValuePair<string, int>?;
                if (pair is KeyValuePair<string, int> kv)
                {
                    ProfesoriMateriale profesoriMateriale = new ProfesoriMateriale(kv.Value);
                    profesoriMateriale.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un profesor!", "Warning", MessageBoxButton.OK);
            }
        }

        private void profesoriMediiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (profesoriCB.SelectedItem != null)
            {
                KeyValuePair<string, int>? pair = profesoriCB.SelectedItem as KeyValuePair<string, int>?;
                if (pair is KeyValuePair<string, int> kv)
                {
                    ProfesoriMedii profesoriMedii = new ProfesoriMedii(kv.Value);
                    profesoriMedii.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un profesor!", "Warning", MessageBoxButton.OK);
            }
        }
    }
}
