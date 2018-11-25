using System.Collections;
using System.Data;

namespace NTiers.DataLayer
{
    public class Students : DataManager
    {
        #region retrive data
        public override DataTable GetAll()
        {
            SetCommand("Students_GetAll");
            return GetData();
        }

        public override DataTable GetByStudent(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Students_GetByStudent");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByCourse(int CourseID)
        {
            string[] ParamsName = { "@CourseID" };
            ArrayList ParamsValue = new ArrayList() { CourseID };

            SetCommand("Students_GetByCourse");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }

        public override DataTable GetByInstructor(int CourseInst)
        {
            string[] ParamsName = { "@CourseInst" };
            ArrayList ParamsValue = new ArrayList() { CourseInst };

            SetCommand("Students_GetByInstructor");
            AddParameters(1, ParamsName, ParamsValue);

            return GetData();
        }
        #endregion

        #region add data
        public override void AddItem(int stdID, string stdName)
        {
            string[] ParamsName = { "@stdID", "@stdName" };
            ArrayList ParamsValue = new ArrayList() { stdID, stdName };

            SetCommand("Students_AddStudent");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
        #endregion

        #region update data
        public override void UpdateItem(int stdID, string stdName)
        {
            string[] ParamsName = { "@stdID", "@stdName" };
            ArrayList ParamsValue = new ArrayList() { stdID, stdName };

            SetCommand("Students_UpdateStudent");
            AddParameters(2, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
        #endregion

        #region remove data
        public override void RemoveItem(int stdID)
        {
            string[] ParamsName = { "@stdID" };
            ArrayList ParamsValue = new ArrayList() { stdID };

            SetCommand("Students_RemoveStudent");
            AddParameters(1, ParamsName, ParamsValue);
            ExecuteNonQuery();
        }
        #endregion
    }
}
