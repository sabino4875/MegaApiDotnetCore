namespace Api.Megaman.Application.Services
{
    using Api.Megaman.Application.DTO;
    using Api.Megaman.Domain.Models;
    using Api.Megaman.Domain.Repositories;
    using AutoMapper;
    using System.Collections.Generic;
    public class RobotServices : IRobotServices
    {
        private readonly IRobotRepository _repository;
        private readonly IMapper _mapper;
        public RobotServices(IMapper mapper, IRobotRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddRobot(RobotCreateDTO entity)
        {
            var data = _mapper.Map<Robot>(entity);
            _repository.AddRobot(data);
        }

        IEnumerable<RobotReadDTO> IRobotServices.SearchAll()
        {
            return _mapper.Map<IEnumerable<RobotReadDTO>>(_repository.GetAllRobots());
        }

        RobotReadDTO IRobotServices.SearchById(int id)
        {
            var robot = _repository.GetRobotById(id);
            RobotReadDTO robotDTO = null;

            if (robot != null)
            {
                robotDTO = _mapper.Map<RobotReadDTO>(robot);
            }

            return robotDTO;
        }
    }
}