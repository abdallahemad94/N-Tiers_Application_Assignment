using System;

namespace NTiers.AppLogic
{
    public class DeleteAccess : MainAccess
    {
        #region constructor
        public DeleteAccess(string table) :  base(table) { }
        #endregion

        #region delete item
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
        #endregion
    }
}
