namespace MegaApiTest.Robot
{
    using Api.Megaman.Domain.Models;
    using Api.Megaman.Domain.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MockRobotRepository : IRobotRepository
    {
        private readonly List<Robot> Items = new() { 
            new Robot { 
                Id = 1, 
                Name = "Robot Test", 
                Code = "120245", 
                HP = 2500, 
                Picture = "Robot picture asset" 
            } 
        };
        public void AddRobot(Robot robot)
        {
            robot.Id = Items.Count + 1;
            Items.Add(robot);
        }

        public IEnumerable<Robot> GetAllRobots()
        {
            return Items;
        }

        public Robot GetRobotById(Int32 id)
        {
            return Items.Where(e => e.Id == id).FirstOrDefault();
        }

        public Boolean SaveChanges()
        {
            return true;
        }
    }
}
