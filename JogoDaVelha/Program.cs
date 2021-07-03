using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            var jogo = new Jogo();
            jogo.CriarJogo();
            jogo.ImprimirJogo();
            Console.ReadLine();
        }
    }
}
