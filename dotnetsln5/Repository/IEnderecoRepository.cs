using dotnetsln5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Repository
{
    public interface IEnderecoRepository
    {
        public Endereco FindByID(long id);
        public List<Endereco> FindAll();
        public Endereco Create(Endereco item);
        public Endereco Edit(Endereco item);
        public void Delete(long id);
    }
}
