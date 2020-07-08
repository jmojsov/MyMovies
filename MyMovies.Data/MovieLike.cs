using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMovies.Data
{
    public class MovieLike
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public bool Status { get; set; }
        public virtual User User{ get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual Movie Moive { get; set; }
    }
}
