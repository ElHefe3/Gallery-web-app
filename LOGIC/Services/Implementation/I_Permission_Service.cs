
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.I_Permission;
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
    public class I_Permission_Service : II_Permission_Service
    {
        //Refernce to crud functions
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<I_Permission_ResultSet>> AddSingleI_Permission(int image_id, int user_id, string i_permission_type)
        {
            Generic_ResultSet<I_Permission_ResultSet> result = new Generic_ResultSet<I_Permission_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF I_Permission
                I_Permission I_Permission = new I_Permission
                {
                    Image_ID = image_id,
                    User_ID = user_id,
                    I_Permission_Type = i_permission_type
                   
                };

                //ADD I_Permission TO DB
                I_Permission = await _crud.Create<I_Permission>(I_Permission);


                //MANUAL MAPPING OF RETURNED I_Permission VALUES TO OUR I_Permission_ResultSet
                I_Permission_ResultSet i_permissionAdded = new I_Permission_ResultSet
                {
                    i_permission_id = I_Permission.I_Permission_ID,
                    image_id = I_Permission.Image_ID,
                    user_id = I_Permission.User_ID,
                    i_permission_type = I_Permission.I_Permission_Type

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied i_permission {0} was added successfully", i_permission_type);
                result.internalMessage = "LOGIC.Services.Implementation.I_Permission_Service: AddSingleI_Permission() method executed successfully.";
                result.result_set = i_permissionAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the i_permission supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.I_Permission_Service: AddSingleI_Permission(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<I_Permission_ResultSet>>> GetAllI_Permissions()
        {
            Generic_ResultSet<List<I_Permission_ResultSet>> result = new Generic_ResultSet<List<I_Permission_ResultSet>>();
            try
            {
                //GET ALL I_Permissions
                List<I_Permission> I_Permissions = await _crud.ReadAll<I_Permission>();
                //MAP DB I_Permission RESULTS
                result.result_set = new List<I_Permission_ResultSet>();
                I_Permissions.ForEach(dg => {
                    result.result_set.Add(new I_Permission_ResultSet
                    {
                        i_permission_id = dg.I_Permission_ID,
                        image_id = dg.Image_ID,
                        user_id = dg.User_ID,
                        i_permission_type = dg.I_Permission_Type,
                                  });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All i_permissions obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.I_Permissions_Service: GetAlli_permissions() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required i_permissions from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.I_Permission_Service: GetAllI_Permissions(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<I_Permission_ResultSet>> UpdateI_Permission(int i_permission_id, int image_id, int user_id, string i_permission_type)
        {
            Generic_ResultSet<I_Permission_ResultSet> result = new Generic_ResultSet<I_Permission_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF I_Permission
                I_Permission I_Permission = new I_Permission
                {
                    I_Permission_ID = i_permission_id,
                    Image_ID = image_id,
                    User_ID = user_id,
                    I_Permission_Type = i_permission_type
                };

                //ADD I_Permission TO DB
                I_Permission = await _crud.Update<I_Permission>(I_Permission, i_permission_id);

                //MANUAL MAPPING OF RETURNED I_Permission VALUES TO OUR I_Permission_ResultSet
                I_Permission_ResultSet i_permissionUpdated = new I_Permission_ResultSet
                {
                    i_permission_id = I_Permission.I_Permission_ID,
                    image_id = I_Permission.Image_ID,
                    user_id = I_Permission.User_ID,
                    i_permission_type = I_Permission.I_Permission_Type
                };

                //SET SUCCESSFUL RESULT VALUES


                result.userMessage = string.Format("The supplied i_permission {0} was updated successfully", i_permission_type);
                result.internalMessage = "LOGIC.Services.Implementation.I_Permission_Service: UpdateI_Permission() method executed successfully.";
                result.result_set = i_permissionUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the i_permission supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateI_Permission: AddSingleI_Permission(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}