using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeekSeatWitchSaga.Models;

namespace GeekSeatWitchSaga.Data
{
    public class GeekSeatWitchSagaContext : DbContext
    {
        public GeekSeatWitchSagaContext (DbContextOptions<GeekSeatWitchSagaContext> options)
            : base(options)
        {
        }

        public DbSet<GeekSeatWitchSaga.Models.Villager> Villager { get; set; } = default!;
    }
}
