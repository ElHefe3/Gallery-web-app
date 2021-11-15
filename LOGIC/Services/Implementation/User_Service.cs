
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class User_Service : IUser_Service
    {
        //Refernce to crud functions
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<User_ResultSet>> AddSingleUser(string user_name, string user_surname, string user_email, string user_nickname, string password_hash) 
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {        
                    User_Name = user_name,
                    User_Email = user_email,
                    User_Nickname = user_nickname,
                    User_Surname = user_surname
                };

                //ADD User TO DB
                User = await _crud.Create<User>(User);


                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet userAdded = new User_ResultSet
                {
                    user_id = User.User_ID,
                    user_name = User.User_Name,
                    user_email = User.User_Email,
                    user_nickname = User.User_Nickname,
                    user_surname = User.User_Surname  
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied user {0} was added successfully", user_name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: AddSingleUser() method executed successfully.";
                result.result_set = userAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: AddSingleUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers()
        {
            Generic_ResultSet<List<User_ResultSet>> result = new Generic_ResultSet<List<User_ResultSet>>();
            try
            {
                //GET ALL Users
                List<User> Users = await _crud.ReadAll<User>();
                //MAP DB USERS RESULTS
                result.result_set = new List<User_ResultSet>();
                Users.ForEach(dg => {
                    result.result_set.Add(new User_ResultSet
                    {
                        user_id = dg.User_ID,
                        user_name = dg.User_Name,
                        user_surname = dg.User_Surname,
                        user_email = dg.User_Email,
                        user_nickname = dg.User_Nickname,
                        password_hash = dg.Password_Hash
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All users obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Users_Service: GetAllusers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required users from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetAllUsers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<User_ResultSet>> UpdateUser(int user_id, string user_name, string user_surname, string user_email, string user_nickname, string password_hash) //double check i collection type
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    User_ID = user_id,
                    User_Name = user_name,
                    User_Email = user_email,
                    User_Nickname = user_nickname,
                    User_Surname = user_surname
                };

                //ADD User TO DB
                User = await _crud.Update<User>(User, user_id);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet userUpdated = new User_ResultSet
                {
                    user_id = User.User_ID,
                    user_name = User.User_Name,
                    user_email = User.User_Email,
                    user_nickname = User.User_Nickname,
                    user_surname = User.User_Surname
                };

                //SET SUCCESSFUL RESULT VALUES


                result.userMessage = string.Format("The supplied user {0} was updated successfully", user_name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: UpdateUser() method executed successfully."; 
                result.result_set = userUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateUser: AddSingleUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}