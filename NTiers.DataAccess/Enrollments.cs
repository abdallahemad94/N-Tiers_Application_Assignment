using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace NTiers.DataAccess
{
    public class Enrollments : DataManager
    {
        public override DataTable GetAll()
        {
            SetCommand("Enrollments_GetAll");
            return GetData();
        }

        public override DataTable GetByStudentID(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Enrollments_GetByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourseID(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Enrollments_GetByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructorID(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Enrollments_GetByInstructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override void AddItem(int CourseID, int stdID)
        {
            string[] ParamsName = { "@CourseID", "@stdID" };
            ArrayList ParamsValue = new ArrayList() { CourseID, stdID };

            SetCommand("Enrollments_addEnrollment");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void RemoveItem(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Enrollments_removeByStudentID");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
    }
}
