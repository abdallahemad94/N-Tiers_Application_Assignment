using NTiers.DataLayer;

namespace NTiers.AppLogic
{
    public class MainAccess
    {
        protected DataManager dataManager;

        public string Table { get; }
        public MainAccess(string table)
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
