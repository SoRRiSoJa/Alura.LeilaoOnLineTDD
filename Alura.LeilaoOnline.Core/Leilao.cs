using Alura.LeilaoOnLine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        public EstadoLeilao Estado { get; private set; }
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        private Interessada _ultimoCLiente;
        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesPregao;
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
            Ganhador = _lances.DefaultIfEmpty(new Lance(null, 0)).OrderBy((l) => l.Valor).LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
        private bool ValidarLance(Interessada cliente, double valor)
        {
          
            return (Estado == EstadoLeilao.LeilaoEmAndamento && _ultimoCLiente != cliente );
        }
    }
}
