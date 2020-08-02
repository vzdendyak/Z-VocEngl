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

        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<CollocationWord> CollocationWords { get; set; }
        public DbSet<DefinitionSynonym> DefinitionSynonyms { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<PartsOfSpeech> PartsOfSpeeches { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<VocabulariesWords> VocabulariesWords { get; set; }
        public DbSet<WordInformation> WordInformations { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Vocabulary>()
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

            builder.Entity<WordInformation>()
                .HasOne(e => e.Word)
                .WithMany(e => e.WordInformations)
                .HasForeignKey(k => k.WordId);

            builder.Entity<WordInformation>()
                .HasOne(o => o.Type)
                .WithMany(m => m.WordInformations)
                .HasForeignKey(k => k.TypeId);

            builder.Entity<WordInformation>()
                .HasOne(o => o.PartOfSpeech)
                .WithMany(m => m.WordInformations)
                .HasForeignKey(k => k.PartOfSpeechId);

            builder.Entity<Example>()
                .HasOne(o => o.WordInformation)
                .WithMany(m => m.Examples)
                .HasForeignKey(k => k.WordInformationId);

            builder.Entity<DefinitionSynonym>()
                .HasOne(o => o.WordInformation)
                .WithMany(m => m.DefinitionSynonyms)
                .HasForeignKey(k => k.WordInformationId);

            builder.Entity<CollocationWord>()
                .HasOne(o => o.WordInformation)
                .WithMany(m => m.CollocationWords)
                .HasForeignKey(k => k.WordInformationId);
        }
    }
}