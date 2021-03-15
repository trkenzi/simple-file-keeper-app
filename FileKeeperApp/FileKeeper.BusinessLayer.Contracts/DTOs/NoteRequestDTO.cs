using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.BusinessLayer.Contracts.DTOs
{
    public class NoteRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ImportantDate { get; set; }

    }
}
