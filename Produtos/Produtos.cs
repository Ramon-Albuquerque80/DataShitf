namespace DataShift.Produtos
{
    public class Produtos
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public decimal PRECO { get; set; }
        public string TIPO { get; set; }
        public string PERECIVEL { get; set; }

        public Produtos() { }

        public Produtos(string nome, decimal preco, string tipo, string perecivel)
        {
            this.NOME = nome;
            this.PRECO = preco;
            this.TIPO = tipo;
            this.PERECIVEL = perecivel;
        }
    }
}