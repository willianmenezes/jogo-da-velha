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
            Console.Clear();
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

            for (var i = 0; i < LINHAS; i++)
            {
                for (var j = 0; j < COLUNAS; j++)
                {
                    Pecas[i, j] = new Peca(i, j);
                }
            }

            return this;
        }

        public Peca GerarPecaNaPosicao(int linha, int coluna, TipoPeca tipoPeca)
        {
            return tipoPeca switch
            {
                TipoPeca.Circulo => new Circulo(linha, coluna),
                TipoPeca.Cruzado => new Cruzado(linha, coluna),
                _ => new Peca(linha, coluna)
            };
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

        public bool VerificarVelha()
        {
            var pecasDefault = new List<Peca>();

            for (var i = 0; i < LINHAS; i++)
            {
                for (var j = 0; j < COLUNAS; j++)
                {
                    if (!Pecas[i, j].Equals(new Peca(0, 0)))
                    {
                        pecasDefault.Add(Pecas[i, j]);
                    }
                }
            }

            return pecasDefault.Count == (LINHAS * COLUNAS);
        }

        public bool VerificarVencedorLinhas()
        {
            var resultado = false;
            for (var i = 0; i < LINHAS; i++)
            {
                resultado = Pecas[i, 0].Equals(Pecas[i, 1]) && Pecas[i, 0].Equals(Pecas[i, 2]) && !Pecas[i, 0].Equals(new Peca(0, 0));

                if (resultado)
                {
                    return true;
                }
            }

            return false;
        }

        public bool VerificarVencedorColunas()
        {
            var resultado = false;
            for (int i = 0; i < LINHAS; i++)
            {
                resultado = Pecas[0, i].Equals(Pecas[1, i]) && Pecas[0, i].Equals(Pecas[2, i]) && !Pecas[0, i].Equals(new Peca(0, 0));

                if (resultado)
                {
                    return true;
                }
            }

            return false;
        }

        public bool VerificarVencedorDiagonal()
        {
            var diagonalPrimaria = (Pecas[0, 0].Equals(Pecas[1, 1]) && Pecas[0, 0].Equals(Pecas[2, 2]) && !Pecas[1, 1].Equals(new Peca(0, 0))) == true ? true : false;
            var diagonalSecundaria = (Pecas[2, 0].Equals(Pecas[1, 1]) && Pecas[2, 0].Equals(Pecas[0, 2]) && !Pecas[1, 1].Equals(new Peca(0, 0))) == true ? true : false;

            return diagonalPrimaria || diagonalSecundaria;
        }

        public bool VerificarVencedor()
        {
            return VerificarVencedorLinhas() || VerificarVencedorColunas() || VerificarVencedorDiagonal();
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

                ImprimirJogo();

                if (rodada)
                {
                    var resultadoJogada = RealizarJogada(primeiroJogador);
                    if (resultadoJogada)
                    {
                        rodada = false;
                    }

                }
                else
                {
                    var resultadoJogada = RealizarJogada(segundoJogador);
                    if (resultadoJogada)
                    {
                        rodada = true;
                    }
                }

                if (VerificarVelha())
                {
                    final = true;
                    ImprimirJogo();
                    Console.WriteLine("Jogo empatado, boa sorte na proxima partida");
                }

                if (VerificarVencedor())
                {
                    var nomeVencedor = !rodada ? nomePrimeiroJogador : nomeSegundoJogador;
                    final = true;
                    ImprimirJogo();
                    Console.WriteLine($"Final de jogo, o jogador {nomeVencedor} foi o vencedor");
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
