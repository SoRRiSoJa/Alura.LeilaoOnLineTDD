using Alura.LeilaoOnLine.Core;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        public double ValorDestino { get; }
        public EstadoLeilao Estado { get; private set; }
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        private Interessada _ultimoCLiente;
        public IModalidadeAvaliacao Modalidade { get; set; }
        public Leilao(string peca,IModalidadeAvaliacao modalidade,double valorDestino=0)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesPregao;
            ValorDestino=valorDestino;
            Modalidade = modalidade??new MaiorValor();
        }
        public Leilao()
        {

        }
        public void RecebeLance(Interessada cliente, double valor)
        {
            if (ValidarLance(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCLiente = cliente;
            }
        }

        public void IniciaPregao()
        {
            Estado = (Estado != EstadoLeilao.LeilaoFinalizado) ? EstadoLeilao.LeilaoEmAndamento : Estado;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new InvalidOperationException("Inicie essa buceta! Utilize o método  IniciaPrgao()!");
            }
            Ganhador = Modalidade.Avalalia(this);
            Estado = EstadoLeilao.LeilaoFinalizado;

        }
        private bool ValidarLance(Interessada cliente, double valor)
        {
          
            return (Estado == EstadoLeilao.LeilaoEmAndamento && _ultimoCLiente != cliente );
        }
    }
}
