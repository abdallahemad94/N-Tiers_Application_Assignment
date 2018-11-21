using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace NTiers.DataAccess
{
    public class Instructors : DataManager
    {
        public override DataTable GetAll()
        {
            SetCommand("Instructors_getAll");
            return GetData();
        }

        public override DataTable GetByStudentID(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Instructors_getByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourseID(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Instructors_getByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructorID(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Instructors_getByID");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override void AddItem(int InstID, string InstName)
        {
            string[] ParamsName = { "@InstID", "@InstName" };
            ArrayList ParamsValue = new ArrayList() { InstID, InstName };

            SetCommand("Instrucors_addInstructor");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void RemoveItem(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Instructors_removeByID");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
    }
}
