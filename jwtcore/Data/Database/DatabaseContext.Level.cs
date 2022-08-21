using jwtcore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtcore.Data.Database
{
    public partial class DatabaseContext
    {
        public DbSet<Level> Levels { get; set; }

    }
}
