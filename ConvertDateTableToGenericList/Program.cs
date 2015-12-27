using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDateTableToGenericList
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public List<Persons> GetAllEmployees()
        {
            // کانکشن برقرار خواهد
            connection();
            // لیست از اشخاص
            List<Persons> persons = new List<Persons>();
            SqlCommand com = new SqlCommand("GetPersons", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            // Bind Persons generic list using AsEnumerable 
            List<DataRow> list = dt.AsEnumerable().ToList();
            foreach (var item in list)
            {
                persons.Add(

                   new Persons()
                   {
                       Id = Convert.ToInt32(item["Id"]),
                       FirstName = Convert.ToString(item["FirstName"]),
                       LastName = Convert.ToString(item["LastName"]),

                   });
            }
            return persons;
        }
    }
}
