using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Repository.IDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.IRepository
{
    public interface IFichaRepository : IRepository<Ficha>
    {
    }
}