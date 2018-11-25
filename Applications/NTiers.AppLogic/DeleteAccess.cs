using System;

namespace NTiers.AppLogic
{
    public class DeleteAccess : MainAccess
    {
        public DeleteAccess(string table) :  base(table) { }

        public void DeleteItem(string userInput)
        {
            try
            {
                int ID = int.Parse(userInput);
                dataManager.RemoveItem(ID);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
