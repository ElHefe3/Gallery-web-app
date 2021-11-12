
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Album;
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
    public class Album_Service : IAlbum_Service
    {
        //Refernce to crud functions
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Album_ResultSet>> AddSingleAlbum(int i_permission_id, int image_id, int user_id, string i_permission_type)
        {
            Generic_ResultSet<Album_ResultSet> result = new Generic_ResultSet<Album_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Album
                Album Album = new Album
                {
                    Album_ID = album_id,
                    Album_Name = album_name,
                    Album_Email = album_email,
                    Album_Nickname = album_nickname,
                    Album_Surname = album_surname,
                    A_Permissions = a_permissions,
                    I_Permissions = i_permissions
                };

                //ADD Album TO DB
                Album = await _crud.Create<Album>(Album);


                //MANUAL MAPPING OF RETURNED Album VALUES TO OUR Album_ResultSet
                Album_ResultSet albumAdded = new Album_ResultSet
                {
                    ////////////////SEE TUTORIAL VIDEO
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied album {0} was added successfully", album_name);
                result.internalMessage = "LOGIC.Services.Implementation.Album_Service: AddSingleAlbum() method executed successfully.";
                result.result_set = albumAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the album supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Album_Service: AddSingleAlbum(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Album_ResultSet>>> GetAllAlbums()
        {
            Generic_ResultSet<List<Album_ResultSet>> result = new Generic_ResultSet<List<Album_ResultSet>>();
            try
            {
                //GET ALL Albums
                List<Album> Albums = await _crud.ReadAll<Album>();
                //MAP DB USERS RESULTS
                result.result_set = new List<Album_ResultSet>();
                Albums.ForEach(dg => {
                    result.result_set.Add(new Album_ResultSet
                    {
                        album_id = dg.Album_ID,
                        album_name = dg.Album_Name,
                        album_surname = dg.Album_Surname,
                        album_email = dg.Album_Email,
                        album_nickname = dg.Album_Nickname,
                        password_hash = dg.Password_Hash,
                        i_permissions = dg.I_Permissions, ///bug
                        a_permissions = dg.A_Permissions //bug


                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All albums obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Albums_Service: GetAllalbums() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.albumMessage = "We failed fetch all the required albums from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Album_Service: GetAllAlbums(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Album_ResultSet>> UpdateAlbum(int album_id, string album_name, string album_surname, string album_email, string album_nickname, string password_hash, ICollection<I_Permission> i_permissions, ICollection<A_Permission> a_permissions) //double check i collection type
        {
            Generic_ResultSet<Album_ResultSet> result = new Generic_ResultSet<Album_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Album
                Album Album = new Album
                {
                    Album_ID = album_id,
                    Album_Name = album_name,
                    Album_Email = album_email,
                    Album_Nickname = album_nickname,
                    Album_Surname = album_surname,
                    A_Permissions = a_permissions,
                    I_Permissions = i_permissions
                };

                //ADD Album TO DB
                Album = await _crud.Update<Album>(Album, album_id);

                //MANUAL MAPPING OF RETURNED Album VALUES TO OUR Album_ResultSet
                Album_ResultSet albumUpdated = new Album_ResultSet
                {
                    ////////////////SEE TUTORIAL VIDEO
                };

                //SET SUCCESSFUL RESULT VALUES


                result.albumMessage = string.Format("The supplied album {0} was updated successfully", album_name);
                result.internalMessage = "LOGIC.Services.Implementation.Album_Service: UpdateAlbum() method executed successfully.";
                result.result_set = albumUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.albumMessage = "We failed to update your information for the album supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateAlbum: AddSingleAlbum(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}