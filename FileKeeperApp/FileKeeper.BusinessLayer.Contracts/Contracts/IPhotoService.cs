using FileKeeper.BusinessLayer.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.BusinessLayer.Contracts.Contracts
{
    public interface IPhotoService
    {
        IEnumerable<PhotoResponseDTO> GetAllPhotos();
        PhotoResponseDTO AddNewPhoto(PhotoRequestDTO photoData);
        bool DeletePhoto(int photoId);

        PhotoResponseDTO UpdatePhoto(int photoId, PhotoRequestDTO photoData);

    }
}
