using System.Threading.Tasks;
using ITCompany.Services;

namespace ITCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var startup = new Startup();
            await startup?.Run();
        }
    }
}