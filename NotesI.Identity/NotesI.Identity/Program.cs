namespace Notes.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuider(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuider(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            webBuilder.UseStartup<Startup>());
    }
}