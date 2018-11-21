using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTiers.DataLayer;

namespace NTiers.AppLogic
{
    public class DataAccess
    {
        protected DataManager dataManager;

        public string Table { get; }
        public DataAccess(string table)
        {
            Table = table;
            switch (Table)
            {
                case "Students":
                    dataManager = new Students();
                    break;
                case "Courses":
                    dataManager = new Courses();
                    break;
                case "Instructors":
                    dataManager = new Instructors();
                    break;
                case "Enrollments":
                    dataManager = new Enrollments();
                    break;
            }
        }
    }
}
