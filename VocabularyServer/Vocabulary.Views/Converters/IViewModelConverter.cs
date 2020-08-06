namespace Vocabilary.Views.Converters
{
    public interface IViewModelConverter<TModel, TView>
        where TModel : new() where TView : new()
    {
        TModel ToModel(TView view);

        TView ToView(TModel model);
    }
}
