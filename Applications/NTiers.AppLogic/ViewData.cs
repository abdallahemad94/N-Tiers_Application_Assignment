using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTiers.DataLayer;
using System.Data;

namespace NTiers.AppLogic
{
    public class ViewData : DataAccess
    {
        public ViewData(string table) : base(table) { }

        public DataTable GetUnFilterdData()
        {
            return dataManager.GetAll();
        }

        public static List<string> GetTables()
        {
            DataTable Schema = DataSchema.GetSchema("Tables");
            List<string> Tables = new List<string>();
            foreach(DataRow row in Schema.Rows)
            {
                Tables.Add(row[2].ToString());
            }
            return Tables;
        }

        public DataTable GetFilterdData(string FilterBy, string FilterID)
        {
            DataTable dataTable;
            try
            {
                int ID = int.Parse(FilterID);
                switch (FilterBy)
                {
                    case "Student":
                        dataTable = dataManager.GetByStudentID(ID);
                        return dataTable;
                    case "Course":
                        dataTable = dataManager.GetByCourseID(ID);
                        return dataTable;
                    case "Instructor":
                        dataTable = dataManager.GetByInstructorID(ID);
                        return dataTable;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return GetUnFilterdData();
        }
    }
}
