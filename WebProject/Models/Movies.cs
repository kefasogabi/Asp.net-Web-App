﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
      
        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }


        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public byte NumberAvailable { get; set; }


        public DateTime DateAdded { get; set; }


    }
}