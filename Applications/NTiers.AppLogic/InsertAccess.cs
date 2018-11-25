using System;

namespace NTiers.AppLogic
{
    public class InsertAccess : MainAccess
    {
        public InsertAccess(string table) : base(table) { }

        public void InsertItem(string IDInput, string NameInput)
        {
            if (Table == "Enrollments")
            {
                try
                {
                    int ID1 = int.Parse(IDInput);
                    int ID2 = int.Parse(NameInput);
                    dataManager.AddItem(ID1, ID2);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    int ID = int.Parse(IDInput);
                    dataManager.AddItem(ID, NameInput);

                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public void InsertItem(string IDInput, string NameInput, string CorsDescInput, string CorsInstInput)
        {
            try
            {
                int ID1 = int.Parse(IDInput);
                int CourseInst = int.Parse(CorsInstInput);
                dataManager.AddItem(ID1, NameInput, CorsDescInput, CourseInst);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
