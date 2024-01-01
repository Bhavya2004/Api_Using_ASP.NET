using ApiDemo.DAL;
using ApiDemo.Models;

namespace ApiDemo.BAL
{
    public class User_BALBase
    {
        #region SelectAll Users
        public List<UserModel> PR_Select_All_Users()
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> users = user_DALBase.PR_Select_All_User();
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
                User_DALBase user_DALBase = new User_DALBase();
                UserModel user = user_DALBase.PR_Select_User_By_PK(UserID);
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
                User_DALBase user_DALBase = new User_DALBase();
                int result = user_DALBase.PR_Insert_User(user);
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
                User_DALBase user_DALBase = new User_DALBase();
                int result = user_DALBase.PR_Update_User(user);
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
                User_DALBase user_DALBase = new User_DALBase();
                int result = user_DALBase.PR_Delete_User(UserID);
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
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> users = user_DALBase.PR_Select_Users_By_Filter(name, email, contact);
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
