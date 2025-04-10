using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagByIdQueryResult:IRequest<GetTagByIdQueryResult>
    {
        public int TagID { get; set; }

        public GetTagByIdQueryResult(int tagID)
        {
            TagID = tagID;
        }
    }
}
