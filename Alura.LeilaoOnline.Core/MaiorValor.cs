
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnLine.Core
{
    public class MaiorValor : IModalidadeAvaliacao
    {
        public Lance Avalalia(Leilao leilao)
        {
            return leilao.Lances.DefaultIfEmpty(new Lance(null, 0)).OrderBy((l) => l.Valor).LastOrDefault();
        }
    }
}