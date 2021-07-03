using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class Jogo
    {
        const int LINHAS = 3;
        const int COLUNAS = 3;
        public Peca[,] Posicoes { get; set; }

        public Jogo()
        {
            Posicoes = new Peca[LINHAS, COLUNAS];
        }

        public void ImprimirJogo()
        {
            for (int i = 0; i < LINHAS; i++)
            {
                for (int j = 0; j < COLUNAS; j++)
                {
                    if (j == 2)
                    {
                        Console.WriteLine(Posicoes[i, j].ToString());
                    }
                    else
                    {
                        Console.Write(Posicoes[i, j].ToString());
                    }
                }
            }
        }

        public void CriarJogo()
        {

            for (int i = 0; i < LINHAS; i++)
            {
                for (int j = 0; j < COLUNAS; j++)
                {
                    Posicoes[i, j] = new Peca(i, j);
                }
            }
        }

        public void Jogar()
        {
            Console.WriteLine("Nome do primeiro jogador: ");
            var primeiroJogador = Console.ReadLine();

            Console.WriteLine("Nome do segundo jogador: ");
            var segundoJogador = Console.ReadLine();

            var final = false;

            while (!final)
            {

            }
        }
    }
}
