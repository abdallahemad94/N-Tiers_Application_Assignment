using System;

namespace NTiers.AppLogic
{
    public class UpdateAccess : MainAccess
    {
        public UpdateAccess(string table) : base(table) { }

        public void UpdateItem(string id, string name)
        {
            try
            {
                int ID = Convert.ToInt32(id);
                dataManager.UpdateItem(ID, name);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdateItem(string enrollID, string courseID, string stdID)
        {
            try
            {
                int EnrollId = Convert.ToInt32(enrollID);
                int CourseID = Convert.ToInt32(courseID);
                int StdID = Convert.ToInt32(stdID);
                dataManager.UpdateItem(EnrollId, CourseID, StdID);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdateItem(string courseID, string courseName, string courseDesc, string courseInst)
        {
            try
            {
                int CourseID = Convert.ToInt32(courseID);
                int CourseInst = Convert.ToInt32(courseInst);
                dataManager.UpdateItem(CourseID, courseName, courseDesc, CourseInst);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
