using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.DataAccess.Contracts.Models
{
    public class Note
    {
        public Note() { }
        public Note(int id, string tittle, string description, DateTime importantDate)
        {
            Id = id;
            Title = tittle;
            Description = description;
            ImportantDate = importantDate;
        
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ImportantDate { get; set; }
      
    }
}
