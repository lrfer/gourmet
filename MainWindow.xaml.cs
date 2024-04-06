using Gourmet.Auxiliar;
using System.Windows;

namespace Gourmet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArvoreBinaria ArvoreBinaria = new ArvoreBinaria();
        //Contando para começar a pergunta a partir de pratos que nao tem na lista ainda
        public MainWindow()
        {
            InserirNos();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            PerguntarNo(ArvoreBinaria.Raiz, null);
        }


        private void PerguntarNo(No no, No? anterior)
        {
            MessageBoxResult result = MessageBox.Show("O prato que você pensou é " + no.Valor + "?", "Jogo Gourmet", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes && no.Esquerdo == null)
            {
                MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (result == MessageBoxResult.Yes && no.Esquerdo != null)
            {
                //Perguntar o no a esquerda
                PerguntarNo(no.Esquerdo, no);
            }
            else if (result == MessageBoxResult.No && no.Direito != null)
            {
                //Perguntar o no a direita
                PerguntarNo(no.Direito, no);
            }
            else if (result == MessageBoxResult.No && no.Direito == null)
            {
                //Perguntar o prato
                PerguntarPrato(no, anterior);
            }


        }

        private void PerguntarPrato(No atual, No anterior)
        {
            DesistoWindow desistoWindow = new DesistoWindow(atual, anterior, this.ArvoreBinaria.Raiz);
            desistoWindow.ShowDialog();

            if (desistoWindow.DialogResult == true)
            {
                //Renicia o jogo
                PerguntarNo(ArvoreBinaria.Raiz, null);
            }
        }

        private void InserirNos()
        {
            //Inserindo os nós, começando com a raiz massa
            ArvoreBinaria.Raiz = new No("massa");

            //Inserindo os nós filhos
            ArvoreBinaria.Raiz.Esquerdo = new No("Lasanha");

            ArvoreBinaria.Raiz.Direito = new No("Bolo de Chocolate");
        }
    }
}