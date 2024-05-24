﻿using EarnMoney.Models.Databases;
using Microsoft.EntityFrameworkCore;

namespace EarnMoney.Helpers.Database
{
    public class DatabaseInitializer
    {
        private readonly IServiceProvider serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Initialize()
        {
            using var scope = serviceProvider.CreateScope();
            var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            appDbContext.Database.EnsureCreated();
            appDbContext.Database.Migrate();
        }
    }
}
