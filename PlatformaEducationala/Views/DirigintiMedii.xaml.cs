using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiMedii.xaml
    /// </summary>
    public partial class DirigintiMedii : Window
    {
        int diriginteId;
        int elevId;

        public DirigintiMedii()
        {
            InitializeComponent();
        }

        public DirigintiMedii(int diriginteId, int elevId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            this.elevId = elevId;
        }
    }
}
