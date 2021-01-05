using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnLine.Tests
{
    public class LeilaoTestes
    {
        
        
        [Theory]
        [InlineData(new double[] { 800, 900, 1000, 1200 })]
        [InlineData(new double[] { 800, 900, 1000, 990 })]
        [InlineData(new double[] { 800 })]
        public void LeilaoComVAriosLances(double[] ofertas)
        {
            //Arramge
            var valorLanceVencedor = ofertas.Max();
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            
            //Act
            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(fulano, oferta);
            }
            //Assert
            leilao.TerminaPregao();
            var valorEsperado = valorLanceVencedor;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorLanceVencedor, valorObtido);
        }
        
        [Fact]
        public void LeilaoSemLances()
        {
            //Arramge
            var leilao = new Leilao("Van Gogh");

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }

}
