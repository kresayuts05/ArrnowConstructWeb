﻿using ArrnowConstruct.Infrastructure.Data.Confuguration;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArrnowConstruct.Infrastructure.Data
{
    public class ArrnowConstructDbContext : IdentityDbContext<User>
    {
        public ArrnowConstructDbContext(DbContextOptions<ArrnowConstructDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLikes> PostsLikes { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<PostLikes>().HasKey(k => new
            {
                k.PostId,
                k.UserId,
            });

            //builder.Entity<ChatMessage>()
            //  .HasMany(e => e.ChatImages)
            //  .WithOne(e => e.ChatMessage)
            //  .HasForeignKey(e => e.ChatMessageId)
            //  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
              new IdentityRole {
                Id ="25f73449-f9e8-40b4-87ee-93fc6c242339" ,
                Name = "Client",
                NormalizedName = "CLIENT"
              },
              new IdentityRole {
                Id = "eed2d778-89cf-4c3c-a710-c8d61811f4c7",
                Name = "Constructor",
                NormalizedName = "CONSTRUCTOR"
              },
            });

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ConstructorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}