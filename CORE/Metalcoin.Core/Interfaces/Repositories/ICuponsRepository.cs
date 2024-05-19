using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface ICuponsRepository:IRepository<Cupom>
    {
        Task<List<Cupom>> BuscarCupomAtivos();
        Task<List<Cupom>> BuscarCupomIndisponiveis();

        //Task<Cupom> BuscarPorCodigo(UtilizarCupomRequest cupom);
    }
}
