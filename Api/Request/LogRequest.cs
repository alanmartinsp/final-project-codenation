namespace Api.Request
{
    public class LogRequest
    {
        public Business.Models.Log.Type Level { get; set; }
        public int Event { get; set; }
        public string Title { get; set; }
        public string Origin { get; set; }
        public string Details { get; set; }
        public Business.Models.Log.TypeEnviroment Enviroment { get; set; }
    }
}
