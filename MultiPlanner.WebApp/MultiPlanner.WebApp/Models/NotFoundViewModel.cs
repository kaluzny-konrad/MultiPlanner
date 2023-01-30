namespace MultiPlanner.WebApp.Models
{
    public class NotFoundViewModel
    {
        public NotFoundViewModel(string? message)
        {
            Message = message;
        }

        public string? Message { get; set; }
    }
}
