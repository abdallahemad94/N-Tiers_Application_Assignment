using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NTiers.Entities;

namespace NTiers.DataLayer
{
    public class Courses : DataManager
    {
        private List<Course> courses;

        #region constructor
        public Courses()
        {
            columns = new string[] { "Course ID", "Course Name", "Course Description", "Course Instructor" };
            dtypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(int) };
            dataTable = SetDataTable(columns, dtypes);
        }
        #endregion 

        #region retrieve data
        public override DataTable GetAll()
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                courses = (from crs in context.Courses select crs).ToList();
            }

            foreach (Course crs in courses)
            {
                RowValues = new ArrayList() { crs.CourseID, crs.CourseName, crs.CourseDesc, crs.CourseInst };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByStudent(int stdID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                courses = (from crs in context.Courses
                           join enroll in context.Enrollments
                           on crs.CourseID equals enroll.CourseID
                           where enroll.stdID == stdID
                           select crs).ToList();
            }

            foreach (Course crs in courses)
            {
                RowValues = new ArrayList() { crs.CourseID, crs.CourseName, crs.CourseDesc, crs.CourseInst };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByCourse(int CourseID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                courses = (from crs in context.Courses
                           where crs.CourseID == CourseID
                           select crs).ToList();
            }

            foreach (Course crs in courses)
            {
                RowValues = new ArrayList() { crs.CourseID, crs.CourseName, crs.CourseDesc, crs.CourseInst };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByInstructor(int CourseInst)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                courses = (from crs in context.Courses
                           where crs.CourseInst == CourseInst
                           select crs).ToList();
            }

            foreach (Course crs in courses)
            {
                RowValues = new ArrayList() { crs.CourseID, crs.CourseName, crs.CourseDesc, crs.CourseInst };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }
        #endregion

        #region add date
        public override void AddItem(int CourseID, string CourseName, string CourseDesc, int CourseInst)
        {
            using (context = new SchoolEntities())
            {
                context.Courses_AddCourse(CourseID, CourseName, CourseDesc, CourseInst);
            }
        }
        #endregion

        #region update data
        public override void UpdateItem(int CourseID, string CourseName, string CourseDesc, int CourseInst)
        {
            using (context = new SchoolEntities())
            {
                context.Courses_UpdateCourse(CourseID, CourseName, CourseDesc, CourseInst);
            }
        }
        #endregion

        #region remove data
        public override void RemoveItem(int CourseID)
        {
            using (context = new SchoolEntities())
            {
                context.Courses_RemoveCourse(CourseID);
            }
        }
        #endregion
    }
}
