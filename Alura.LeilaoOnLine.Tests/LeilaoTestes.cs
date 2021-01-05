using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnLine.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public  void LeilaoComVAriosLances()
        {
            //Arramge
            int valorLanceVencedor = 11000;
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            //Act
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, valorLanceVencedor);
            leilao.RecebeLance(fulano, 1000);
            //Assert
            leilao.TerminaPregao();
            var valorEsperado = valorLanceVencedor;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(new decimal(valorLanceVencedor), new decimal(valorObtido));
        }
        [Fact]
        public void LeilaoComUmLance()
        {
            //Arramge
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            int valorLance = 800;
            //Act
            leilao.RecebeLance(fulano, valorLance);
            //Assert
            leilao.TerminaPregao();
            var valorEsperado = valorLance;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(new decimal(valorLance), new decimal(valorObtido));
        }
    }
    
}
