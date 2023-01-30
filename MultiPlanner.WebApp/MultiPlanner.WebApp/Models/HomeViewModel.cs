namespace MultiPlanner.WebApp.Models
{
    public class HomeViewModel
    {
        public bool isLoggedIn { get; set; }
        public int numberOfTasks { get; set; }
        public int numberOfSuccededTasks { get; set; }
        public int numberOfOpenTasks { get; set; }
    }
}
