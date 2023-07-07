namespace Api.Megaman.Application.Services
{
    using Api.Megaman.Application.DTO;
    using System;
    using System.Collections.Generic;
    public interface IRobotServices
    {
         IEnumerable<RobotReadDTO> SearchAll();
        RobotReadDTO SearchById(Int32 id);
        void AddRobot(RobotCreateDTO entity);
    }
}