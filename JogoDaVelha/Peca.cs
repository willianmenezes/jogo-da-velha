namespace JogoDaVelha
{
    public class Peca
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Peca(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public virtual string Imprimir()
        {
            return "  -  ";
        }

        public override string ToString()
        {
            return Imprimir();
        }
        public override bool Equals(object obj)
        {
            var objeCompare = obj as Peca;
            if (objeCompare == null)
                return false;

            return objeCompare.ToString() == this.ToString();
        }
    }
}
