using CDP.Data;
using CDP.Models;
using CDP.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CDP.Services
{
    public class FuncionarioService
    {
        public readonly CDPContext _context;

        public FuncionarioService(CDPContext context)
        {
            _context = context;
        }
        public async Task<List<Funcionario>> FindAllAsync()
        {
            return await _context.Funcionario.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task InsertAsync(Funcionario obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario> FindByIdAsync(int id)
        {
            return await _context.Funcionario.Include(obj => obj.Cargo).FirstOrDefaultAsync(obj => obj.Id == id); ;
        }

        public async Task UpdateAsync(Funcionario obj)
        {
            bool hasAny = await _context.Funcionario.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id do usuário não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new IntegrityException("Erro ao deletar Funcionario por existência de vínculo de funcionário");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Funcionario.FindAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
                throw;
            }
        }
    }
}
