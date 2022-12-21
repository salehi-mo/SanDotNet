using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Domain.AccountRoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Fullname = account.Fullname,
                Mobile = account.Mobile
            };
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.Fullname, command.Username, password, command.Mobile, 
                picturePath);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);

            //var accountRoles = new List<AccountRole>();
            //if (command.Roles.Count > 0)
            //    foreach (var role in command.Roles)
            //    {
            //        var accountrole = new AccountRole(command.Id,role);
            //        accountRoles.Add(accountrole);
            //    }

            if (command.Roles != null)
            {
                var accountRoles = new List<AccountRole>();
                command.Roles.ForEach(x => accountRoles.Add(new AccountRole(command.Id, x)));
                _accountRepository.DeleteAccountRoles(command.Id);
                account.Edit(command.Fullname, command.Username, command.Mobile, picturePath, accountRoles);
            }
            else
            {
                account.Edit(command.Fullname, command.Username, command.Mobile, picturePath);
            }

            
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetAccountByRoles(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

           
            var permissions = new List<int>();
            var roleNames = new List<string>();
            var roleIds = new List<long>();
            foreach (var role in account.Roles)
            {
                var permission = _roleRepository.Get(role)
                        .Permissions
                        .Select(x => x.Code)
                        .ToList();
                permissions.AddRange(permission);
                roleNames.Add(_roleRepository.Get(role).Name);
                roleIds.Add(_roleRepository.Get(role).Id);
            }

            if(string.IsNullOrWhiteSpace(command.Verifycode))
                permissions = new List<int>();


            var authViewModel = new AuthViewModel(account.Id,  roleNames,roleIds, account.Fullname
                , account.Username, account.Mobile, account.ProfilePhoto, permissions);


            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public AccountViewModel GetAccountByRoles(string username)
        {
            return _accountRepository.GetAccountByRoles(username);
        }

        public AccountViewModel GetAccountByRoles(long id)
        {
            return _accountRepository.GetAccountByRoles(id);
        }

        public void DeleteAccountRoles(long accountId)
        {
             _accountRepository.DeleteAccountRoles(accountId);
        }

        public OperationResult LoginFinal(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetAccountByRoles(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);
           

            var permissions = new List<int>();
            var roleNames = new List<string>();
            var roleIds = new List<long>();
            foreach (var role in account.Roles)
            {
                var permission = _roleRepository.Get(role)
                    .Permissions
                    .Select(x => x.Code)
                    .ToList();
                permissions.AddRange(permission);
                roleNames.Add(_roleRepository.Get(role).Name);
                roleIds.Add(_roleRepository.Get(role).Id);
            }

            if (string.IsNullOrWhiteSpace(command.Verifycode))
                permissions = new List<int>();


            var authViewModel = new AuthViewModel(account.Id, roleNames, roleIds, account.Fullname
                , account.Username, account.Mobile, account.ProfilePhoto, permissions);

            
            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }
    } 
}