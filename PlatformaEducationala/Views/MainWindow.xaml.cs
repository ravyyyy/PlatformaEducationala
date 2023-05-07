using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Data.SqlClient;
using System.Windows;
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
    }
}
