using PlatformaEducationala.Models.EntityLayer;
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
    /// Interaction logic for ProfesoriMedii.xaml
    /// </summary>
    public partial class ProfesoriMedii : Window
    {
        private int profesorId;
        private ObservableCollection<Elev> elevi = new ObservableCollection<Elev>();

        public ProfesoriMedii()
        {
            InitializeComponent();
        }

        public ProfesoriMedii(int profesorId)
        {
            InitializeComponent();
            this.profesorId = profesorId;
            ElevVM elevVM = this.DataContext as ElevVM;
            elevi = elevVM.GetListaEleviProfesori(profesorId);
            eleviDG.ItemsSource = elevi;
        }
    }
}
