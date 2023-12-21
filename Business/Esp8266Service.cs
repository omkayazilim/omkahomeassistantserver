﻿using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace Business
{
    public class Esp8266Service : IEsp8266Service
    {
        private readonly IAppDbContext _dbContext;
        public Esp8266Service(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<PortStatResponse> PostPinStat(PortStatDto std)
        {
            string espurl = Environment.GetEnvironmentVariable("ESPURL") ?? "";
            string espset = Environment.GetEnvironmentVariable("ESPSET") ?? "";
            var client = new RestClient(espurl);

            var request = new RestRequest(espset);
            request.AddBody(std);
            var response = client.ExecutePost(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PortStatResponse>>(response.Content);//response.Content.ser;

            else throw response.ErrorException ?? new Exception();
        }

        public List<PortStatResponse> GetPinStat()
        {
            string espurl = Environment.GetEnvironmentVariable("ESPURL") ?? "";
            var client = new RestClient(espurl);
            var request = new RestRequest("getValues");
            var response = client.Get(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PortStatResponse>>(response.Content);//response.Content.ser;
            else throw response.ErrorException ?? new Exception();
        }

        public string getpath()
        {
            var path = _dbContext.getpath();
            return path;
        }

        public async Task<List<PortPropsDto>> GetPortProps()
        {
            var props = await _dbContext.EspPort.Select(x =>
            new PortPropsDto
            {
                 Id = x.Id,
                PortDesc = x.PortDesc,
                PortKey = x.PortKey,
                PortNumber = x.PortNumber,
                PortPropertyType = x.PortPropertyType,
                PortType = x.PortType,
            }
            ).ToListAsync();

            return props;
        }

        public async Task NewPortProp(PortPropsSetRequestDto request)
        {
            var prop = new EspPort
            {
                PortDesc = request.PortDesc,
                PortKey = request.PortKey,
                PortNumber = request.PortNumber,
                PortPropertyType = request.PortPropertyType,
                PortType = request.PortType,
                UpdatedUser=string.Empty,
            };

            _dbContext.EspPort.Add(prop);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdatePortProp(PortPropsSetRequestDto request)
        {
           var prop= await _dbContext.EspPort.SingleAsync(x=>x.Id==request.Id);
            prop.PortDesc = request.PortDesc;
            prop.PortKey = request.PortKey;
            prop.PortNumber = request.PortNumber;
            prop.PortPropertyType = request.PortPropertyType;
            prop.PortType = request.PortType;
            prop.UpdatedUser = "SYS";
            _dbContext.EspPort.Update(prop);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePortProp(long Id)
        {
            var prop = await _dbContext.EspPort.SingleAsync(x => x.Id == Id);
            _dbContext.EspPort.Remove(prop);
            await _dbContext.SaveChangesAsync();
        }

    }
}
