using Vendinha.Data;
using Vendinha.Models;
using Microsoft.EntityFrameworkCore;

namespace Vendinha.Services
{
    public class DividaService
    {
        private VendinhaDbContext context;

        public DividaService(VendinhaDbContext context) 
        {
            this.context = context;
        }

        public async Task<bool> CriarDivida(Divida divida)
        {
            var possuiDividaAberta = await context.Dividas
                .AnyAsync(d => d.ClienteId == divida.ClienteId && !d.Paga);

            if (possuiDividaAberta)
            {
                return false;
            }

            context.Dividas.Add(divida);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PagarDivida(int dividaId)
        {
            var divida = await context.Dividas.FindAsync(dividaId);

            if (divida == null || divida.Paga)
            {
                return false;
            }

            divida.Paga = true;
            divida.DataPagamento = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return true;
        }
    }
}
