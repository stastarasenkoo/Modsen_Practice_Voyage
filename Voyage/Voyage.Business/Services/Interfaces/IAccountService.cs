using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.DataAccess.Entities;

namespace Voyage.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(AppUser user, string password);
    }
}
