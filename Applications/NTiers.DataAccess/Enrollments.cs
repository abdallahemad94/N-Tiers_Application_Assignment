using NTiers.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NTiers.DataLayer
{
    public class Enrollments : DataManager
    {
        private List<Enrollment> enrollments;

        #region constructor
        public Enrollments()
        {
            columns = new string[] { "Enrollment ID", "Course ID", "Student ID"};
            dtypes = new Type[] { typeof(int), typeof(int), typeof(int) };
            dataTable = SetDataTable(columns, dtypes);
        }
        #endregion

        #region retrieve data
        public override DataTable GetAll()
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                enrollments = (from enroll in context.Enrollments select enroll).ToList();
            }

            foreach (Enrollment enroll in enrollments)
            {
                RowValues = new ArrayList() { enroll.EnrollID, enroll.CourseID, enroll.stdID };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByStudent(int stdID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                enrollments = (from enroll in context.Enrollments where enroll.stdID == stdID select enroll).ToList();
            }

            foreach(Enrollment enroll in enrollments)
            {
                RowValues = new ArrayList() { enroll.EnrollID, enroll.CourseID, enroll.stdID };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByCourse(int CourseID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                enrollments = (from enroll in context.Enrollments where enroll.CourseID == CourseID select enroll).ToList();
            }

            foreach (Enrollment enroll in enrollments)
            {
                RowValues = new ArrayList() { enroll.EnrollID, enroll.CourseID, enroll.stdID };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByInstructor(int CourseInst)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                enrollments = (from enroll in context.Enrollments
                               join crs in context.Courses
                               on enroll.CourseID equals crs.CourseID
                               where crs.CourseInst == CourseInst
                               select enroll).ToList();
            }

            foreach (Enrollment enroll in enrollments)
            {
                RowValues = new ArrayList() { enroll.EnrollID, enroll.CourseID, enroll.stdID };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }
        #endregion

        #region add date
        public override void AddItem(int CourseID, int stdID)
        {
            using (context = new SchoolEntities())
            {
                context.Enrollments_AddEnrollment(CourseID, stdID);
            }
        }
        #endregion

        #region update date
        public override void UpdateItem(int EnrollID, int CourseID, int stdID)
        {
            using (context = new SchoolEntities())
            {
                context.Enrollments_UpdateEnrollment(EnrollID, CourseID, stdID);
            }
        }
        #endregion

        #region remove data
        public override void RemoveItem(int EnrollID)
        {
            using (context = new SchoolEntities())
            {
                context.Enrollments_RemoveEnrollment(EnrollID);
            }
        }
        #endregion
    }
}
