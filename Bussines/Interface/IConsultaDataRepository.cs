
using Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interface
{
    public interface IConsultaDataRepository: IRepository<DataModel>
    {
        public List<DataModel> ObterPorData(string data);
        public List<DataModel> ObterTodos();

    }
}
