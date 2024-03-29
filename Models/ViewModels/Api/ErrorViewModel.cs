namespace Models.ViewModels.Api
{
    public class ErrorViewModel
    {
        public List<string> Errors { get; }

        public ErrorViewModel() : this(Array.Empty<string>())
        {
            
        }

        public ErrorViewModel(params string[] errors)
        {
            Errors = errors.Take(1).ToList();
        }
    }
}