using System.Collections;
using System.Data;

namespace NTiers.DataLayer
{
    public class Instructors : DataManager
    {
        public override DataTable GetAll()
        {
            SetCommand("Instructors_GetAll");
            return GetData();
        }

        public override DataTable GetByStudent(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Instructors_GetByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourse(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Instructors_GetByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructor(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Instructors_GetByInstructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override void AddItem(int InstID, string InstName)
        {
            string[] ParamsName = { "@InstID", "@InstName" };
            ArrayList ParamsValue = new ArrayList() { InstID, InstName };

            SetCommand("Instrucors_AddInstructor");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void UpdateItem(int InstID, string InstName)
        {
            string[] ParamsName = { "@InstID", "@InstName" };
            ArrayList ParamsValue = new ArrayList() { InstID, InstName };

            SetCommand("Instructors_UpdateInstructor");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void RemoveItem(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Instructors_RemoveInstructor");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
    }
}
