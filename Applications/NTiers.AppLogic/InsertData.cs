using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiers.AppLogic
{
    public class InsertData : DataAccess
    {
        public InsertData(string table) : base(table) { }

        public void InsertItem(string IdInput, string NameInput)
        {
            if (Table == "Enrollments")
            {
                try
                {
                    int ID1 = int.Parse(IdInput);
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
                    int ID = int.Parse(IdInput);
                    dataManager.AddItem(ID, NameInput);

                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public void InsertItem(string IdInput, string NameInput, string CorsDescInput, string CorsInstInput)
        {
            try
            {
                int ID1 = int.Parse(IdInput);
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
