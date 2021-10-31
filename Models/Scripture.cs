using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Book { get; set; }

        [Range(1, 300), DataType(DataType.Text)]
        public int Chapter { get; set; }

        [Range(1, 300), DataType(DataType.Text)]
        public int Verse { get; set; }

        [StringLength(180, MinimumLength = 3)]
        public string Note { get; set; }

        [Display(Name = "Journal Entry Date"), DataType(DataType.Date)]
        public DateTime JournalEntryDate { get; set; }
    }
}