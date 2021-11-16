using dotnetsln5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Business
{
    public interface IPessoaBusiness
    {
        public List<Pessoa> FindAll();
        public Pessoa FindByID(long id);
        public Pessoa Create(Pessoa pessoa);
        public Pessoa Edit(Pessoa pessoa);
        public void Delete(long id);
    }
}
