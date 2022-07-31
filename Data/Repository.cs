using Bussines.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<t> : IRepository<t> where t : class
    {
        protected Context _contexto;
        protected DbSet<t> _DbSet;
        public Repository(Context contexto)
        {
            _contexto = contexto;
            _DbSet = _contexto.Set<t>();

        }


        public bool Adicionar(t entidade)
        {
            _DbSet.Add(entidade);
            if (Salvar() > 0)
            {
                return true;
            }
            return false;

        }

        public int Salvar()
        {
            return _contexto.SaveChanges();
        }
    }
}
