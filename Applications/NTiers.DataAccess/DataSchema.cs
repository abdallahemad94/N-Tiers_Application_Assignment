﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace NTiers.DataAccess
{
    class DataSchema
    {
        private static SqlConnection Conn = null;
        public static DataTable GetSchema(string CollectionName)
        {
            using (Conn = new SqlConnection("data source=localhost; database=School; integrated security=SSPI"))
            {
                Conn.Open();
                return Conn.GetSchema(CollectionName);
            }
        }
    }
}