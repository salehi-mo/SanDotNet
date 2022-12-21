﻿using System.Collections.Generic;

namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel account);
        List<long> CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        long CurrentAccountId();
        string CurrentAccountMobile();
        string CurrentAccountUserName();

    }
}
