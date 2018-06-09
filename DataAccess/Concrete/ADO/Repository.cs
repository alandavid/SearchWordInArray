using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ADO
{
    public abstract class Repository
    {


        public SqlConnection GetConnection()
        {
            //Connection string si pueda sacar de un archivo de configuracion o de una otra fuente
            //para la prueba agregue a mano.

            //var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTelefe;Data Source=DESKTOP-OM1VPVN\\SQLEXPRESS;MultipleActiveResultSets=True");
        }

        public int ExecuteSPNonQuery(string Query, List<SqlParameter> parameters)
        {

            var conn = GetConnection();

            if (conn.State != ConnectionState.Open) conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;
                cmd.Parameters.AddRange(parameters.ToArray());
                //cmd.Parameters.AddWithValue("@pricePoint", paramValue);

                var result = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();

                return result;
            }

        }

        public SqlDataReader ExecuteReader(string Query)
        {

            var conn = GetConnection();

            if (conn.State != ConnectionState.Open) conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;

                //cmd.Parameters.AddWithValue("@pricePoint", paramValue);

                return cmd.ExecuteReader();

            }

        }

        public string BuildQueryInsert(Type type, string tabla)
        {

            string query = "Insert into " + tabla;
            FormatQuery(type.GetProperties().Select(x => { return !x.Name.Equals("Id") ? x.Name : null; }).ToList(), ref query);
            query += "Values";
            FormatQuery(type.GetProperties().Select(x => { return !x.Name.Equals("Id") ? "@" + x.Name : null; }).ToList(), ref query);
            return query;
        }

        public string BuildQuerySelect(Type type, string tabla)
        {

            string query = "Select ";
            FormatQuery(type.GetProperties().Select(x => { return x.Name; }).ToList(), ref query, false);
            query += " from " + tabla;

            return query;
        }

        private void FormatQuery(IList<string> list, ref string query, bool isDelimited = true)
        {

            query += isDelimited ? "(" : string.Empty;
            query += String.Join(",", list.Where(x => x != null));
            query += isDelimited ? ")" : string.Empty;
        }
    }
}
