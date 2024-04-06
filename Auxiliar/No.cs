namespace Gourmet.Auxiliar
{
    public class No(string valor)
    {
        public string Valor { get; set; } = valor;
        public No Esquerdo { get; set; } = null;
        public No Direito { get; set; } = null;

    }
}
