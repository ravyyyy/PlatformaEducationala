using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.TextFormatting;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiIerarhie.xaml
    /// </summary>
    public partial class DirigintiIerarhie : Window
    {
        int diriginteId;

        public DirigintiIerarhie()
        {
            InitializeComponent();
        }

        public DirigintiIerarhie(int diriginteId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            ClasaVM clasaVM = DataContext as ClasaVM;
            Clasa clasa = new Clasa();
            foreach (Clasa clasaAux in clasaVM.ListaClase)
            {
                if (clasaAux.IdDiriginte == diriginteId)
                {
                    clasa = clasaAux;
                    break;
                }
            }
            ObservableCollection<Elev> elevi = new ObservableCollection<Elev>();
            foreach (Elev elev in clasaVM.elevBLL.ObtineTotiElevii())
            {
                if (elev.IdClasa == clasa.IdClasa && !elevi.Contains(elev))
                {
                    elevi.Add(elev);
                }
            }
            ObservableCollection<Medie> medii = new ObservableCollection<Medie>();
            foreach (Medie medie in clasaVM.medieBLL.ObtineToateMediile())
            {
                if (!medii.Contains(medie))
                {
                    foreach (Elev elev in elevi)
                    {
                        if (elev.IdElev == medie.IdElev)
                        {
                            medii.Add(medie);
                        }
                    }
                }
            }
            //medii.OrderBy(m => m.Nota);
            for (int i = 0; i < medii.Count - 1; i++)
            {
                for (int j = i + 1; j < medii.Count; j++)
                {
                    if (medii[i].Nota < medii[j].Nota)
                    {
                        (medii[j], medii[i]) = (medii[i], medii[j]);
                    }
                }
            }
            string sortare = "";
            ObservableCollection<Tuple<string, double>> pairs = new ObservableCollection<Tuple<string, double>>();
            foreach (Elev elev in elevi)
            {
                Tuple<string, double> pair = new Tuple<string, double>(elev.Nume, 0.0);
                if (!pairs.Contains(pair))
                {
                    pairs.Add(pair);
                }
            }
            foreach (Tuple<string, double> pair in pairs)
            {
                double medieElev = 0.0;
                int numarMedii = 0;
                int idElev = -1;
                foreach (Elev elev in elevi)
                {
                    if (elev.Nume == pair.Item1)
                    {
                        idElev = (int)elev.IdElev;
                    }
                }
                foreach (Medie medie in medii)
                {
                    if (medie.IdElev == idElev)
                    {
                        numarMedii++;
                        medieElev += medie.Nota;
                    }
                }
                sortare += pair.Item1 + " -> " + (medieElev / numarMedii) + '\n';
            }
            txtSortare.Text = sortare;
        }
    }
}
