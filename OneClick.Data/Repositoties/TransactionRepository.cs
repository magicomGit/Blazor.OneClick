using Microsoft.EntityFrameworkCore;
using OneClick.Data.Data;
using OneClick.Data.Dto;
using OneClick.Domain.Domain.Balances;
using OneClick.Domain.Domain.DomainModels;
using OneClick.UseCases.Intefaces.Balances;

namespace OneClick.Data.Repositoties
{
    public class TransactionRepository : ITransactionRepository<Response<OneClickTransaction>, OneClickTransaction>
    {
        private ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<OneClickTransaction>> Add(OneClickTransaction transaction)
        {
            var response = new Response<OneClickTransaction> { Success = true };

            var addResult = await _context.AddAsync(OneClickTransactionDto.TransactionDto(transaction));


            var saveResult = await _context.SaveChangesAsync();

            var entity = addResult.Entity;

            if (saveResult == 0)
            {
                response.Success = false;
                response.Message = "Save Transaction error";
                return response;
            }

            var newTransaction = OneClickTransactionDto.TransactionDto(entity);

            response.Data = newTransaction;
            return response;
        }

        public async Task<List<OneClickTransaction>> Get()
        {
            var oneClickTransactions = new List<OneClickTransaction>();
            var transactions = await _context.Transactions.AsNoTracking().ToListAsync();

            if (transactions != null)
            {
                transactions.ForEach(x => oneClickTransactions.Add(OneClickTransactionDto.TransactionDto(x)));
            }
            return oneClickTransactions;
        }

        public async Task<Response<OneClickTransaction>> GetById(long transactionId)
        {
            var response = new Response<OneClickTransaction> { Success = true };

            var entity = await _context.Transactions.Where(x => x.Id == transactionId).AsNoTracking().FirstOrDefaultAsync();

            if (entity != null)
            {
                response.Data = OneClickTransactionDto.TransactionDto(entity);
                return response;
            }
            else
            {
                response.Success = false;
                return response;
            }


        }

        public async Task<Response<OneClickTransaction>> Update(OneClickTransaction transaction)
        {
            var response = new Response<OneClickTransaction> { Success = true };
            var entity = _context.Transactions.Update(OneClickTransactionDto.TransactionDto(transaction));
            var resultSave = await _context.SaveChangesAsync();
            if (resultSave > 0)
            {
                response.Data = OneClickTransactionDto.TransactionDto(entity.Entity);
                return response;
            }
            else
            {
                response.Success = false;
                return response;
            }
        }
    }
}
