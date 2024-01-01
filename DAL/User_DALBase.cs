using ApiDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace ApiDemo.DAL
{
    public class User_DALBase: DAL_Helpers
{
        #region SelectAll Users
        public List<UserModel> PR_Select_All_User()
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("API_SELECT_ALL_USER");
                List<UserModel> users = new List<UserModel>();
                using(IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UserModel user = new UserModel();
                        user.UserID = Convert.ToInt32(dr["UserID"]);
                        user.Name = dr["Name"].ToString();
                        user.Contact = dr["Contact"].ToString();
                        user.Email = dr["Email"].ToString();
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Select User By PK

        public UserModel PR_Select_User_By_PK(int UserID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("API_SELECT_BY_PK_USER");
                db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
                UserModel user = new UserModel();
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        user.UserID = Convert.ToInt32(dr["UserID"]);
                        user.Name = dr["Name"].ToString();
                        user.Contact = dr["Contact"].ToString();
                        user.Email = dr["Email"].ToString();
                    }
                       
                    
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Insert User
        public int PR_Insert_User(UserModel user)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("API_INSERT_USER");
                db.AddInParameter(cmd, "@Name", DbType.String, user.Name);
                db.AddInParameter(cmd, "@Contact", DbType.String, user.Contact);
                db.AddInParameter(cmd, "@Email", DbType.String, user.Email);
                int result = db.ExecuteNonQuery(cmd);
                return result;
            }
            catch (Exception ex)

            {
                return 0;
            }
        }
        #endregion

        #region Update User
        public int PR_Update_User(UserModel user)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("API_UPDATE_USER");
                db.AddInParameter(cmd, "@UserID", DbType.Int32, user.UserID);
                db.AddInParameter(cmd, "@Name", DbType.String, user.Name);
                db.AddInParameter(cmd, "@Contact", DbType.String, user.Contact);
                db.AddInParameter(cmd, "@Email", DbType.String, user.Email);
                int result = db.ExecuteNonQuery(cmd);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Delete User
        public int PR_Delete_User(int UserID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("API_DELETE_USER");
                db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
                int result = db.ExecuteNonQuery(cmd);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Filter User
        public List<UserModel> PR_Select_Users_By_Filter(string name, string email = null, string contact = null)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("API_SELECT_USER_BY_FILTER");
                db.AddInParameter(cmd, "@Name", DbType.String, name);
                if (!string.IsNullOrEmpty(email))
                {
                    db.AddInParameter(cmd, "@Email", DbType.String, email);
                }
                if (!string.IsNullOrEmpty(contact))
                {
                    db.AddInParameter(cmd, "@Contact", DbType.String, contact);
                }
                List<UserModel> users = new List<UserModel>();
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        UserModel user = new UserModel();
                        user.UserID = Convert.ToInt32(dr["UserID"]);
                        user.Name = dr["Name"].ToString();
                        user.Contact = dr["Contact"].ToString();
                        user.Email = dr["Email"].ToString();
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


    }
}
