using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WordService
{
    public class WordsContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
    }
}