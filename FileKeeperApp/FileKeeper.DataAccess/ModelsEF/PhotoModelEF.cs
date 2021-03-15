using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FileKeeper.DataAccess.ModelsEF
{
    public class PhotoModelEF
    {
        public PhotoModelEF() { }

        public PhotoModelEF(string title, string description, DateTime creationDate, string photoUrl)
        {
            Title = title;
            Description = description;
            CreationDate = creationDate;
            PhotoUrl = photoUrl;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhotoUrl { get; set; }

    }
}
