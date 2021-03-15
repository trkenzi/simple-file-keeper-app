using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.BusinessLayer.Contracts.DTOs
{
    public class PhotoRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhotoUrl { get; set; }
    }
}
