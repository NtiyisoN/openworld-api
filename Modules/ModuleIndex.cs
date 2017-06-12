namespace OpenWorldAPI.nancyfx.Modules
{
    using Nancy;

    public class ModuleIndex : NancyModule
    {
        public ModuleIndex()
        {
            Get["/"] = parameters => {
                return View["index"];
            };
            Get["/authentication/authenticatecallback?providerkey=facebook"] = paramaters =>
            {
                return View["owUser"];
            };
        }
    }
}