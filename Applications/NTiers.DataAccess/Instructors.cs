using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NTiers.Entities;

namespace NTiers.DataLayer
{
    public class Instructors : DataManager
    {
        private List<Instructor> instructors;

        #region constructor
        public Instructors()
        {
            columns = new string[] { "Instructor ID", "Instructor Name" };
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
                instructors = (from inst in context.Instructors select inst).ToList();
            }
            
            foreach (Instructor inst in instructors)
            {
                RowValues = new ArrayList() { inst.InstID, inst.InstName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByStudent(int stdID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                instructors = (from inst in context.Instructors
                               join crs in context.Courses
                               on inst.InstID equals crs.CourseInst
                               join enroll in context.Enrollments
                               on crs.CourseID equals enroll.CourseID
                               where enroll.stdID == stdID
                               select inst).ToList();
            }

            foreach (Instructor inst in instructors)
            {
                RowValues = new ArrayList() { inst.InstID, inst.InstName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }

        public override DataTable GetByCourse(int CourseID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                instructors = (from inst in context.Instructors
                               join crs in context.Courses
                               on inst.InstID equals crs.CourseInst
                               where crs.CourseID == CourseID
                               select inst).ToList();
            }
            foreach (Instructor inst in instructors)
            {
                RowValues = new ArrayList() { inst.InstID, inst.InstName };
                AddToDataTable(columns, RowValues);
            }
            
            return dataTable;
        }

        public override DataTable GetByInstructor(int InstID)
        {
            dataTable.Rows.Clear();

            using (context = new SchoolEntities())
            {
                instructors = (from inst in context.Instructors where inst.InstID == InstID select inst).ToList();
            }

            foreach (Instructor inst in instructors)
            {
                RowValues = new ArrayList() { inst.InstID, inst.InstName };
                AddToDataTable(columns, RowValues);
            }

            return dataTable;
        }
        #endregion

        #region add date
        public override void AddItem(int InstID, string InstName)
        {
            using (context = new SchoolEntities())
            {
                context.Instrucors_AddInstructor(InstID, InstName);
            }
        }
        #endregion

        #region update date
        public override void UpdateItem(int InstID, string InstName)
        {
            using (context = new SchoolEntities())
            {
                context.Instructors_UpdateInstructor(InstID, InstName);
            }
        }
        #endregion

        #region remove date
        public override void RemoveItem(int InstID)
        {
            using (context = new SchoolEntities())
            {
                context.Instructors_RemoveInstructor(InstID);
            }
        }
        #endregion
    }
}
