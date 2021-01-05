using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnLine.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo() 
        {
            //Arranje
            var valorNegativo = -100;
            //Assert
            var exception = Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo));
            Assert.Equal("Só viados e arrombados fornecem valores negativos em lances. Você é um viado?", exception.Message);
        }
    }
}
