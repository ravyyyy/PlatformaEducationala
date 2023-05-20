using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiPremiantiCorigentiRepetenti.xaml
    /// </summary>
    public partial class DirigintiPremiantiCorigentiRepetenti : Window
    {
        int diriginteId;

        public DirigintiPremiantiCorigentiRepetenti()
        {
            InitializeComponent();
        }

        public DirigintiPremiantiCorigentiRepetenti(int diriginteId)
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
            ObservableCollection<Tuple<string, double>> pairs = new ObservableCollection<Tuple<string, double>>();
            foreach (Elev elev in elevi)
            {
                double medieElev = 0.0;
                int mediiElev = 0;
                foreach (Medie medie in medii)
                {
                    if (elev.IdElev == medie.IdElev)
                    {
                        mediiElev++;
                        medieElev += medie.Nota;
                    }
                }
                Tuple<string, double> pair = new Tuple<string, double>(elev.Nume, medieElev / mediiElev);
                pairs.Add(pair);
            }
            pairs.OrderBy(p => p.Item2);
            if (pairs.Count > 0)
            {
                txtLocul1.Text = pairs[0].Item1;
            }
            if (pairs.Count > 1)
            {
                txtLocul2.Text = pairs[1].Item1;
            }
            if (pairs.Count > 2)
            {
                txtLocul3.Text = pairs[2].Item1;
            }
            if (pairs.Count > 3)
            {
                txtMentiune.Text = pairs[3].Item1;
            }
            ObservableCollection<Tuple<string, string>> eleviCorigenti = new ObservableCollection<Tuple<string, string>>();
            foreach (Medie medie in medii)
            {
                if (medie.Nota < 5)
                {
                    string numeElev = "";
                    foreach (Elev elev in elevi)
                    {
                        if (elev.IdElev == medie.IdElev)
                        {
                            numeElev = elev.Nume;
                            break;
                        }
                    }
                    string numeMaterie = "";
                    foreach (Materie materie in clasaVM.materieBLL.ObtineToateMateriile())
                    {
                        if (materie.IdMaterie == medie.IdMaterie)
                        {
                            numeMaterie = materie.Nume;
                            break;
                        }
                    }
                    Tuple<string, string> pair = new Tuple<string, string>(numeElev, numeMaterie);
                    eleviCorigenti.Add(pair);
                }
            }
            for (int i = 0; i < eleviCorigenti.Count - 1; i++)
            {
                string elevRepetent = eleviCorigenti[i].Item1;
                ObservableCollection<string> materiiRepetente = new ObservableCollection<string>
                {
                    eleviCorigenti[i].Item2
                };
                int nrAparitii = 1;
                for (int j = i + 1; j < eleviCorigenti.Count; j++)
                {
                    if (eleviCorigenti[i].Item1 == eleviCorigenti[j].Item1)
                    {
                        materiiRepetente.Add(eleviCorigenti[j].Item2);
                        nrAparitii++;
                        if (nrAparitii == 3)
                        {
                            break;
                        }
                    }
                }
                if (nrAparitii == 3)
                {
                    for (int j = 0; j < eleviCorigenti.Count; j++)
                    {
                        if (eleviCorigenti[j].Item1 == elevRepetent)
                        {
                            eleviCorigenti.RemoveAt(j);
                            j--;
                        }
                    }
                    txtRepetenti.Text += elevRepetent + " -> ";
                    foreach (string materie in materiiRepetente)
                    {
                        txtRepetenti.Text += materie + ',';
                    }
                }
            }
            foreach (Tuple<string, string> pair in eleviCorigenti)
            {
                txtCorigenti.Text += pair.Item1 + " -> " + pair.Item2 + '\n';
            }
        }
    }
}
