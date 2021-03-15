using AutoMapper;
using FileKeeper.DataAccess.Contracts.Contracts;
using FileKeeper.DataAccess.Contracts.Models;
using FileKeeper.DataAccess.ModelsEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileKeeper.DataAccess.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        FileKeeperDbContext context;
        IMapper mapper;
        public PhotoRepository(FileKeeperDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
       
        public Photo AddNewPhoto(Photo photoData)
        {
            if (photoData == null)
                throw new ArgumentNullException("Photo data can not be null.");

            try
            {
                PhotoModelEF photoModelEF = mapper.Map<PhotoModelEF>(photoData);
                context.Photos.Add(photoModelEF);
                context.SaveChanges();

                return mapper.Map<Photo>(photoModelEF);
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new Exception(exception.Message);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return mapper.Map<IEnumerable<Photo>>(context.Photos.ToList());
        }

        public bool DeletePhoto(int photoId)
        {
            PhotoModelEF photoForDelete = context.Photos.SingleOrDefault(photo => photo.Id == photoId);

            if (photoForDelete == null)
                throw new ArgumentException("Photo with given ID does not exist.");

            try
            {
                context.Photos.Remove(photoForDelete);
                context.SaveChanges();
                return true;
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new Exception(exception.Message);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Photo UpdatePhoto(int photoId, Photo photoData)
        {
            if (photoData == null)
                throw new ArgumentNullException("Photo data can not be null.");

            PhotoModelEF photoForUpdate = context.Photos.SingleOrDefault(photo => photo.Id == photoId);

            if (photoForUpdate == null)
                throw new ArgumentException("Photo with given ID does not exist.");

            try
            {
                photoForUpdate.Title = photoData.Title;
                photoForUpdate.Description = photoData.Description;
                photoForUpdate.CreationDate = photoData.CreationDate;
                photoForUpdate.PhotoUrl = photoData.PhotoUrl;

                context.Photos.Update(photoForUpdate);
                context.SaveChanges();

                return mapper.Map<Photo>(photoForUpdate);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                throw new Exception(exception.Message);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
