using dotnetsln5.Models;
using dotnetsln5.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Repository.Implementation
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly Dotnetsln5Context _context;

        public EnderecoRepository(Dotnetsln5Context context)
        {
            _context = context;
        }

        public Endereco Create(Endereco item)
        {
            var result = _context.Enderecos.Add(item).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Delete(long id)
        {
            var deletedOne = _context.Enderecos.FirstOrDefault(endereco => endereco.EnderecoID == id);
            _context.Enderecos.Remove(deletedOne);
            _context.SaveChanges();
        }

        public Endereco Edit(Endereco item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        public List<Endereco> FindAll()
        {
            return _context.Enderecos.ToList();
        }

        public Endereco FindByID(long id)
        {
            return _context.Enderecos.FirstOrDefault(endereco => endereco.EnderecoID == id);
        }
    }
}
