using System;
using System.IO;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for Materiale.xaml
    /// </summary>
    public partial class Materiale : Window
    {
        public Materiale()
        {
            InitializeComponent();
        }

        private void IncarcaFisier_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                byte[] fileData = File.ReadAllBytes(fileName);
            }
        }
    }
}
