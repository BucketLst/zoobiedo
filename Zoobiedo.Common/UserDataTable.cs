using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Zoobiedo.Common
{
    public class UserDataTable : IDisposable
    {
        DataTable table = null;
        bool IsDisposing = false;

        public UserDataTable()
        {
          table = new DataTable();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool flag)
        {
            if (flag)
                return;
            if(IsDisposing)
            {
                if(table != null) 
                  table.Dispose();
                IsDisposing = true;
            }
        }

        public DataTable GetAllUsers()
        {
           table.Columns.Add("UserId", typeof(string));
           table.Columns.Add("FirstName", typeof(string));
           table.Columns.Add("MiddleName", typeof(string));
           table.Columns.Add("LastName", typeof(string));
           table.Columns.Add("PhoneNo", typeof(string));
           table.Columns.Add("EmailId", typeof(string));

            table.Rows.Add("", "Gokul", "Raj", "", "", "");
            table.Rows.Add("", "Dharma", "Raj", "", "", "");
            table.Rows.Add("", "Gokul", "Raj", "", "", "");
            table.Rows.Add("", "Dharma", "Raj", "", "", "");
            table.Rows.Add("", "Gokul", "Raj", "", "", "");
            table.Rows.Add("", "Dharma", "Raj", "", "", "");

            return table;
        }
    }
}
