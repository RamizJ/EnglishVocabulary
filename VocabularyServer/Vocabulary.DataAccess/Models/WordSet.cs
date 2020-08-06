using System.Collections.Generic;

namespace Vocabulary.DataAccess.Models
{
    public class WordSet
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Word> Words { get; set; } = new List<Word>();
    }
}
