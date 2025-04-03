using Microsoft.Extensions.DependencyInjection;

using UBB_SE_2025_EUROTRUCKERS.ViewModels;

namespace UBB_SE_2025_EUROTRUCKERS.Views
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.DataContext = App.Services.GetRequiredService<MainViewModel>();

        // Navegación inicial (opcional)
        MainContent.Navigate(typeof(DeliveriesView));
    }
}
