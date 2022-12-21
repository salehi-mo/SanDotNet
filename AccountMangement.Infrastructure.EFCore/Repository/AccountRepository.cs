using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.AccountRoleAgg;

namespace AccountMangement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public Account GetBy(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.Username == username);
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                //RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname
            }).ToList();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                //Role = x.Role.Name,
                //RoleId = x.RoleId,
                Username = x.Username,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            //if (searchModel.RoleId > 0)
            //    query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public AccountViewModel GetAccountByRoles(string username)
        {
            var account = _context.Accounts.Select(x=> new AccountViewModel()
            {
                Id = x.Id,
                Roles = new List<long>(),
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                Password = x.Password,
                Username = x.Username,
                ProfilePhoto = x.ProfilePhoto
            }).FirstOrDefault(x => x.Username == username);
            var accountRoles = _context.AccountRoles.Where(x => x.AccountId == account.Id).ToList();
            var rolse = new List<long>();
            rolse.AddRange(accountRoles.Select(x=>x.RoleId));

            account.Roles = rolse;
            return account;
        }
        public AccountViewModel GetAccountByRoles(long id)
        {
            var account = _context.Accounts.Select(x => new AccountViewModel()
            {
                Id = x.Id,
                Roles = new List<long>(),
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                Password = x.Password,
                Username = x.Username,
                ProfilePhoto = x.ProfilePhoto
            }).FirstOrDefault(x => x.Id == id);
            var accountRoles = _context.AccountRoles.Where(x => x.AccountId == account.Id).ToList();
            var rolse = new List<long>();
            rolse.AddRange(accountRoles.Select(x => x.RoleId));

            account.Roles = rolse;
            return account;
        }

        public void DeleteAccountRoles(long accountId)
        {
            var accountRoles = _context.AccountRoles.Where(x => x.AccountId == accountId).ToList();
            _context.RemoveRange(accountRoles);
            _context.SaveChanges();
        }
    }
}