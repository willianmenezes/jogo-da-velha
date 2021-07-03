using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class Circulo : Peca
    {
        public Circulo(int linha, int coluna) : base(linha, coluna)
        {
        }

        public override string Imprimir()
        {
            return "  O  ";
        }
    }
}
