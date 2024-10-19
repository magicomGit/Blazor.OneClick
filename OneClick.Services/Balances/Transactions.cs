using OneClick.Domain.Domain.Balances;
using OneClick.Domain.Enums.Transaction;
using OneClick.Services.Contracts;
using OneClick.UseCases.Intefaces.App;
using OneClick.UseCases.Intefaces.Balances;
using OneClick.UseCases.Intefaces.User;

namespace OneClick.Services.Balances
{
    public class Transactions : ITransactions<Response<OneClickTransaction>, OneClickTransaction>
    {
        private ITransactionRepository<OneClickTransaction> _transactionRepository;
        private IUserRepository _userRepository;
        private IAppLogger _logger;
        public Transactions(ITransactionRepository<OneClickTransaction> transactionRepository, IUserRepository userRepository, IAppLogger logger)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Response<OneClickTransaction>> ApplyDeposit(Guid userId, PaymentSystem paymentSystem, double summ, string description)
        {
            var response = new Response<OneClickTransaction> { Success = true };
            try
            {
                var user = await _userRepository.GetByIdAsync(userId.ToString());

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "пользователь не найден";
                }

                string tempId = Guid.NewGuid().ToString();

                var operations = new List<Operation>();

                var operation = new Operation(id: 0, summ, new Guid(user.Id), user.UserName, DateTime.UtcNow, description, user.Balance.WalletBalance, OpirationType.Apply,
                    OperationDirection.None, TransactionCode.ApplyDeposit, paymentSystem, "");

                operations.Add(operation);

                var newTransaction = new OneClickTransaction(id: 0, TransactionCode.Deposit, new Guid(user.Id), paymentSystem, "", user.UserName, summ, DateTime.UtcNow,
                    description, TransactionType.Deposit,TransactionStatus.Await, operations);


                var result = await _transactionRepository.Add(newTransaction);


                if (result)
                {
                    response.Success = false;
                    response.Message = "ApplyDeposit error ";
                    return response;
                }


                response.Message = user.UserName + " / Summ: " + summ + " / " + TransactionCode.ApplyDeposit.ToString();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "ApplyDeposit " + ex.Message;
                return response;
            }


            return response;
        }

        public async Task<Response<OneClickTransaction>> ApproveDeposit(Guid implementerId, long transactionId, double summ, string description, string payId)
        {
            var response = new Response<OneClickTransaction> { Success = true };
            try
            {
                var transaction = await _transactionRepository.GetById(transactionId);
                if (transaction == null)
                {
                    response.Success = false;
                    response.Message = "Не найдена транзакция " + transactionId;
                    return response;
                }

                var user = await _userRepository.GetByIdAsync(transaction.IssuerId.ToString());
                if (user.Balance == null)
                {
                    response.Success = false;
                    response.Message = "У пользователя " + user.UserName + " не удалось получить баланс";
                    return response;
                }


                var implementerName = "";

                if (transaction.PaySystem == PaymentSystem.Admin)
                {
                    var implementer = await _userRepository.GetByIdAsync(implementerId.ToString()); 
                    implementerId = new Guid(implementer.Id);
                    implementerName = implementer.UserName;
                }
                else
                {
                    //implementerId = new Guid();
                    implementerName = transaction.PaySystem.ToString();
                }



                //добавляем операцию
                transaction.ChangeStatus(TransactionStatus.Completed);
               
                transaction.SetSumm(summ);

                transaction.Operations.Add(new Operation(0, 0, implementerId, implementerName, DateTime.UtcNow, description, 0, OpirationType.Approve, OperationDirection.None,
                    TransactionCode.ApproveDeposit, transaction.PaySystem, payId));
               
                 transaction.Operations.Add(new Operation(0, summ, new Guid(user.Id), user.UserName, DateTime.UtcNow, description, user.Balance.WalletBalance + summ, 
                     OpirationType.Transfer, OperationDirection.Income, TransactionCode.Deposit, transaction.PaySystem, payId));
               

                

                //баланс пользователя
                user.Balance.WalletBalance += summ;

                var transactionUpdateResult = await _transactionRepository.Update(transaction);

                var userUpdateResult = await _userRepository.UpdateBalanceAsync(user);

                if (transactionUpdateResult && userUpdateResult)
                {
                    _logger.LogTransaction($"Платежная система: {transaction.PaySystem} | Код транзакции: {TransactionCode.ApproveDeposit.ToString()} |  Summ: {summ}$ | Пользователь: {user.UserName} | Transaction Id: {transaction.Id}");
                }
                else
                {
                    _logger.LogCriticalError($"Ошибка при сохранении транзакции | Платежная система: {transaction.PaySystem} | Код транзакции: {TransactionCode.ApproveDeposit.ToString()} |  Summ: {summ}$ | Пользователь: {user.UserName} | Transaction Id: {transaction.Id}");
                    response.Success = false;
                }

                
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Transaction Id: {transactionId}  | Код транзакции: {TransactionCode.ApproveDeposit.ToString()} { ex.Message} ";
                return response;
            }
        }
    }
}
