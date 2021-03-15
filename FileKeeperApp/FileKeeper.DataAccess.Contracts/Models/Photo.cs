using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.DataAccess.Contracts.Models
{
    public class Photo
    {
        public Photo() { }
        public Photo(int id, string tittle, string description, string photoUrl, DateTime creationDate)
        {
            Id = id;
            Title = tittle;
            Description = description;
            PhotoUrl = photoUrl;
            CreationDate = creationDate;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
