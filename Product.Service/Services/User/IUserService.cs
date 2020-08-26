using Product.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Services.User
{
    public interface IUserService
    {
        void Save(RegisterModel user);
    }
}
