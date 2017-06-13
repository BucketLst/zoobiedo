using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobiedo.Common.Models;

namespace Zoobiedo.ServiceLibrary
{
   public interface IUserAccount
    {
        Task<UserObjectModel> GetUser();
        bool IsUserAuthenticationPassesd();

    }
}
