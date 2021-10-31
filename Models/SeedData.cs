using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any Scriptures.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = 3,
                        Verse = 5,
                        Note = "My favorite scripture",
                        JournalEntryDate = DateTime.Parse("2020-3-12")
                    },

                    new Scripture
                    {
                        Book = "John",
                        Chapter = 31,
                        Verse = 2,
                        Note = "How does he do this.",
                        JournalEntryDate = DateTime.Parse("2021-6-3")
                    },

                    new Scripture
                    {
                        Book = "1 Nephi",
                        Chapter = 13,
                        Verse = 52,
                        Note = "My wifes favorite scripture.",
                        JournalEntryDate = DateTime.Parse("2019-10-25")
                    },

                    new Scripture
                    {
                        Book = "Exodus",
                        Chapter = 8,
                        Verse = 25,
                        Note = "Look more into this.",
                        JournalEntryDate = DateTime.Parse("2021-5-2")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}