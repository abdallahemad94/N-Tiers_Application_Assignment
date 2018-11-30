using NTiers.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NTiers.DataLayer
{
    public class Students : DataManager
    {
        private List<Student> students;

        #region constructor
        public Students()
        {
            columns = new string[] { "Student ID", "Student Name" };
            dtypes = new Type[] { typeof(int), typeof(string) };
            dataTable = SetDataTable(columns, dtypes);
        }
        #endregion

        #region retrieve data
        public override DataTable GetAll()
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                students = (from std in context.Students select std).ToList();
            }

            foreach (Student std in students)
            {
                RowValues = new ArrayList() { std.stdID, std.stdName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByStudent(int stdID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                students = (from std in context.Students where std.stdID == stdID select std).ToList();
            }

            foreach (Student std in students)
            {
                RowValues = new ArrayList() { std.stdID, std.stdName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByCourse(int CourseID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                students = (from std in context.Students 
                            join enroll in context.Enrollments
                            on std.stdID equals enroll.stdID
                            where enroll.CourseID == CourseID
                            select std).ToList();
            }

            foreach (Student std in students)
            {
                RowValues = new ArrayList() { std.stdID, std.stdName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByInstructor(int CourseInst)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                students = (from std in context.Students
                            join enroll in context.Enrollments
                            on std.stdID equals enroll.stdID
                            join course in context.Courses
                            on enroll.CourseID equals course.CourseID
                            where course.CourseInst == CourseInst
                            select std).ToList();
            }

            foreach (Student std in students)
            {
                RowValues = new ArrayList() { std.stdID, std.stdName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }
        #endregion

        #region add data
        public override void AddItem(int stdID, string stdName)
        {
            using (context = new SchoolEntities())
            {
                context.Students_AddStudent(stdID, stdName);
            }
        }
        #endregion

        #region update data
        public override void UpdateItem(int stdID, string stdName)
        {
            using (context = new SchoolEntities())
            {
                context.Students_UpdateStudent(stdID, stdName);
            }
        }
        #endregion

        #region remove data
        public override void RemoveItem(int stdID)
        {
            using (context = new SchoolEntities())
            {
                context.Students_RemoveStudent(stdID);
            }
        }
        #endregion
    }
}
