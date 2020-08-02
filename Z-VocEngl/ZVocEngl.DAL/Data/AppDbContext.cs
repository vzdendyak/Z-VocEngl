using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.DAL.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }

        public DbSet<Vocabularies> Vocabularies { get; set; }
        public DbSet<CollocationWords> CollocationWords { get; set; }
        public DbSet<DefinitionSynonyms> DefinitionSynonyms { get; set; }
        public DbSet<Examples> Examples { get; set; }
        public DbSet<PartsOfSpeeches> PartsOfSpeeches { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<VocabulariesWords> VocabulariesWords { get; set; }
        public DbSet<WordInformations> WordInformations { get; set; }
        public DbSet<Words> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Vocabularies>()
                .HasOne(v => v.User)
                .WithMany(u => u.Vocabularies)
                .HasForeignKey(v => v.UserId);

            builder.Entity<VocabulariesWords>()
                .HasOne(e => e.Word)
                .WithMany(e => e.VocabulariesWords)
                .HasForeignKey(k => k.WordId);
            builder.Entity<VocabulariesWords>()
                .HasOne(e => e.Vocabulary)
                .WithMany(e => e.VocabulariesWords)
                .HasForeignKey(k => k.VocabularyId);

            builder.Entity<WordInformations>()
                .HasOne(e => e.Word)
                .WithMany(e => e.WordInformations)
                .HasForeignKey(k => k.WordId);

            builder.Entity<WordInformations>()
                .HasOne(o => o.Type)
                .WithMany(m => m.WordInformations)
                .HasForeignKey(k => k.TypeId);

            builder.Entity<WordInformations>()
                .HasOne(o => o.PartOfSpeech)
                .WithMany(m => m.WordInformations)
                .HasForeignKey(k => k.PartOfSpeechId);

            builder.Entity<Examples>()
                .HasOne(o => o.WordInformation)
                .WithMany(m => m.Examples)
                .HasForeignKey(k => k.WordInformationId);

            builder.Entity<DefinitionSynonyms>()
                .HasOne(o => o.WordInformation)
                .WithMany(m => m.DefinitionSynonyms)
                .HasForeignKey(k => k.WordInformationId);

            builder.Entity<CollocationWords>()
                .HasOne(o => o.WordInformation)
                .WithMany(m => m.CollocationWords)
                .HasForeignKey(k => k.WordInformationId);
        }
    }
}