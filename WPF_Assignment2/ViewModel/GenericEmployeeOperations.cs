using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.ViewModel
{
    public class GenericEmployeeOperations
    {
        public RegistrationModel RegistrationModel { get; set; }
        public LoginModel LoginModel { get; set; }

        public GenericEmployeeOperations()
        {
            RegistrationModel = new RegistrationModel();
            LoginModel = new LoginModel();
        }


        //CRUD operation

        public int AddNewRecord(string firstname, string lastname, string email, string password, string address, bool check)
        {
            string queryString = "INSERT INTO Registration(FirstName, LastName, Email, Password, Address,UserType) VALUES(@FirstName, @LastName, @Email, @Password, @Address,@UserType)";
            try
            {
                SqlCommand cmd = new SqlCommand(queryString);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", firstname);
                cmd.Parameters.AddWithValue("@LastName", lastname);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@UserType", check);
                int result = DatabaseConnection.ExecuteNonQuery(cmd);
                cmd.Connection.Close();
                return result;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Login(string username, string password)
        {
            string query = "Select * from Registration where Email=@Email AND Password=@Password";
            try
            {
                SqlCommand cmd = new SqlCommand(query);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", username);
                cmd.Parameters.AddWithValue("@Password", password);
                var datatable = DatabaseConnection.GetDataTable(cmd);
                cmd.Connection.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public int EditExistingEmployeeDetails()
        {
            string queryString = "Update Registration set FirstName=@FirstName, LastName=@LastName, Password=@Password, Address=@Address,UserType=@UserType Where Email=@Email";
            try
            {
                SqlCommand cmd = new SqlCommand(queryString);
                cmd.Parameters["@FirstName"].Value = RegistrationModel.textBoxFirstName;
                cmd.Parameters["@LastName"].Value = RegistrationModel.textBoxLastName;
                cmd.Parameters["@Email"].Value = RegistrationModel.textBoxEmail;
                cmd.Parameters["@Password"].Value = RegistrationModel.passwordBox1;
                cmd.Parameters["@Address"].Value = RegistrationModel.textBoxAddress;
                cmd.Parameters["@UserType"].Value = 0;
                int result = DatabaseConnection.ExecuteNonQuery(cmd);
                cmd.Connection.Close();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public List<Model.User> GetEmployeeFromDatabase()
        {
            try
            {
                string query = "Select * from User";
                SqlCommand cmd = new SqlCommand(query);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", LoginModel.textBoxEmail);
                var dt = DatabaseConnection.GetDataTable(cmd);
                var Employee = new List<Model.User>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new Model.User()
                    {
                        ID = (string)row["ID"],
                        FirstName = (string)row["FirstName"],
                        LastName = (string)row["LastName"],
                        DOB = (string)row["DOB"],
                        Gender = (string)row["Gender"],
                        Nationality = (string)row["Nationality"],
                        Language = ((string)row["Language"]),
                        Address = (string)row["Address"],
                        Male = (bool)row["Male"],
                        Female = (bool)row["Female"],
                        Hindi = (bool)row["Hindi"],
                        English = (bool)row["English"],
                        French = (bool)row["French"],
                    };
                    Employee.Add(obj);
                }
                return Employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
