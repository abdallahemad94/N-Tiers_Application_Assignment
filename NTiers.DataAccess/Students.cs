using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace NTiers.DataAccess
{
    public class Students : MainData
    {
        public override DataTable GetAll()
        {
            SetCommand("Students_getAll");
            return GetData();
        }

        public override DataTable GetByStudentID(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Students_getByID");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourseID(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Students_getByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructorID(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Students_getByInstructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override void AddItem(int stdID, string stdName)
        {
            string[] ParamsName = { "@stdID", "@stdName" };
            ArrayList ParamsValue = new ArrayList() { stdID, stdName };

            SetCommand("Students_addStudent");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void RemoveItem(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Students_removeByID");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
    }
}
