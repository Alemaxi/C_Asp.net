using dotnetsln5.Models;
using dotnetsln5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Business.Implementation
{
    public class PessoaBusiness : IPessoaBusiness
    {
        private readonly IPessoaRepository _repository;

        public PessoaBusiness(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            return _repository.Create(pessoa);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Pessoa Edit(Pessoa pessoa)
        {
            return _repository.Edit(pessoa);
        }

        public List<Pessoa> FindAll()
        {
            return _repository.FindAll();
        }

        public Pessoa FindByID(long id)
        {
            return _repository.FindByID(id);
        }
    }
}
