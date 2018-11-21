using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NTiers.DataLayer;

namespace NTiers.AppLogic
{
    public class DeleteData : DataAccess
    {
        public DeleteData(string table) :  base(table) { }

        public void DeleteItem(string userIdInput)
        {
            try
            {
                int IdInput = int.Parse(userIdInput);
                dataManager.RemoveItem(IdInput);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
