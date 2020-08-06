using Vocabulary.DataAccess.Models;

namespace Vocabilary.Views.Converters
{
    public class VmWordExampleConverter : IViewModelConverter<WordExample, WordExampleView>
    {
        public WordExample ToModel(WordExampleView view)
        {
            return new WordExample
            {
                Id = view.Id,
                WordId = view.WordId,
                Value = view.Value,
                Translation = view.Translation
            };
        }

        public WordExampleView ToView(WordExample model)
        {
            return new WordExampleView
            {
                Id = model.Id,
                WordId = model.WordId,
                Value = model.Value,
                Translation = model.Translation
            };
        }
    }
}