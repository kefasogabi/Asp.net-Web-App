using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebProject.Models;

namespace WebProject.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }


        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }


        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}