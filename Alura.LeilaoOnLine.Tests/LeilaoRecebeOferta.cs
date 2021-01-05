using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnLine.Tests
{
    public class LeilaoRecebeOferta
    {

        [Fact]
        public void NaoAceitaProximoLancesDadoMesmoClienteRealizouUltimaOferta() 
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            //Act
            leilao.RecebeLance(fulano, 1000);

            //Assert
            
            var qtdEsperada = 1;
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }
        [Theory]
        [InlineData(1, new double[] { 1000, 1200,1400,1300 })]
        [InlineData(1,new double[] {800,900})]
        public void NaoPermiteNovosLancesDadosLeilaoFinalizado(int qtdEsperada, double[] ofertas) 
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano",leilao);
            
            leilao.IniciaPregao();
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            leilao.TerminaPregao();
            
            //Act
            
            leilao.RecebeLance(fulano, 1000);
            
            //Assert
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObtida);
        }
    }
}
