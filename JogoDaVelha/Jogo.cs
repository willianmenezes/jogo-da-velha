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
        public Peca[,] Pecas { get; set; }

        public Jogo()
        {
            Pecas = new Peca[LINHAS, COLUNAS];
        }

        public Jogo ImprimirJogo()
        {
            for (int i = 0; i < LINHAS; i++)
            {
                for (int j = 0; j < COLUNAS; j++)
                {
                    if (j == 2)
                    {
                        Console.WriteLine(Pecas[i, j].ToString());
                    }
                    else
                    {
                        Console.Write(Pecas[i, j].ToString());
                    }
                }
            }

            return this;
        }

        public Jogo CriarJogo()
        {

            for (int i = 0; i < LINHAS; i++)
            {
                for (int j = 0; j < COLUNAS; j++)
                {
                    Pecas[i, j] = new Peca(i, j);
                }
            }

            return this;
        }

        public Peca GerarPecaNaPosicao(int linha, int coluna, TipoPeca tipoPeca)
        {
            switch (tipoPeca)
            {
                case TipoPeca.Circulo:
                    return new Circulo(linha, coluna);
                case TipoPeca.Cruzado:
                    return new Cruzado(linha, coluna);
                default:
                    return new Peca(linha, coluna);
            }
        }

        public bool PosicaoLivre(int linha, int coluna)
        {
            return Pecas[linha, coluna].ToString() == "  -  ";
        }

        public bool ColocarPecaNaPosicao(int linha, int coluna, TipoPeca tipoPeca)
        {
            var peca = GerarPecaNaPosicao(linha, coluna, tipoPeca);

            var posicaoLivre = PosicaoLivre(linha, coluna);

            if (!posicaoLivre) return false;

            Pecas[linha, coluna] = peca;
            return true;
        }

        public void ImprimirJogada(Jogador jogador)
        {
            Console.WriteLine($"Jogador  {jogador.Nome} escolha uma posição: \n[0,0] - [0,1] - [0,2] \n[1,0] - [1,1] - [1,2]\n[2,0] - [2,1] - [2,2] ");
        }

        public void Jogar()
        {
            Console.Write("Nome do primeiro jogador: ");
            var nomePrimeiroJogador = Console.ReadLine();
            var primeiroJogador = new Jogador(nomePrimeiroJogador, TipoPeca.Circulo);

            Console.Write("Nome do segundo jogador: ");
            var nomeSegundoJogador = Console.ReadLine();
            var segundoJogador = new Jogador(nomeSegundoJogador, TipoPeca.Cruzado);
            var final = false;
            var rodada = true;

            while (!final)
            {
                Console.Clear();
                ImprimirJogo();

                if (rodada)
                {
                    var resultadoJogada = RealizarJogada(primeiroJogador);
                    if (resultadoJogada)
                    {
                        rodada = !rodada;
                    }

                }
                else
                {
                    var resultadoJogada = RealizarJogada(segundoJogador);
                    if (resultadoJogada)
                    {
                        rodada = !rodada;
                    }
                }

            }
        }

        private bool RealizarJogada(Jogador jogador)
        {
            ImprimirJogada(jogador);
            var posicoesJogador = Console.ReadLine().Replace(" ", "").Split(",");
            return ColocarPecaNaPosicao(int.Parse(posicoesJogador[0]), int.Parse(posicoesJogador[1]), jogador.TipoPeca);
        }
    }
}
