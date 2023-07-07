namespace Api.Megaman.Domain.Repositories
{
    using Api.Megaman.Domain.Models;
    using System;
    using System.Collections.Generic;
    public interface IRobotRepository
    {
        Boolean SaveChanges();
        IEnumerable<Robot> GetAllRobots();
        Robot GetRobotById(Int32 id);
        void AddRobot(Robot robot);
    }
}