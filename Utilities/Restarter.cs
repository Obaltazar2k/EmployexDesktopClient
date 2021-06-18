
namespace Employex.Utilities
{
    class Restarter
    {
        public static void RestarEmployex()
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
