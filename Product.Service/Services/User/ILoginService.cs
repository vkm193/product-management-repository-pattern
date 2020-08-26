using Product.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Services.User
{
    public interface ILoginService
    {
        string LoginUser(LoginModel user);
        bool IsValidUser(LoginModel user);
    }
}
