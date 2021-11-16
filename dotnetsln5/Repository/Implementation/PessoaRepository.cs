using dotnetsln5.Models;
using dotnetsln5.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Repository.Implementation
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly Dotnetsln5Context _context;

        public PessoaRepository(Dotnetsln5Context context)
        {
            _context = context;
        }

        public Pessoa Create(Pessoa item)
        {
            var result = _context.Pessoas.Add(item).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Delete(long id)
        {
            var deletedOne = _context.Pessoas.FirstOrDefault(pessoa => pessoa.PessoaID == id);
            _context.Pessoas.Remove(deletedOne);
            _context.SaveChanges();
        }

        public Pessoa Edit(Pessoa item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        public List<Pessoa> FindAll()
        {
            return _context.Pessoas.ToList();
        }

        public Pessoa FindByID(long id)
        {
            return _context.Pessoas.FirstOrDefault(pessoa => pessoa.PessoaID == id);
        }
    }
}
