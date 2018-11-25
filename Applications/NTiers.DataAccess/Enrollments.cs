using System.Collections;
using System.Data;

namespace NTiers.DataLayer
{
    public class Enrollments : DataManager
    {
        #region retrive data
        public override DataTable GetAll()
        {
            SetCommand("Enrollments_GetAll");
            return GetData();
        }

        public override DataTable GetByStudent(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Enrollments_GetByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourse(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Enrollments_GetByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructor(int CourseInst)
        {
            string[] ParamsName = { "@CourseInst" };
            ArrayList ParamsValue = new ArrayList() { CourseInst };

            SetCommand("Enrollments_GetByInstructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }
        #endregion

        #region add date
        public override void AddItem(int CourseID, int stdID)
        {
            string[] ParamsName = { "@CourseID", "@stdID" };
            ArrayList ParamsValue = new ArrayList() { CourseID, stdID };

            SetCommand("Enrollments_AddEnrollment");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
        #endregion

        #region update date
        public override void UpdateItem(int EnrollID, int CourseID, int stdID)
        {
            string[] ParamsName = { "@EnrollID", "@CourseID", "@stdID" };
            ArrayList ParamsValue = new ArrayList() { EnrollID, CourseID, stdID };

            SetCommand("Enrollments_UpdateEnrollment");
            AddParameters(3, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
        #endregion

        #region remove data
        public override void RemoveItem(int EnrollID)
        {
            string[] ParamsName = { "@EnrollID" };
            ArrayList ParamsValue = new ArrayList() { EnrollID };

            SetCommand("Enrollments_RemoveEnrollment");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
        #endregion
    }
}
