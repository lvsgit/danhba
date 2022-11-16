using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace danhba
{
    internal class Provider
    {
        public string ConnectionString { get; set; } = @"Data Source=localhost\sqlexpress;Initial Catalog=Contacts;Integrated Security=True";

        public DataTable ReadTable(string sql)
        {
            var conn = new SqlConnection(ConnectionString);
            var command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);

            reader.Close();
            conn.Close();

            return table;
        }
    }
}
