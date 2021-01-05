using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnLine.Core
{
    public class OfertaSuperiorMaisProxima:IModalidadeAvaliacao
    {
        private double valorDestino;

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.valorDestino = valorDestino;
        }

        public Lance Avalalia(Leilao leilao)
        {
            return leilao.Lances.DefaultIfEmpty(new Lance(null, 0)).Where((l) => l.Valor > leilao.ValorDestino).OrderBy((l) => l.Valor).FirstOrDefault();
        }
    }
}