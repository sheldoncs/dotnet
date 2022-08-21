using jwtcore.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtcore.Data.Entities.Dtos
{
    public class FacultyCodeTypeDto
    {
        public FacultyCodeTypeDto()
        {

        }

        [FromQuery(Name="collCode")]
        public FacultyCodeEnum? CollCode { get; set; }

    }
}
