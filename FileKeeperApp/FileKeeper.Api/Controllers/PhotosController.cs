using FileKeeper.BusinessLayer.Contracts.Contracts;
using FileKeeper.BusinessLayer.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace FileKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        IPhotoService photoService;

        public PhotosController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhotoResponseDTO>> GetAllPhotos()
        {
            return Ok(photoService.GetAllPhotos());
        }

        [HttpPost]
        public ActionResult<PhotoResponseDTO> AddNewPhoto([FromBody] PhotoRequestDTO photoData)
        {
            try
            {
                PhotoResponseDTO createdPhoto = photoService.AddNewPhoto(photoData);
                return Ok(createdPhoto);
            }
            catch(ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePhoto(int id)
        {
            try
            {
                photoService.DeletePhoto(id);
                return NoContent();
            }
            catch(ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{photoId}")]
        public ActionResult<PhotoResponseDTO> UpdatePhoto(int photoId, [FromBody] PhotoRequestDTO photoData)
        {
            try
            {
                PhotoResponseDTO updatedPhoto = photoService.UpdatePhoto(photoId, photoData);
                return updatedPhoto;
            }
            catch(ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }
            catch(ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
  
        }

    }
}
