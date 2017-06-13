using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zoobiedo.Common;
using Zoobiedo.Common.Models;

namespace Zoobiedo.ServiceLibrary
{
   public class UserAccountService : IUserAccount
    {
        public UserAccountService()
        {

        }

        public Task<UserObjectModel> GetUser()
        {
            UserDataTable tableObj = new UserDataTable();
            var result = DataTableToList<UserObjectModel>(tableObj.GetAllUsers()).FirstOrDefault();
            tableObj.Dispose();
            return Task.FromResult(result);
        }

        public bool IsUserAuthenticationPassesd()
        {
            return true;
        }

        private List<T> DataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

      
    }
}
