using Assetservice.Data;
using AssetService.Dtos;
using AssetService.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace AssetService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserPublished:
                    AddUser(message);
                    break;
                default:
                    break;
            }
        }


        private EventType DetermineEvent(string notificationMessage) 
        {
            Console.WriteLine("Determining Event...");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event) 
            {
                case "User_Published":
                    Console.WriteLine("user Published Event Detected");
                    return EventType.UserPublished;
                default:
                    Console.WriteLine("Could not determine the event type");
                    return EventType.Undetermined;
            } 
        }

        private void AddUser(string userPublishedMessage) 
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IAssetRepository>();

                var userPublishedDto = JsonSerializer.Deserialize<UserPublishDto>(userPublishedMessage);

                try
                {
                    var user = _mapper.Map<User>(userPublishedDto);
                    if (!repo.ExternalUserExists(user.ExternalId))
                    {
                        repo.CreateUser(user);
                        repo.SaveChanges();
                        Console.WriteLine("User added!");
                    }
                    else
                    {
                        Console.WriteLine("User already exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not add user to db {e.Message}");
                }
            }
        }
    }

    enum EventType 
    { 
        UserPublished,
        Undetermined
    }
}
