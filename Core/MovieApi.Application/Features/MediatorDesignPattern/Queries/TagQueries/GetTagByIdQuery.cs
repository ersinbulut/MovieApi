using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagByIdQuery:IRequest<GetTagByIdQueryResult>
    {
        public int TagID { get; set; }

        public GetTagByIdQuery(int tagID)
        {
            TagID = tagID;
        }
    }
}
