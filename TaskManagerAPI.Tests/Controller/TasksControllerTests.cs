using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Xunit;

using TaskManagerAPI.Controllers;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;


namespace TaskManagerAPI.Tests.Controller
{
    public class TasksControllerTests
    {
        private readonly AppDbContext _context;
        private readonly TasksController _controller;

        public TasksControllerTests()
        {
          
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new AppDbContext(options);


            _controller = new TasksController(_context);
        }

        [Fact]
        public async Task GetTask_ReturnsOkResult_WithTask_FromRealDb()
        {
            int existingTaskId = 1;  
            var result = await _controller.GetTask(existingTaskId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var task = Assert.IsType<TaskItem>(okResult.Value);
            Assert.Equal(existingTaskId, task.Id);
        }

        [Fact]
        public async Task GetTask_ReturnsNotFound_ForNonExistingId()
        {
            int nonExistingTaskId = 999999; 
            var result = await _controller.GetTask(nonExistingTaskId);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
