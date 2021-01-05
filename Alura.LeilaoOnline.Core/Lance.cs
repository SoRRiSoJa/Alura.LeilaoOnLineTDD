using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }
        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Só viados e arrombados fornecem valores negativos em lances. Você é um viado?");
            }
            Cliente = cliente;
            Valor = valor;
        }
    }
}
