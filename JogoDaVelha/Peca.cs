using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var instance = obj as Peca;
            if (instance == null) return false;
            return instance.Linha == Linha && instance.Coluna == Coluna;
        }
    }
}
