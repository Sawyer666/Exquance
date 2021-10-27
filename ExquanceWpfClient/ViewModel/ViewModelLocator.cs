using Microsoft.Extensions.DependencyInjection;

namespace ExquanceWpfClient.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
    }
}