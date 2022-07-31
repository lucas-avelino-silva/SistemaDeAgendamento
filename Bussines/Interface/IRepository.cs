
using Agendamento.App.Models;
using Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interface
{
    public interface IRepository<t> where t : class
    {
        public bool Adicionar(t entidade);
        public int Salvar();

    }
}
