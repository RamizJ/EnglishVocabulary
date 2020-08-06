using System.Linq;
using Vocabulary.DataAccess.Models;

namespace Vocabilary.Views.Converters
{
    public class VmWordConverter : IViewModelConverter<Word, WordView>
    {
        public VmWordConverter(VmWordExampleConverter wordExampleConverter)
        {
            _wordExampleConverter = wordExampleConverter;
        }

        public Word ToModel(WordView view)
        {
            return new Word
            {
                Id = view.Id,
                WordSetId = view.WordSetId,
                Value = view.Value,
                Definition = view.Definition,
                Translation = view.Translation,
                Examples = view.Examples
                    .Select(e => _wordExampleConverter.ToModel(e))
                    .ToList()
            };
        }

        public WordView ToView(Word model)
        {
            return new WordView
            {
                Id = model.Id,
                WordSetId = model.WordSetId,
                Value = model.Value,
                Definition = model.Definition,
                Translation = model.Translation,
                Examples = model.Examples
                    .Select(e => _wordExampleConverter.ToView(e))
                    .ToList()
            };
        }


        private readonly VmWordExampleConverter _wordExampleConverter;
    }
}