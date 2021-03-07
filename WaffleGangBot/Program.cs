using System.Threading.Tasks;

namespace WaffleGangBot
{
    class Program
    {
        public static Task Main(string[] args)
            => Startup.RunAsync(args);
    }
}