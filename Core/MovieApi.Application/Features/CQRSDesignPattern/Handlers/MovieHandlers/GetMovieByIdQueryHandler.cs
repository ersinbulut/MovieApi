﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResults> Handle(GetMovieByIdQuery query)
        {
            var value =await _context.Movies.FindAsync(query.MovieID);
            return new GetMovieByIdQueryResults
            {
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Duration = value.Duration,
                Rating = value.Rating,
                RealeseDate = value.RealeseDate,
                Status = value.Status,
                Title = value.Title
            };
        }
    }
}
