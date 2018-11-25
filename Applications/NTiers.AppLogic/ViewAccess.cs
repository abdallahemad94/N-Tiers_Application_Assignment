using NTiers.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace NTiers.AppLogic
{
    public class ViewAccess : MainAccess
    {
        #region constructor
        public ViewAccess(string table) : base(table) { }
        #endregion

        #region get tables names
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
        #endregion

        #region get tables data
        public DataTable GetUnFilterdData()
        {
            return dataManager.GetAll();
        }

        public DataTable GetFilterdData(string FilterBy, string FilterID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                int ID = int.Parse(FilterID);
                switch (FilterBy)
                {
                    case "Student":
                        dataTable = dataManager.GetByStudent(ID);
                        return dataTable;
                    case "Course":
                        dataTable = dataManager.GetByCourse(ID);
                        return dataTable;
                    case "Instructor":
                        dataTable = dataManager.GetByInstructor(ID);
                        return dataTable;
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return dataTable;
        }
        #endregion
    }
}
