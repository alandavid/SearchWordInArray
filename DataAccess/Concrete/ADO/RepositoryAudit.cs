using DataAccess.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Common.Entities;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DataAccess.Concrete.ADO
{
    public class RepositoryAudit : Repository, IRepository<Audit>
    {
        public int Save(Audit entity)
        {
            try
            {
                var query = BuildQueryInsert(typeof(Audit), "table_audit");

                return ExecuteSPNonQuery(query,
                     new List<SqlParameter> {
                     new SqlParameter() {ParameterName = "@Result", SqlDbType = SqlDbType.NVarChar, Value= entity.Result},
                     new SqlParameter() {ParameterName = "@InitialDate", SqlDbType = SqlDbType.DateTime, Value = entity.InitialDate},
                     new SqlParameter() {ParameterName = "@Usuario", SqlDbType = SqlDbType.NVarChar, Value = entity.Usuario},
                        new SqlParameter() {ParameterName = "@Word", SqlDbType = SqlDbType.NVarChar, Value = entity.Word}}
                     );
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }

     

        public IList<Audit> GetAll()
        {
            List<Audit> resultList = new List<Audit>();
            var query = BuildQuerySelect(typeof(Audit), "table_audit");

            var reader = ExecuteReader(query);
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    resultList.Add(
                        new Audit
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            InitialDate = DateTime.Parse(reader["InitialDate"].ToString()),
                            Result = reader["Result"].ToString(),
                            Usuario = reader["Usuario"].ToString(),
                            Word = reader["Word"].ToString()
                        }
                        );
                }
            }
            return resultList;

        }





    }
}
