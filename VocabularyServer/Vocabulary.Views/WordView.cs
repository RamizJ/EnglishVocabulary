using System.Collections.Generic;

namespace Vocabilary.Views
{
    public class WordView   
    {
        public int Id { get; set; }

        public int WordSetId { get; set; }

        public string Value { get; set; }
        public string Definition { get; set; }
        public string Translation { get; set; }

        public List<WordExampleView> Examples { get; set; }
    }
}
