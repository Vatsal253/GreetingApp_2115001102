﻿using RepositoryLayer.Interface;
using System;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Services
{
    public class GreetingRL : IGreetingRL
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly GreetingContext _context;

        public GreetingRL(GreetingContext context)
        {
            _context = context;
        }
        public bool GreetMessage(GreetingModel greetModel)
        {
            if (_context.GreetMessages.Any(greet => greet.Greeting == greetModel.GreetMessage))
            {
                return false;
            }
            var greetingEntity = new GreetingEntity
            {
                Greeting = greetModel.GreetMessage,
            };
            _context.GreetMessages.Add(greetingEntity);
            _context.SaveChanges();
            return true;
        }
        public string Greeting(UserNameModel userModel)
        {
            string greetingMessage = string.Empty;

            if (!string.IsNullOrEmpty(userModel.FirstName) && !string.IsNullOrEmpty(userModel.LastName))
            {
                greetingMessage = $"Hello {userModel.FirstName} {userModel.LastName}";
            }
            else if (!string.IsNullOrEmpty(userModel.FirstName))
            {
                greetingMessage = $"Hello {userModel.FirstName}";
            }
            else if (!string.IsNullOrEmpty(userModel.LastName))
            {
                greetingMessage = $"Hello {userModel.LastName}";
            }
            else
            {
                greetingMessage = "Hello World";
            }

            _logger.Info($"Generated Greeting: {greetingMessage}");
            return greetingMessage;
        }
        public GreetingModel GetGreetingById(int ID)
        {
            var entity = _context.GreetMessages.FirstOrDefault(g => g.id == ID);

            if (entity != null)
            {
                return new GreetingModel()
                {
                    Id = entity.id,
                    GreetMessage = entity.Greeting
                };
            }
            return null;
        }
        public List<GreetingEntity> GetAllGreetings()
        {
            return _context.GreetMessages.ToList();  // Fetching All Data from Database
        }
        public GreetingEntity EditGreeting(int id, GreetingModel greetingModel)
        {
            var entity = _context.GreetMessages.FirstOrDefault(g => g.id == id);
            if (entity != null)
            {
                entity.Greeting = greetingModel.GreetMessage;
                _context.GreetMessages.Update(entity);
                _context.SaveChanges();
                return entity;
            }
            return null; 
        }
        public bool DeleteGreeting(int id)
        {
            var entity = _context.GreetMessages.FirstOrDefault(g => g.id == id);
            if (entity != null)
            {
                _context.GreetMessages.Remove(entity);
                _context.SaveChanges();
                return true; 
            }
            return false; 
        }




    }
}
