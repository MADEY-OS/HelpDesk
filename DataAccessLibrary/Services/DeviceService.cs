﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLibrary.Data;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly HelpDeskDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeviceService(HelpDeskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DeviceDto GetById(int id)
        {
            var device = _dbContext.Devices.FirstOrDefault(d => d.Id == id);

            if (device is null) return null;
            
            var result = _mapper.Map<DeviceDto>(device);
            
            return result;
        }

        public IEnumerable<DeviceDto> GetAll()
        {
            var devices = _dbContext.Devices.ToList();

            var devicesDto = _mapper.Map<List<DeviceDto>>(devices);

            return devicesDto;
        }

        public int Create(CreateDeviceDto dto)
        {
            var device = _mapper.Map<Device>(dto);
            
            _dbContext.Devices.Add(device);
            _dbContext.SaveChanges();

            return device.Id;
        }

        public bool Delete(int id)
        {
            var device = _dbContext.Devices.FirstOrDefault(d => d.Id == id);
            
            if(device is null) return false;

            _dbContext.Devices.Remove(device);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, CreateDeviceDto dto)
        {
            var device = _dbContext.Devices.FirstOrDefault(d => d.Id == id);

            if(device is null) return false;

            device.Brand = dto.Brand;
            device.Model = dto.Model;
            device.Type = dto.Type;
            device.BuildingId = dto.BuildingId;
            device.UserId = dto.UserId;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
