using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnLine.Core;
using Xunit;

namespace Alura.LeilaoOnLine.Tests
{
    public class LeilaoTerminaPregao
    {
     
        [Theory]
        [InlineData(1250,1200,new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorEsperado,double valorDestino,double[] ofertas) 
        {
            //Arramge
            var modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            var leilao = new Leilao("Van Gogh",modalidade,valorDestino);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            //Act
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else 
                {
                    leilao.RecebeLance(maria, ofertas[i]);
                }
            }
            
            //Assert
            leilao.TerminaPregao();
            
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }   
        

        [Theory]
        [InlineData(new double[] { 800, 900, 1000, 1200 })]
        [InlineData(new double[] { 800, 900, 1000, 990 })]
        [InlineData(new double[] { 800 })]
        public void RetornaMaiorDadoLeilaoComPeloMenosUmLance(double[] ofertas)
        {
            //Arramge
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var valorLanceVencedor = 800;
            var leilao = new Leilao("Van Gogh",modalidade);
            var fulano = new Interessada("Fulano", leilao);

            //Act
            leilao.IniciaPregao();
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
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado() 
        {
            //Arramge
            var leilao = new Leilao("Van Gogh",null);

            //Act
            //Assert
            var exception=Assert.Throws<System.InvalidOperationException>(() => leilao.TerminaPregao());
            Assert.Equal("Inicie essa buceta! Utilize o método  IniciaPrgao()!", exception.Message);
        }

        [Fact]
        public void RetornaZeroLeilaoSemLances()
        {
            //Arramge
            var leilao = new Leilao("Van Gogh",null);

            //Act
            leilao.IniciaPregao();
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }

}
