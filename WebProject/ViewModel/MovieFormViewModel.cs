using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models;
using System.ComponentModel.DataAnnotations;

namespace WebProject.ViewModel
{
    public class MovieFormViewModel
    {
       

        public IEnumerable<Genre> Genre  { get; set; }
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }


        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel( Movies movies)
        {
            Id = movies.Id;
            Name = movies.Name;
            NumberInStock = movies.NumberInStock;
            GenreId = movies.GenreId;
            ReleaseDate = movies.ReleaseDate;
        }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}