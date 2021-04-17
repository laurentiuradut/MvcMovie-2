using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class MovieReview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }

        public Movie Movie { get; set; }

    }
}
