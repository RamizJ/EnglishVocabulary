namespace Vocabulary.DataAccess.Models
{
    public class WordExample
    {
        public int Id { get; set; }

        public string Value { get; set; }
        public string Translation { get; set; }

        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}