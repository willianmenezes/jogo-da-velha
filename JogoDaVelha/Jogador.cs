namespace JogoDaVelha
{
    public class Jogador
    {
        public Jogador(string nome, TipoPeca tipoPeca)
        {
            Nome = nome;
            TipoPeca = tipoPeca;
        }

        public string Nome { get; set; }
        public TipoPeca TipoPeca { get; set; }
    }

    public enum TipoPeca
    {
        Circulo,
        Cruzado
    }
}
