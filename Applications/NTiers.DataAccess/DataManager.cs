using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NTiers.Entities;

namespace NTiers.DataLayer
{
    public abstract class DataManager
    {
        #region define properities
        protected SchoolEntities context;
        protected DataTable dataTable { get; set; }
        protected string[] columns { get; set; }
        protected Type[] dtypes { get; set; }
        protected ArrayList RowValues { get; set; }
        #endregion

        #region datatable methods
        protected DataTable SetDataTable(string[] columns, Type[] dtypes)
        {
            DataTable dt = new DataTable();
            int NumOfCols = columns.Length;

            for (int i = 0; i < NumOfCols; i++)
            {
                dt.Columns.Add(columns[i], dtypes[i]);
            }

            return dt;
        }
        protected void AddToDataTable(string[] columns, ArrayList values)
        {
            DataRow dr = this.dataTable.NewRow();
            int NumOfCols = columns.Length;

            for (int i = 0; i < NumOfCols; i++)
            {
                dr[columns[i]] = values[i];
            }

            this.dataTable.Rows.Add(dr);
        }
        #endregion

        #region methods to be implemented by derived classes 
        public virtual DataTable GetAll() { return new DataTable(); }
        public virtual DataTable GetByStudent(int stdID) { throw new NotImplementedException(); }
        public virtual DataTable GetByCourse(int CourseID) { throw new NotImplementedException(); }
        public virtual DataTable GetByInstructor(int InstID) { throw new NotImplementedException(); }
        public virtual void AddItem(int id, string name) { throw new NotImplementedException(); }
        public virtual void AddItem(int id1, int id2) { throw new NotImplementedException(); }
        public virtual void AddItem(int id1, string name, string desc, int id2) { throw new NotImplementedException(); }
        public virtual void UpdateItem(int id, string name) { throw new NotImplementedException(); }
        public virtual void UpdateItem(int id1, int id2, int id3) { throw new NotImplementedException(); }
        public virtual void UpdateItem(int id1, string name, string desc, int id2) { throw new NotImplementedException(); }
        public virtual void RemoveItem(int id) { throw new NotImplementedException(); }
        #endregion
    }
}
