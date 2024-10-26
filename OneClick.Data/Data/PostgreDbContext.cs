﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OneClick.Data.Data
{
    public class PostgreDbContext(DbContextOptions<PostgreDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Project>? Projects { get; set; }
        public DbSet<ProjectData>? ProjectsData { get; set; }
        public DbSet<SystemSettings>? Settings { get; set; }
        public DbSet<AppLog>? Logs { get; set; }
        public DbSet<BalanceTransaction>? Transactions { get; set; }
        public DbSet<TelegramUser>? TelegramUsers { get; set; }
        public DbSet<ProjectDomain>? ProjectDomains { get; set; }
        public DbSet<Referral>? Referrals { get; set; }
    }
}