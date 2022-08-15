using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace LibraryForCountry
{
    public class EmpDataProvider
    {
        SqlConnection connection=null;
        SqlCommand command = null;
        SqlDataReader reader = null;

        public EmpDataProvider(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public List<Employee> GetEmployees(string name)
        {
            try
            {
                string query = "select EmployeeId,LastName,FirstName,Hiredate,City,Country from Employees where Country=@country";
                command=new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@country", name);
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader=command.ExecuteReader();
                List<Employee> emplist = new List<Employee>();
                while(reader.Read())
                {
                    Employee emp = new Employee();
                    emp.empId = Convert.ToInt32(reader["EmployeeId"].ToString());
                    emp.empfname = reader["FirstName"].ToString();
                    emp.emplname= reader["LastName"].ToString();
                   emp.hiredate = reader["Hiredate"].ToString();
                    emp.city = reader["City"].ToString();
                    emp.country = reader["Country"].ToString();

                    emplist.Add(emp);
                }
                return emplist;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(connection.State==ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<Employee> getCountry()
        {
            try
            {
                string query = "select distinct(Country) from Employees";
                command = new SqlCommand(query, connection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                List<Employee> emplist1 = new List<Employee>();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.country = reader["Country"].ToString();

                    emplist1.Add(emp);
                }
                return emplist1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
