using Microsoft.EntityFrameworkCore;
using OneClick.Data.Data;
using OneClick.Data.Dto;
using OneClick.Domain.Domain.Balances;
using OneClick.UseCases.Intefaces.Balances;

namespace OneClick.Data.Repositoties
{
    public class TransactionRepository : ITransactionRepository<OneClickTransaction>
    {
        private ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(OneClickTransaction transaction)
        {
            await _context.AddAsync(OneClickTransactionDto.TransactionDto(transaction));
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<OneClickTransaction>> Get()
        {
            var oneClickTransactions = new List<OneClickTransaction>();
            var transactions = await _context.Transactions.ToListAsync();

            if (transactions != null)
            {
                transactions.ForEach(x => oneClickTransactions.Add(OneClickTransactionDto.TransactionDto(x)));
            }
            return oneClickTransactions;
        }

        public async Task<OneClickTransaction> GetById(long transactionId)
        {
            var transaction = await _context.Transactions.Where(x => x.Id == transactionId).FirstOrDefaultAsync();

            if (transaction != null)
            {
                return OneClickTransactionDto.TransactionDto(transaction);
            }
            return null;
        }

        public async Task<bool> Update(OneClickTransaction transaction)
        {

            _context.Update(transaction);
            var resultSave = await _context.SaveChangesAsync();
            if (resultSave != 1)
            {
                return false;
            }

            return true;
        }
    }
}
