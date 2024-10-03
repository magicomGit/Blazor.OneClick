using OneClick.Data.Data;
using OneClick.Domain.Domain.Balances;

namespace OneClick.Data.Dto
{
    public class OneClickTransactionDto
    {
        public static OneClickTransaction TransactionDto(BalanceTransaction b)
        {
            var operations = new List<Operation>();
            if (b.Operations != null) {
                b.Operations.ForEach(x=> operations.Add(OperationDto(x)));
            }   

            return new OneClickTransaction(b.Id, b.Code, b.IssuerId, b.PaySystem, b.PayId, b.Issuer, b.Summ, b.Date, b.Description, b.Type, b.Status, operations);
        }
         public static BalanceTransaction TransactionDto(OneClickTransaction b)
        {
            var operations = new List<BalanceOperation>();
            if (b.Operations != null) {
                b.Operations.ForEach(x=> operations.Add(OperationDto(x)));
            }

            return new BalanceTransaction
            {
                Id = b.Id,
                Code = b.Code,
                IssuerId = b.IssuerId,
                PaySystem = b.PaySystem,
                PayId = b.PayId,
                Date = b.Date,
                Description = b.Description,
                Type = b.Type,
                Status = b.Status,
                Issuer = b.Issuer,
                Summ = b.Summ,
                Operations = operations,
                
            };
                
              
        }

        public static Operation OperationDto(BalanceOperation o)
        {
            return new Operation(o.Id, o.Summ, o.UserId, o.UserLogin, o.Date, o.Description, o.LastBalance, o.Type, o.Direction, o.Code, o.PaySystem, o.PayId);
        }
        public static BalanceOperation OperationDto(Operation o)
        {
            return new BalanceOperation
            {
                Id = o.Id,
                Summ = o.Summ,
                UserId = o.UserId,
                Date = o.Date,
                Description = o.Description,
                LastBalance = o.LastBalance,
                Type = o.Type,
                Direction = o.Direction,
                Code = o.Code,
                PaySystem = o.PaySystem,
                PayId = o.PayId,
                UserLogin = o.UserLogin,
                
            };
        }
    }
}
