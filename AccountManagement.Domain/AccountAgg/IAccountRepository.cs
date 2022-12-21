using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetBy(string username);
        AccountViewModel GetAccountByRoles(string username);
        AccountViewModel GetAccountByRoles(long id);
        EditAccount GetDetails(long id);
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void DeleteAccountRoles(long accountId);
    }
}
