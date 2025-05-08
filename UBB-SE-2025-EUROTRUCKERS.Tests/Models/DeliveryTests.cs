using System;
using FluentAssertions;
using UBB_SE_2025_EUROTRUCKERS.Models;
using Xunit;

namespace UBB_SE_2025_EUROTRUCKERS.Tests.Models
{
    public class DeliveryTests
    {
        [Fact]
        public void Delivery_WhenCreated_ShouldInitializeStringProperties()
        {
            // Arrange & Act
            var delivery = new Delivery();

            // Assert
            delivery.reference_number.Should().BeEmpty();
            delivery.departure_address.Should().BeEmpty();
            delivery.destination_address.Should().BeEmpty();
            delivery.status.Should().BeEmpty();
            delivery.cargo_description.Should().BeEmpty();
        }

        [Fact]
        public void Delivery_WhenCreated_ShouldInitializeNavigationPropertiesAsNull()
        {
            // Arrange & Act
            var delivery = new Delivery();

            // Assert
            delivery.driver.Should().BeNull();
            delivery.truck.Should().BeNull();
            delivery.company.Should().BeNull();
        }

        [Fact]
        public void Delivery_WhenCreated_ShouldInitializeValueTypesWithDefaults()
        {
            // Arrange & Act
            var delivery = new Delivery();

            // Assert
            delivery.delivery_id.Should().Be(0);
            delivery.driver_id.Should().Be(0);
            delivery.truck_id.Should().Be(0);
            delivery.company_id.Should().Be(0);
            delivery.weight_kg.Should().Be(0);
            delivery.total_distance_km.Should().Be(0);
            delivery.fee_euros.Should().Be(0);
            delivery.departure_time.Should().Be(default(DateTime));
            delivery.estimated_time_arrival.Should().Be(default(DateTime));
        }

        [Fact]
        public void Delivery_WhenPropertiesSet_ShouldStoreValuesCorrectly()
        {
            // Arrange
            var delivery = new Delivery
            {
                delivery_id = 1,
                reference_number = "REF123",
                departure_address = "Start Address",
                destination_address = "End Address",
                departure_time = new DateTime(2024, 3, 20),
                estimated_time_arrival = new DateTime(2024, 3, 21),
                status = "In Transit",
                driver_id = 1,
                truck_id = 1,
                company_id = 1,
                cargo_description = "Test Cargo",
                weight_kg = 1000,
                total_distance_km = 500,
                fee_euros = 1000
            };

            // Act & Assert
            delivery.delivery_id.Should().Be(1);
            delivery.reference_number.Should().Be("REF123");
            delivery.departure_address.Should().Be("Start Address");
            delivery.destination_address.Should().Be("End Address");
            delivery.departure_time.Should().Be(new DateTime(2024, 3, 20));
            delivery.estimated_time_arrival.Should().Be(new DateTime(2024, 3, 21));
            delivery.status.Should().Be("In Transit");
            delivery.driver_id.Should().Be(1);
            delivery.truck_id.Should().Be(1);
            delivery.company_id.Should().Be(1);
            delivery.cargo_description.Should().Be("Test Cargo");
            delivery.weight_kg.Should().Be(1000);
            delivery.total_distance_km.Should().Be(500);
            delivery.fee_euros.Should().Be(1000);
        }
    }
} 