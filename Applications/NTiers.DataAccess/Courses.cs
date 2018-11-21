using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace NTiers.DataLayer
{
    public class Courses : DataManager
    {
        public override DataTable GetAll()
        {
            SetCommand("Courses_getAll");
            return GetData();
        }

        public override DataTable GetByStudentID(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Courses_getByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourseID(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Courses_getByID");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructorID(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Courses_getByIntructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override void AddItem(int CourseID, string CourseName, string CourseDesc, int InstID)
        {
            string[] ParamsName = { "@CourseID", "@CourseName", "@CourseDesc", "@InstID" };
            ArrayList ParamsValue = new ArrayList() { CourseID, CourseName, CourseDesc, InstID };

            SetCommand("Courses_addCourse");
            AddParameters(4, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void RemoveItem(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Courses_removeByCourseID");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public void RemoveItemByInstructorID(int InstID)
        {
            string[] ParamsName = { "@InstID" };
            ArrayList ParamsValue = new ArrayList() { InstID };

            SetCommand("Courses_removeByInstructorID");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
    }
}
