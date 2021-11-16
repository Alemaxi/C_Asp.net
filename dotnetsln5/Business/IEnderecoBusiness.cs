using dotnetsln5.Models;
using dotnetsln5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Business
{
    public interface IEnderecoBusiness
    {
        public List<Endereco> FindAll();
        public Endereco FindByID(long id);
        public Endereco Create(Endereco endereco);
        public Endereco Edit(Endereco endereco);
        public void Delete(long id);
    }
}
