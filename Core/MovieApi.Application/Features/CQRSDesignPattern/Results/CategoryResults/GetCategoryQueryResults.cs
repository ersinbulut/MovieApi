﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults
{
    public class GetCategoryQueryResults
    {
        public int CategoryID { get; set; }
        public int CategoryName { get; set; }
    }
}
