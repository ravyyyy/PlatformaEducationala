using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiAbsenteNemotivate.xaml
    /// </summary>
    public partial class DirigintiAbsenteNemotivate : Window
    {
        int diriginteId;
        int elevId;
        int materieId;

        public DirigintiAbsenteNemotivate()
        {
            InitializeComponent();
        }

        public DirigintiAbsenteNemotivate(int diriginteId, int elevId, int materieId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            this.elevId = elevId;
            this.materieId = materieId;
        }
    }
}
