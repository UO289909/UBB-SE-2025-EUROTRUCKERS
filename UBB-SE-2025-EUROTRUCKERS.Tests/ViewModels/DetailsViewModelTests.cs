using FluentAssertions;
using Moq;
using UBB_SE_2025_EUROTRUCKERS.Models;
using UBB_SE_2025_EUROTRUCKERS.Services;
using UBB_SE_2025_EUROTRUCKERS.ViewModels;
using Xunit;

namespace UBB_SE_2025_EUROTRUCKERS.Tests.ViewModels
{
    public class DetailsViewModelTests
    {
        private readonly Mock<INavigationService> _navigationServiceMock;

        public DetailsViewModelTests()
        {
            _navigationServiceMock = new Mock<INavigationService>();
        }

        [Fact]
        public void DetailsViewModel_WhenCreated_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var viewModel = new DetailsViewModel(_navigationServiceMock.Object);

            // Assert
            viewModel.Title.Should().Be("Delivery Details");
            viewModel.SelectedDelivery.Should().BeNull();
        }

        [Fact]
        public void DetailsViewModel_WhenSelectedDeliverySet_ShouldUpdateProperty()
        {
            // Arrange
            var viewModel = new DetailsViewModel(_navigationServiceMock.Object);
            var delivery = new Delivery { delivery_id = 1, reference_number = "TEST123" };

            // Act
            viewModel.SelectedDelivery = delivery;

            // Assert
            viewModel.SelectedDelivery.Should().NotBeNull();
            viewModel.SelectedDelivery.delivery_id.Should().Be(1);
            viewModel.SelectedDelivery.reference_number.Should().Be("TEST123");
        }

        [Fact]
        public void DetailsViewModel_WhenSelectedDeliverySetToNull_ShouldUpdateProperty()
        {
            // Arrange
            var viewModel = new DetailsViewModel(_navigationServiceMock.Object);
            var delivery = new Delivery { delivery_id = 1 };
            viewModel.SelectedDelivery = delivery;

            // Act
            viewModel.SelectedDelivery = null;

            // Assert
            viewModel.SelectedDelivery.Should().BeNull();
        }
    }
} 