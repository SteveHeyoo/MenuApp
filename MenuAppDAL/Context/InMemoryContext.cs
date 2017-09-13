using MenuAppEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
                new DbContextOptionsBuilder<InMemoryContext>()
                    .UseInMemoryDatabase("TheDB")
                    .Options;

        //Options explaining what we want in Memory
        public InMemoryContext() : base(options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }
    }
}
