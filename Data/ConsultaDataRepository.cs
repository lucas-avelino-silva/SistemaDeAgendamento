using Bussines.Interface;
using Bussines.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ConsultaDataRepository : Repository<DataModel>, IConsultaDataRepository
    {
        public ConsultaDataRepository(Context contexto) : base(contexto)
        {
        }

        public List<DataModel> ObterPorData(string data)
        {
            var lista = _contexto.Agendamentos.Where(a => a.Data == data).ToList();
            return lista;
        }

        public List<DataModel> ObterTodos()
        {
            var lista = _contexto.Agendamentos.Include(a => a.Pessoa).ToList();
            return lista;
        }
    }
}
