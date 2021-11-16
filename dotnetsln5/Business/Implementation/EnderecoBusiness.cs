using dotnetsln5.Models;
using dotnetsln5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Business.Implementation
{
    public class EnderecoBusiness : IEnderecoBusiness
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoBusiness(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public Endereco Create(Endereco endereco)
        {
            return _repository.Create(endereco);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Endereco Edit(Endereco endereco)
        {
            return _repository.Edit(endereco);
        }

        public List<Endereco> FindAll()
        {
            return _repository.FindAll();
        }

        public Endereco FindByID(long id)
        {
            return _repository.FindByID(id);
        }
    }
}
