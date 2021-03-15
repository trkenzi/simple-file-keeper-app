using AutoMapper;
using FileKeeper.BusinessLayer.Contracts.Contracts;
using FileKeeper.BusinessLayer.Contracts.DTOs;
using FileKeeper.DataAccess.Contracts.Contracts;
using FileKeeper.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.BusinessLayer.Services
{
    public class PhotoService : IPhotoService
    {
        IMapper mapper;
        IPhotoRepository repository;
        public PhotoService(IMapper mapper, IPhotoRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public PhotoResponseDTO AddNewPhoto(PhotoRequestDTO photoData)
        {
            if (photoData == null)
                throw new ArgumentNullException("Photo data can not be null.");

            return mapper.Map<PhotoResponseDTO>(repository.AddNewPhoto(mapper.Map<Photo>(photoData)));
        }

        public IEnumerable<PhotoResponseDTO> GetAllPhotos()
        {
            return mapper.Map<IEnumerable<PhotoResponseDTO>>(repository.GetAllPhotos());
        }

        public bool DeletePhoto(int photoId)
        {
            return repository.DeletePhoto(photoId);
        }

        public PhotoResponseDTO UpdatePhoto(int photoId, PhotoRequestDTO photoData)
        {
            if (photoData == null)
                throw new ArgumentNullException("Photo data can not be null.");

            return mapper.Map<PhotoResponseDTO>(repository.UpdatePhoto(photoId, mapper.Map<Photo>(photoData)));
        }
    }
}
