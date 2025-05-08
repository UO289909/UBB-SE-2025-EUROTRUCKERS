using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Moq;
using System;
using UBB_SE_2025_EUROTRUCKERS.Services;
using UBB_SE_2025_EUROTRUCKERS.ViewModels;
using Xunit;

namespace UBB_SE_2025_EUROTRUCKERS.Tests.Services
{
    public class NavigationServiceTests
    {
        private readonly Mock<IServiceProvider> _serviceProviderMock;
        private readonly NavigationService _navigationService;
        private readonly Mock<Frame> _frameMock;

        public NavigationServiceTests()
        {
            _serviceProviderMock = new Mock<IServiceProvider>();
            _frameMock = new Mock<Frame>();
            _navigationService = new NavigationService(_serviceProviderMock.Object);
        }

        [Fact]
        public void NavigationService_WhenCreated_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var service = new NavigationService(_serviceProviderMock.Object);

            // Assert
            service.Should().NotBeNull();
        }

        [Fact]
        public void SetContentFrame_WhenFrameIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange & Act
            Action act = () => _navigationService.SetContentFrame(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetContentFrame_WhenFrameIsValid_ShouldSetFrame()
        {
            // Arrange
            var frame = new Frame();

            // Act
            _navigationService.SetContentFrame(frame);

            // Assert
            // Note: We can't directly test the private field, but we can test the behavior
            _navigationService.CanGoBack().Should().BeFalse();
        }

        [Fact]
        public void NavigateTo_WhenFrameNotSet_ShouldThrowInvalidOperationException()
        {
            // Arrange & Act
            Action act = () => _navigationService.NavigateTo<DetailsViewModel>();

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("ContentFrame no ha sido establecido. Llama a SetContentFrame primero.");
        }

        [Fact]
        public void NavigateToWithParameter_WhenFrameNotSet_ShouldThrowInvalidOperationException()
        {
            // Arrange & Act
            Action act = () => _navigationService.NavigateToWithParameter<DetailsViewModel>(new object());

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("ContentFrame no ha sido establecido");
        }

        [Fact]
        public void NavigateToWithParameter_WhenParameterIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            _navigationService.SetContentFrame(_frameMock.Object);

            // Act
            Action act = () => _navigationService.NavigateToWithParameter<DetailsViewModel>(null);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("El parámetro no puede ser nulo*");
        }

        [Fact]
        public void CanGoBack_WhenFrameNotSet_ShouldReturnFalse()
        {
            // Arrange & Act
            var result = _navigationService.CanGoBack();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void GoBack_WhenFrameNotSet_ShouldNotThrowException()
        {
            // Arrange & Act
            Action act = () => _navigationService.GoBack();

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void GoBack_WhenFrameCanGoBack_ShouldCallFrameGoBack()
        {
            // Arrange
            _frameMock.Setup(f => f.CanGoBack).Returns(true);
            _navigationService.SetContentFrame(_frameMock.Object);

            // Act
            _navigationService.GoBack();

            // Assert
            _frameMock.Verify(f => f.GoBack(), Times.Once);
        }
    }
} 