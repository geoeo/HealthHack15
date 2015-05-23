namespace HealthSdkNancyServer
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "Hello World!";

        }
    }
}