using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using VisaApplication.Modals;

namespace VisaApplication.DataBaseLayer
{
    public class VisaDBLayer
    {
        static string connectionString = "Data Source=server_name;Initial Catalog=database_name;User ID=user_name;Password=password;";
        public bool CreateUser(User user)
        {
            try
            {
                using (SqlConnection con=new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "select Count(UserId) from Users";
                    SqlCommand cmd = new SqlCommand(query,con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    int userIdCount = 0;
                    while(sdr.Read())
                    {
                        int count = int.Parse(sdr[0].ToString());
                        if (count>0)
                        {
                            userIdCount = count + 1;
                        }
                    }
                    sdr.Close();
                    query = "insert into Users (UserId,UserName,Password,Email) Values ('"+userIdCount+"','"+user.UserName+"','"+user.Password+"','"+user.UserName+"')";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool validateUser(User user)
        {
            bool isuserFound = false;
            try
            {
                using (SqlConnection con= new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "select Password where UserName='"+user.UserName+"'";
                    SqlCommand cmd = new SqlCommand(query,con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        string password = reader[0].ToString();
                        if (password==user.Password)
                        {
                            isuserFound = true;
                        }
                    }
                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                return false; ;
            }
            return isuserFound;
        }
        public void CreateApplication(VisaApplicationModel application)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO VisaApplications (UserID, UserName, PassportCopy, VisaType, CountryOfApplication, ApplicationStatus) VALUES (@UserID, @UserName, @PassportCopy, @VisaType, @CountryOfApplication, @ApplicationStatus)", con);
                cmd.Parameters.AddWithValue("@UserID", application.UserID);
                cmd.Parameters.AddWithValue("@UserName", application.UserName);
                cmd.Parameters.AddWithValue("@PassportCopy", application.PassportCopy);
                cmd.Parameters.AddWithValue("@VisaType", application.VisaType);
                cmd.Parameters.AddWithValue("@CountryOfApplication", application.CountryOfApplication);
                cmd.Parameters.AddWithValue("@ApplicationStatus", application.ApplicationStatus);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable GetApplications(int? userID = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VisaApplications WHERE @UserID IS NULL OR UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userID.HasValue ? (object)userID.Value : DBNull.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void UpdateApplicationStatus(int applicationID, string status)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE VisaApplications SET ApplicationStatus = @Status WHERE ApplicationID = @ApplicationID", con);
                cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                cmd.Parameters.AddWithValue("@Status", status);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteApplication(int applicationID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM VisaApplications WHERE ApplicationID = @ApplicationID", con);
                cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}