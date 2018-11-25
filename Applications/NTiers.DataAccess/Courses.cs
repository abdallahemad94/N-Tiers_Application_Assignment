using System.Collections;
using System.Data;

namespace NTiers.DataLayer
{
    public class Courses : DataManager
    {
        public override DataTable GetAll()
        {
            SetCommand("Courses_GetAll");

            return GetData();
        }

        public override DataTable GetByStudent(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Courses_GetByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourse(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Courses_GetByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructor(int CourseInst)
        {
            string[] ParamsName = { "@CourseInst" };
            ArrayList ParamsValue = new ArrayList() { CourseInst };

            SetCommand("Courses_GetByIntructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override void AddItem(int CourseID, string CourseName, string CourseDesc, int CourseInst)
        {
            string[] ParamsName = { "@CourseID", "@CourseName", "@CourseDesc", "@CourseInst" };
            ArrayList ParamsValue = new ArrayList() { CourseID, CourseName, CourseDesc, CourseInst };

            SetCommand("Courses_AddCourse");
            AddParameters(4, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void UpdateItem(int CourseID, string CourseName, string CourseDesc, int CourseInst)
        {
            string[] ParamsName = { "@CourseID", "@CourseName", "@CourseDesc", "@CourseInst" };
            ArrayList ParamsValue = new ArrayList() { CourseID, CourseName, CourseDesc, CourseInst };

            SetCommand("Courses_UpdateCourse");
            AddParameters(4, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }

        public override void RemoveItem(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Courses_RemoveCourse");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
    }
}
