using dotnetsln5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Repository
{
    public interface IPessoaRepository
    {
        public Pessoa FindByID(long id);
        public List<Pessoa> FindAll();
        public Pessoa Create(Pessoa item);
        public Pessoa Edit(Pessoa item);
        public void Delete(long id);
    }
}
