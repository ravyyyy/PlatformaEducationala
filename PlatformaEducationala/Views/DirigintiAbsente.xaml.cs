using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for DirigintiAbsente.xaml
    /// </summary>
    public partial class DirigintiAbsente : Window
    {
        int diriginteId;
        int elevId;
        int materieId;

        public DirigintiAbsente()
        {
            InitializeComponent();
        }

        public DirigintiAbsente(int diriginteId, int elevId, int materieId)
        {
            InitializeComponent();
            this.diriginteId = diriginteId;
            this.elevId = elevId;
            this.materieId = materieId;
        }
    }
}
