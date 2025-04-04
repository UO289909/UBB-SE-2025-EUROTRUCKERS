using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UBB_SE_2025_EUROTRUCKERS.Models;
using UBB_SE_2025_EUROTRUCKERS.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace UBB_SE_2025_EUROTRUCKERS.ViewModels
{
    public partial class DeliveriesViewModel : ViewModelBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<Delivery> _deliveries = new();

        public DeliveriesViewModel(
            IDeliveryService deliveryService,
            INavigationService navigationService)
        {
            _deliveryService = deliveryService;
            _navigationService = navigationService;
            Title = "Deliveries";
            LoadDeliveriesCommand = new AsyncRelayCommand(LoadDeliveriesAsync);
            NavigateToDetailsCommand = new RelayCommand<Delivery>(NavigateToDetails);

            _ = LoadDeliveriesCommand.ExecuteAsync(null);
        }

        public IAsyncRelayCommand LoadDeliveriesCommand { get; }
        public IRelayCommand<Delivery> NavigateToDetailsCommand { get; }

        private async Task LoadDeliveriesAsync()
        {
            IsBusy = true;
            try
            {
                var deliveries = await _deliveryService.GetActiveDeliveriesAsync();
                Deliveries = new ObservableCollection<Delivery>(deliveries);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void NavigateToDetails(Delivery delivery)
        {
            if (delivery != null)
            {
                _navigationService.NavigateToWithParameter<DetailsViewModel>(delivery);
            }
        }
    }
}