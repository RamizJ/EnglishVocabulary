using System.Collections.Generic;

namespace Vocabulary.DataAccess.Models
{
    public class Word
    {
        public int Id { get; set; }

        public int WordSetId { get; set; }
        public WordSet WordSet { get; set; }

        public string Value { get; set; }
        public string Definition { get; set; }
        public string Translation { get; set; }

        public List<WordExample> Examples { get; set; }

    }
}