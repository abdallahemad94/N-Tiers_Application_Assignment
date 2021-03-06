﻿using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace NTiers.DataLayer
{
    public abstract class DataManager
    {
        #region Setting connection, command, and parameters
        protected SqlCommand Command;

        /// <summary>
        /// create a sql command object for a given procedure
        /// </summary>
        /// <param name="procedure"></param>
        /// <returns></returns>
        protected void SetCommand(string procedure)
        {
            SqlConnection Conn = new SqlConnection("data source =.; database=School; integrated security=SSPI");
            this.Command = new SqlCommand(procedure, Conn) { CommandType = CommandType.StoredProcedure };
        }

        /// <summary>
        /// add a sql parameters to a given command object
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="NoOfParams"></param>
        /// <param name="ParamsName"></param>
        /// <param name="ParamsValue"></param>
        /// <returns></returns>
        protected void AddParameters(int NoOfParams, string[] ParamsName, ArrayList ParamsValue)
        {
            SqlParameter param = null;
            for (int i = 0; i < NoOfParams; i++)
            {
                param = new SqlParameter(ParamsName[i], ParamsValue[i]) { Direction = ParameterDirection.Input };
                this.Command.Parameters.Add(param);
            }
        }
        #endregion

        #region executing command
        /// <summary>
        /// return the result of executing a given command as a DataTable object
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected DataTable GetData()
        {
            DataTable datatable = new DataTable();
            try
            {
                this.Command.Connection.Open();
                SqlDataReader dataReader = this.Command.ExecuteReader();
                datatable.Load(dataReader);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                this.Command.Connection.Close();
            }
            return datatable;
        }

        protected void ExecuteNonQuery()
        {
            try
            {
                this.Command.Connection.Open();
                this.Command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                this.Command.Connection.Close();
            }
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
