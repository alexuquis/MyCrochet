using System.Windows;
using MyCrochetWpf.Data;
using MyCrochetWpf.Views;

namespace MyCrochetWpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Db.EnsureDatabase();
            Schema.EnsureCreated();

            base.OnStartup(e);

            // Fase C: el flujo real arranca en el Login (como Form1 → FmInicio).
            new LoginWindow().Show();
        }
    }
}
