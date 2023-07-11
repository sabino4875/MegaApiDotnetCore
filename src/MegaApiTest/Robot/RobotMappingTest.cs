namespace MegaApiTest.Robot
{
    using AutoMapper;
    using System;
    using Xunit;
    using Api.Megaman.Domain.Models;
    using Api.Megaman.Application.DTO;
    using MegaApiTest.Helpers;

    public class RobotMappingTest : IDisposable
    {
        private Boolean _disposable;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;
        public RobotMappingTest()
        {
            _config = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
                "Application"
            }));
            _disposable = true;
            _mapper = _config.CreateMapper(); 
        }

        [Fact(DisplayName = "Validando carregamento da configuração")]
        public void ConfigurationTest()
        {
            //Arrange.
         
            //Action.
            
            //Assert.
            _config.AssertConfigurationIsValid();
        }

        [Fact(DisplayName = "Validando origem para destino")]
        public void SourceToDestinationTest()
        {
            //Arrange.
            Robot source = new()
            {
                Id = 1,
                Name = "Test",
                Code = "Test",
                HP = 1,
                Picture = "Image picture",
            };

            //Action.
            var destination = _mapper.Map<RobotReadDTO>(source);

            //Assert.
            Assert.NotNull(destination);
            CustomEqual.Validate(destination.Id, source.Id, "Invalid informed id");
            CustomEqual.Validate(destination.Name, source.Name, "Invalid informed name");
            CustomEqual.Validate(destination.Code, source.Code, "Invalid informed code");
            CustomEqual.Validate(destination.HP, source.HP, "Invalid informed HP");
            CustomEqual.Validate(destination.Picture, source.Picture, "Invalid informed picture");
        }

        [Fact(DisplayName = "Validando destino para origem")]
        public void DestinationToSourceTest()
        {
            //Arrange.
            RobotReadDTO destination = new()
            {
                Id = 1,
                Name = "Test",
                Code = "Test",
                HP = 1,
                Picture = "Image picture",
            };

            //Action.
            var source = _mapper.Map<Robot>(destination);

            //Assert.
            CustomEqual.Validate(source.Id, destination.Id, "Invalid informed id");
            CustomEqual.Validate(source.Name, destination.Name, "Invalid informed name");
            CustomEqual.Validate(source.Code, destination.Code, "Invalid informed code");
            CustomEqual.Validate(source.HP, destination.HP, "Invalid informed HP");
            CustomEqual.Validate(source.Picture, destination.Picture, "Invalid informed picture");
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (disposing && _disposable)
            {
                _disposable = false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RobotMappingTest()
        {
            Dispose(false);
        }
    }
}
