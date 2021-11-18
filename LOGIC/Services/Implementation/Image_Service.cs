
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Image;
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
    public class Image_Service : IImage_Service
    {
        //Refernce to crud functions
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Image_ResultSet>> AddSingleImage(Int64 album_id, DateTime image_captured_date, string image_captured_by, string image_tags, string geolocation)
        {
            Generic_ResultSet<Image_ResultSet> result = new Generic_ResultSet<Image_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Image
                Image Image = new Image
                {
                    Album_ID = album_id,
                    Image_Captured_By = image_captured_by,
                    Image_Tags = image_tags,
                    Geolocation = geolocation

                };

                //ADD Image TO DB
                Image = await _crud.Create<Image>(Image);


                //MANUAL MAPPING OF RETURNED Image VALUES TO OUR Image_ResultSet
                Image_ResultSet imageAdded = new Image_ResultSet
                {
                    image_id = Image.Image_ID,
                    album_id = Image.Album_ID,
                    image_captured_by = Image.Image_Captured_By,
                    image_tags = Image.Image_Tags,
                    geolocation = Image.Geolocation
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied image {0} was added successfully", image_captured_by);// <<=======
                result.internalMessage = "LOGIC.Services.Implementation.Image_Service: AddSingleImage() method executed successfully.";
                result.result_set = imageAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the image supplied. Please try again." + exception.Message;
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Image_Service: AddSingleImage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Image_ResultSet>>> GetAllImages()
        {
            Generic_ResultSet<List<Image_ResultSet>> result = new Generic_ResultSet<List<Image_ResultSet>>();
            try
            {
                //GET ALL Images
                List<Image> Images = await _crud.ReadAll<Image>();
                //MAP DB Image RESULTS
                result.result_set = new List<Image_ResultSet>();
                Images.ForEach(dg => {
                    result.result_set.Add(new Image_ResultSet
                    {
                        image_id = dg.Image_ID,
                        album_id = dg.Album_ID,
                        image_captured_by = dg.Image_Captured_By,
                        image_tags = dg.Image_Tags,
                        geolocation = dg.Geolocation
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All images obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Images_Service: GetAllimages() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required images from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Image_Service: GetAllImages(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Image_ResultSet>> UpdateImage(Int64 image_id, Int64 album_id, DateTime image_captured_date, string image_captured_by, string image_tags, string geolocation)
        {
            Generic_ResultSet<Image_ResultSet> result = new Generic_ResultSet<Image_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Image
                Image Image = new Image
                {
                    Image_ID = image_id,
                    Album_ID = album_id,
                    Image_Captured_By = image_captured_by,
                    Image_Tags = image_tags,
                    Geolocation = geolocation
                };

                //ADD Image TO DB
                Image = await _crud.Update<Image>(Image, image_id);

                //MANUAL MAPPING OF RETURNED Image VALUES TO OUR Image_ResultSet
                Image_ResultSet imageUpdated = new Image_ResultSet
                {
                    image_id = Image.Image_ID,
                    album_id = Image.Album_ID,
                    image_captured_by = Image.Image_Captured_By,
                    image_tags = Image.Image_Tags,
                    geolocation = Image.Geolocation
                };

                //SET SUCCESSFUL RESULT VALUES


                result.userMessage = string.Format("The supplied image {0} was updated successfully", image_id);
                result.internalMessage = "LOGIC.Services.Implementation.Image_Service: UpdateImage() method executed successfully.";
                result.result_set = imageUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the image supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateImage: AddSingleImage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        
        public async Task<Generic_ResultSet<Image_ResultSet>> DeleteImage(Int64 image_id)
        {
            Generic_ResultSet<Image_ResultSet> result = new Generic_ResultSet<Image_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Image
                Image Image = new Image
                {
                    Image_ID = (int)image_id
                };

                //ADD Image TO DB
               bool i_delete = await _crud.Delete<Image>(image_id);

              //SET SUCCESSFUL RESULT VALUES


                result.userMessage = string.Format("The supplied image {0} was deleted successfully", image_id);
                result.internalMessage = "LOGIC.Services.Implementation.Image_Service: DeleteImage() method executed successfully.";
               // result.result_set = imageUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the image supplied. Please try again.{0}" + exception.Message;
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateImage: AddUpdateImage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Image_ResultSet>> GetImageByID(Int64 image_id)
        {
            Generic_ResultSet<Image_ResultSet> result = new Generic_ResultSet<Image_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                Image Image = await _crud.Read<Image>(image_id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Image_ResultSet imageReturned = new Image_ResultSet
                {
                    image_id = Image.Image_ID,
                    album_id = Image.Album_ID,
                    image_captured_by = Image.Image_Captured_By,
                    image_tags = Image.Image_Tags,
                    geolocation = Image.Geolocation
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Applicant {0} was found successfully", imageReturned.image_id);
                result.internalMessage = "LOGIC.Services.Implementation.Applicant_Service: GetApplicantById() method executed successfully.";
                result.result_set = imageReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed find the applicant you are looking for. "+   exception.Message;
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Applicant_Service: AddSingleApplicant(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}