using System.Windows;
using Gourmet.Auxiliar;

namespace Gourmet
{


    public partial class DesistoWindow : Window
    {
        public string Prato { get; private set; }
        public No Anterior { get; set; }
        public No Atual { get; set; }
        public No Raiz { get; set; }

        public DesistoWindow(No atual, No anterior, No raiz)
        {
            this.Prato = "";
            this.Anterior = anterior;
            this.Atual = atual;
            this.Raiz = raiz;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Prato = txtResposta.Text;
            var adjetivo = new CompleteWindow(Prato, Atual.Valor);
            adjetivo.ShowDialog();
            var NoNovoPrato = new No(Prato);

            var NoAdjetivo = new No(adjetivo.Resposta);
            NoAdjetivo.Esquerdo = NoNovoPrato;

            NoAdjetivo.Direito = Atual;

            if (Raiz.Direito == Atual)
            {
                Raiz.Direito = NoAdjetivo;
            }
            else if (Raiz.Esquerdo == Atual)
            {
                Raiz.Esquerdo = NoAdjetivo;
            }
            else if (Anterior.Esquerdo == Atual)
            {
                Anterior.Esquerdo = NoAdjetivo;
            }
            else if (Anterior.Direito == Atual)
            {
                Anterior.Direito = NoAdjetivo;
            }
            else
            {
                Anterior.Direito = NoAdjetivo;
            }

            DialogResult = true;

            Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Fechar a janela sem armazenar a resposta
            DialogResult = false;
            Close();
        }
    }
}
