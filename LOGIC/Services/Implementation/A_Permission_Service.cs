
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.A_Permission;
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
    public class A_Permission_Service : IA_Permission_Service
    {
        //Refernce to crud functions
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<A_Permission_ResultSet>> AddSingleA_Permission(int a_permission_id, int album_id, int user_id, string a_permission_type)
        {
            Generic_ResultSet<A_Permission_ResultSet> result = new Generic_ResultSet<A_Permission_ResultSet>();
            
            try
            {
                //INIT NEW DB ENTITY OF A_Permission
                A_Permission A_Permission = new A_Permission
                {
                    A_Permission_ID = a_permission_id,
                    Album_ID = album_id,
                    User_ID = user_id,
                    A_Permission_Type = a_permission_type

                };

                //ADD A_Permission TO DB
                A_Permission = await _crud.Create<A_Permission>(A_Permission);


                //MANUAL MAPPING OF RETURNED A_Permission VALUES TO OUR A_Permission_ResultSet
                A_Permission_ResultSet a_permissionAdded = new A_Permission_ResultSet
                {
                    ////////////////SEE TUTORIAL VIDEO
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied a_permission {0} was added successfully", a_permission_type);
                result.internalMessage = "LOGIC.Services.Implementation.A_Permission_Service: AddSingleA_Permission() method executed successfully.";
                result.result_set = a_permissionAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the a_permission supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.A_Permission_Service: AddSingleA_Permission(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<A_Permission_ResultSet>>> GetAllA_Permissions()
        {
            Generic_ResultSet<List<A_Permission_ResultSet>> result = new Generic_ResultSet<List<A_Permission_ResultSet>>();
            try
            {
                //GET ALL A_Permissions
                List<A_Permission> A_Permissions = await _crud.ReadAll<A_Permission>();
                //MAP DB A_Permission RESULTS
                result.result_set = new List<A_Permission_ResultSet>();
                A_Permissions.ForEach(dg => {
                    result.result_set.Add(new A_Permission_ResultSet
                    {
                        a_permission_id = dg.A_Permission_ID,
                        album_id = dg.Album_ID,
                        user_id = dg.User_ID,
                        a_permission_type = dg.A_Permission_Type,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All a_permissions obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.A_Permissions_Service: GetAlla_permissions() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required a_permissions from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.A_Permission_Service: GetAllA_Permissions(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<A_Permission_ResultSet>> UpdateA_Permission(int a_permission_id, int album_id, int user_id, string a_permission_type)
        {
            Generic_ResultSet<A_Permission_ResultSet> result = new Generic_ResultSet<A_Permission_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF A_Permission
                A_Permission A_Permission = new A_Permission
                {
                    A_Permission_ID = a_permission_id,
                    Album_ID = album_id,
                    User_ID = user_id,
                    A_Permission_Type = a_permission_type
                };

                //ADD A_Permission TO DB
                A_Permission = await _crud.Update<A_Permission>(A_Permission, a_permission_id);

                //MANUAL MAPPING OF RETURNED A_Permission VALUES TO OUR A_Permission_ResultSet
                A_Permission_ResultSet a_permissionUpdated = new A_Permission_ResultSet
                {
                    ////////////////SEE TUTORIAL VIDEO
                };

                //SET SUCCESSFUL RESULT VALUES


                result.userMessage = string.Format("The supplied a_permission {0} was updated successfully", a_permission_type);
                result.internalMessage = "LOGIC.Services.Implementation.A_Permission_Service: UpdateA_Permission() method executed successfully.";
                result.result_set = a_permissionUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the a_permission supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateA_Permission: AddSingleA_Permission(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}