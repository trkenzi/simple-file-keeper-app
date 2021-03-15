using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FileKeeper.DataAccess.ModelsEF
{
    public class NoteModelEF
    {

        public NoteModelEF(string title, string description, DateTime importantDate)
        {
            Title = title;
            Description = description;
            ImportantDate = importantDate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ImportantDate { get; set; }
     
    }
}
