using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FastFood.Data
{
    public class FastFoodContextDesignTimeFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FastFoodContext>();
            builder.UseSqlServer(@"Server=DESKTOP-L3ARJIL\\SQLEXPRESS;Database=FastFood;Trusted_Connection=True;MultipleActiveResultSets=true");
            //builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new FastFoodContext(builder.Options);
        }
    }
}
