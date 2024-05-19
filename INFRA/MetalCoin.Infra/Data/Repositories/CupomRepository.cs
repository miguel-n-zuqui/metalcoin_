using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Infra.Data.Repositories
{
    public class CupomRepository: Repository<Cupom>,ICuponsRepository
    {
        public CupomRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public async Task<List<Cupom>> BuscarCupomAtivos()
        {
            var resultado = await DbSet.Where(x => x.statusCupom == TipoStatusCupom.Ativo).ToListAsync();
            return resultado;
        }

        public async Task<List<Cupom>> BuscarCupomIndisponiveis()
        {
            var resultado = await DbSet.Where(x => x.statusCupom == TipoStatusCupom.Desativado).ToListAsync();
            return resultado;
        }
        //public async Task<Cupom> BuscarPorCodigo(string codigo)
        //{
        //    var resultado = await DbSet.Where(x => x.CodigoCupom == codigo).ToListAsync();
        //    return resultado;
        //}
    }
}
