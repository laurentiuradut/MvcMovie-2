using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class ReviewDto
    {
        public string Name { get; set; }
        public string Review { get; set; }

        public Movie Movie { get; set; }

        public List<MovieReview> ReviewsList { get; set; }

    }
}
