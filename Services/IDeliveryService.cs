﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UBB_SE_2025_EUROTRUCKERS.Data;
using UBB_SE_2025_EUROTRUCKERS.Models;

namespace UBB_SE_2025_EUROTRUCKERS.Services
{
    public interface IDeliveryService
    {
        Task<IEnumerable<Delivery>> GetActiveDeliveriesAsync();
        Task<Delivery> GetDeliveryDetailsAsync(int id);
        Task CreateDeliveryAsync(Delivery delivery);
        Task UpdateDeliveryStatusAsync(int deliveryId, string status);
    }

    // Services/DeliveryService.cs
    public class DeliveryService : IDeliveryService
    {
        private readonly IRepository<Delivery> _deliveryRepository;

        public DeliveryService(IRepository<Delivery> deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<IEnumerable<Delivery>> GetActiveDeliveriesAsync()
        {
            return await _deliveryRepository.GetAllAsync();
        }

        public async Task<Delivery> GetDeliveryDetailsAsync(int id)
        {
            return await _deliveryRepository.GetByIdAsync(id);
        }

        public async Task CreateDeliveryAsync(Delivery delivery)
        {
            await _deliveryRepository.AddAsync(delivery);
        }

        public async Task UpdateDeliveryStatusAsync(int deliveryId, string status)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(deliveryId);
            if (delivery != null)
            {
                delivery.Status = status;
                await _deliveryRepository.UpdateAsync(delivery);
            }
        }
    }
}
