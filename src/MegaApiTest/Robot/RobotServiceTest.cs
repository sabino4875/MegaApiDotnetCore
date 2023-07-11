namespace MegaApiTest.Robot
{
    using Api.Megaman.Application.DTO;
    using Api.Megaman.Application.Services;
    using AutoMapper;
    using System;
    using System.Linq;
    using Xunit;

    public class RobotServiceTest : IDisposable
    {
        private Boolean _disposable;
        private readonly IRobotServices _service;

        public RobotServiceTest() 
        {
            var _config = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
                "Application"
            }));

            _disposable = true;
            _service = new RobotServices(_config.CreateMapper(), new MockRobotRepository());
        }

        [Fact(DisplayName = "Validando método de inclusão de robos")]
        public void Test_AddRobot()
        {
            //Arrange.
            var entity = new RobotCreateDTO() { Name = "Test", Code = "1050", HP = 2500, Picture = "Picture url" };
            //Action.
            _service.AddRobot(entity);
            //Assert.
            Assert.True(_service.SearchById(2) != null, "Robo cadastrado não encontrado.");
        }

        [Fact(DisplayName = "Validando método de listagem de robos")]
        public void Test_ListRobot()
        {
            //Arrange.
            //Action.
            var items = _service.SearchAll();
            //Assert.
            Assert.True(items.Count() > 0, "Listagem sem dados.");
        }

        [Fact(DisplayName = "Validando método de consulta de robos")]
        public void Test_SearchRobot()
        {
            //Arrange.
            //Action.
            var item = _service.SearchById(1);
            //Assert.
            Assert.True(item != null, "Robo não localizado.");
        }


        protected virtual void Dispose(Boolean disposing) 
        { 
            if(disposing && _disposable) 
            {
                _disposable = false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RobotServiceTest()
        {
            Dispose(false);
        }
    }
}
