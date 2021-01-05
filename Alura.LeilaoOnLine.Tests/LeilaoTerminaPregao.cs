﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnLine.Tests
{
    public class LeilaoTerminaPregao
    {
        
        
        [Theory]
        [InlineData(new double[] { 800, 900, 1000, 1200 })]
        [InlineData(new double[] { 800, 900, 1000, 990 })]
        [InlineData(new double[] { 800 })]
        public void RetornaMaiorDadoLeilaoComPeloMenosUmLance(double[] ofertas)
        {
            //Arramge
            var valorLanceVencedor = 800;
            var leilao = new Leilao("Van Gogh");
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
            var leilao = new Leilao("Van Gogh");

            //Act
            //Assert
            var exception=Assert.Throws<System.InvalidOperationException>(() => leilao.TerminaPregao());
            Assert.Equal("Inicie essa buceta! Utilize o método  IniciaPrgao()!", exception.Message);
        }

        [Fact]
        public void RetornaZeroLeilaoSemLances()
        {
            //Arramge
            var leilao = new Leilao("Van Gogh");

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
