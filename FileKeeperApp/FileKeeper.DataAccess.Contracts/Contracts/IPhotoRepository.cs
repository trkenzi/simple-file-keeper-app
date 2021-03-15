using FileKeeper.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.DataAccess.Contracts.Contracts
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAllPhotos();
        Photo AddNewPhoto(Photo photoData);
        bool DeletePhoto(int photoId);
        Photo UpdatePhoto(int photoId, Photo photoData);
    }
}
