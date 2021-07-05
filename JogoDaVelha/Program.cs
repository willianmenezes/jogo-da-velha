using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            new Jogo()
            .CriarJogo()
            .ImprimirJogo()
            .Jogar();

            Console.ReadLine();
        }
    }
}
