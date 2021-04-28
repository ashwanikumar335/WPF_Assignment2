using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using WPF_Assignment2.Model;

namespace WPF_Assignment2.Data
{
    public class DatabaseLayer
    {
        public static string CS = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public static List<User> GetEmployeeFromDatabase()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(CS, CommandType.StoredProcedure, "[dbo].[uspGetUser]");
                var Employee = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new User()
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
        internal static void InsertEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[13];
                MyParams[0] = new SqlParameter("@ID", employee.ID);
                MyParams[1] = new SqlParameter("@FirstName", employee.FirstName);
                MyParams[2] = new SqlParameter("@LastName", employee.LastName);
                MyParams[3] = new SqlParameter("@Gender", employee.Gender);
                MyParams[4] = new SqlParameter("@DOB", employee.DOB);
                MyParams[5] = new SqlParameter("@Language", employee.Language);
                MyParams[6] = new SqlParameter("@Nationality", employee.Nationality);
                MyParams[7] = new SqlParameter("@Address", employee.Address);
                MyParams[8] = new SqlParameter("@Male", employee.Male);
                MyParams[9] = new SqlParameter("@Female", employee.Female);
                MyParams[10] = new SqlParameter("@Hindi", employee.Hindi);
                MyParams[11] = new SqlParameter("@English", employee.English);
                MyParams[12] = new SqlParameter("@French", employee.French);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspInsertUser]", MyParams);
                MessageBox.Show("Data Saved Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void UpdateEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[13];
                MyParams[0] = new SqlParameter("@ID", employee.ID);
                MyParams[1] = new SqlParameter("@FirstName", employee.FirstName);
                MyParams[2] = new SqlParameter("@LastName", employee.LastName);
                MyParams[3] = new SqlParameter("@Gender", employee.Gender);
                MyParams[4] = new SqlParameter("@DOB", employee.DOB);
                MyParams[5] = new SqlParameter("@Language", employee.Language);
                MyParams[6] = new SqlParameter("@Nationality", employee.Nationality);
                MyParams[7] = new SqlParameter("@Address", employee.Address);
                MyParams[8] = new SqlParameter("@Male", employee.Male);
                MyParams[9] = new SqlParameter("@Female", employee.Female);
                MyParams[10] = new SqlParameter("@Hindi", employee.Hindi);
                MyParams[11] = new SqlParameter("@English", employee.English);
                MyParams[12] = new SqlParameter("@French", employee.French);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspUpdateUser]", MyParams);
                MessageBox.Show("Data Updated Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void DeleteEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[1];
                MyParams[0] = new SqlParameter("@ID", employee.ID);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspDeletetUser]", MyParams);
                MessageBox.Show("Data Deleted Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static List<NationalityCollection> GetNationality()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(CS, CommandType.StoredProcedure, "[dbo].[uspGetNationality]");
                var NationalityList = new List<NationalityCollection>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new NationalityCollection()
                    {
                        Nationality = (string)row["Nationality"]
                    };
                    NationalityList.Add(obj);
                }
                return NationalityList;
                // return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Issue> GetIssueList()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(CS, CommandType.StoredProcedure, "[dbo].[uspGetIssues]");
                var Issue = new List<Issue>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new Issue()
                    {
                        IssueID = (string)row["issueId"],
                        Title = (string)row["title"],
                        PostedOn = (string)row["postedOn"],
                        PostedBy = (string)row["postedBy"],
                        Status = (string)row["status"],
                        Priority = (string)row["priority"],
                    };
                    Issue.Add(obj);
                }
                return Issue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void InsertIssue(Issue issue)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[6];
                MyParams[0] = new SqlParameter("@IssueId", issue.IssueID);
                MyParams[1] = new SqlParameter("@Title", issue.Title);
                MyParams[2] = new SqlParameter("@PostedOn", issue.PostedOn);
                MyParams[3] = new SqlParameter("@PostedBy", issue.PostedBy);
                MyParams[4] = new SqlParameter("@Status", issue.Status);
                MyParams[5] = new SqlParameter("@Priority", issue.Priority);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspInsertIssue]", MyParams);
                MessageBox.Show("Issue Saved Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void UpdateIssue(Issue issue)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[6];
                MyParams[0] = new SqlParameter("@IssueId", issue.IssueID);
                MyParams[1] = new SqlParameter("@Title", issue.Title);
                MyParams[2] = new SqlParameter("@PostedOn", issue.PostedOn);
                MyParams[3] = new SqlParameter("@PostedBy", issue.PostedBy);
                MyParams[4] = new SqlParameter("@Status", issue.Status);
                MyParams[5] = new SqlParameter("@Priority", issue.Priority);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspUpdateIssue]", MyParams);
                MessageBox.Show("Issue Updated Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void DeleteIssue(Issue issue)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[1];
                MyParams[0] = new SqlParameter("@IssueId", issue.IssueID);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspDeleteIssue]", MyParams);
                MessageBox.Show("Issue Deleted Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static List<PriorityCollection> GetPriority()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(CS, CommandType.StoredProcedure, "[dbo].[uspGetPriority]");
                var PriorityList = new List<PriorityCollection>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new PriorityCollection()
                    {
                        Priority = (string)row["Priority"]
                    };
                    PriorityList.Add(obj);
                }
                return PriorityList;
                // return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Notice> GetNoticeList()
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(CS, CommandType.StoredProcedure, "[dbo].[uspGetNotice]");
                var Notice = new List<Notice>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new Notice()
                    {
                        NoticeID = (string)row["noticeId"],
                        Title = (string)row["title"],
                        StartDate = (string)row["startdate"],
                        ExpiryDate = (string)row["expirydate"],
                        PostedBy = (string)row["postedBy"],
                    };
                    Notice.Add(obj);
                }
                return Notice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void InsertNotice(Notice notice)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[5];
                MyParams[0] = new SqlParameter("@NoticeId", notice.NoticeID);
                MyParams[1] = new SqlParameter("@Title", notice.Title);
                MyParams[2] = new SqlParameter("@StartDate", notice.StartDate);
                MyParams[3] = new SqlParameter("@ExpiryDate", notice.ExpiryDate);
                MyParams[4] = new SqlParameter("@PostedBy", notice.PostedBy);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspInsertNotice]", MyParams);
                MessageBox.Show("Notice Saved Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void UpdateNotice(Notice notice)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[5];
                MyParams[0] = new SqlParameter("@NoticeID", notice.NoticeID);
                MyParams[1] = new SqlParameter("@Title", notice.Title);
                MyParams[2] = new SqlParameter("@StartDate", notice.StartDate);
                MyParams[3] = new SqlParameter("@ExpiryDate", notice.ExpiryDate);
                MyParams[4] = new SqlParameter("@PostedBy", notice.PostedBy);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspUpdateNotice]", MyParams);
                MessageBox.Show("Notice Updated Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void DeleteNotice(Notice notice)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[1];
                MyParams[0] = new SqlParameter("@NoticeID", notice.NoticeID);
                SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "[dbo].[uspDeleteNotice]", MyParams);
                MessageBox.Show("Notice Deleted Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
