using System.Windows;

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
        }
    }
}
