﻿using MovieApp.Shared.Models;
using System.Collections.Generic;

namespace MovieApp.Shared.DTOs
{
    public class DetailsMovieDTO
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Person> Actors { get; set; }
    }
}
