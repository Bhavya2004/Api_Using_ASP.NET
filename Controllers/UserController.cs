using ApiDemo.BAL;
using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        #region get All Users
        [HttpGet]
        public IActionResult GetAll()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_Select_All_Users();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if(users.Count>0 && users != null)
            {
                response.Add("status", true);
                response.Add("message", "Users Found");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Users Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region get User By ID
        [HttpGet("{UserID}")]
        //[Route("api/[controller]/{UserID}")]
        public IActionResult Get(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel user = bal.PR_Select_User_By_PK(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (user.UserID != 0)
            {
                response.Add("status", true);
                response.Add("message", "User Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "User Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Insert User
        [HttpPost]
        public IActionResult Post(UserModel user)
        {
            User_BALBase bal = new User_BALBase();
            int result = bal.PR_Insert_User(user);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (result > 0)
            {
                response.Add("status", true);
                response.Add("message", "User Inserted");
                response.Add("data", result);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "User Not Inserted");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Update User
        [HttpPut]
        public IActionResult Put(UserModel user)
        {
            User_BALBase bal = new User_BALBase();
            int result = bal.PR_Update_User(user);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (result > 0)
            {
                response.Add("status", true);
                response.Add("message", "User Updated");
                response.Add("data", result);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "User Not Updated");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Delete User
        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            int result = bal.PR_Delete_User(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (result > 0)
            {
                response.Add("status", true);
                response.Add("message", "User Deleted");
                response.Add("data", result);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "User Not Deleted");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Filter User
        [HttpGet("filter/{name}/{email?}/{contact?}")]
        public IActionResult GetByFilter(string name, string email = null, string contact = null)
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_Select_Users_By_Filter(name, email, contact);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (users.Count > 0 && users != null)
            {
                response.Add("status", true);
                response.Add("message", "Users Found");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Users Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

    }
}
