using System;
using Alura.LeilaoOnline.Core;

namespace ConsoleTestes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console de Testes!");
            LeilaoComVAriosLances();
            LeilaoComUmUnicoLance();

        }

        private static void LeilaoComUmUnicoLance()
        {
            //Arramge
            var leilao = new Leilao("Van Gogh",null);
            var fulano = new Interessada("Fulano", leilao);

            //Act
            leilao.RecebeLance(fulano, 800);
            //Assert
            leilao.TerminaPregao();
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            AssertValues(leilao, valorEsperado, valorObtido);
        }

        private static void AssertValues(Leilao leilao, int valorEsperado, double valorObtido)
        {
            var corAtual=Console.ForegroundColor;

            if (valorObtido == valorEsperado)

            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vencedor [{leilao.Ganhador.Cliente.Nome}] Valor[{leilao.Ganhador.Valor}]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou [{leilao.Ganhador.Valor}]");
            }
            Console.ForegroundColor = corAtual;
        }

        private static void LeilaoComVAriosLances()
        {
            //Arramge
            var leilao = new Leilao("Van Gogh",null);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            //Act
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 1100);
            leilao.RecebeLance(fulano, 1000);
            //Assert
            leilao.TerminaPregao();
            var valorEsperado = 1100;
            var valorObtido = leilao.Ganhador.Valor;
            AssertValues(leilao,valorEsperado, valorObtido);
        }
    }

}
