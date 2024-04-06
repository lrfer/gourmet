using System.Windows;

namespace Gourmet
{

    public partial class CompleteWindow : Window
    {
        public string Resposta { get; private set; }
        public string Pergunta { get; }
        public CompleteWindow(string prato, string prato2)
        {

            InitializeComponent();
            this.Resposta = "";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Pergunta = $"{prato} é _________ mas {prato2} não.";
            DataContext = this;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            Resposta = txtResposta.Text;
            DialogResult = true;
            Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = false;
            Close();
        }
    }
}
