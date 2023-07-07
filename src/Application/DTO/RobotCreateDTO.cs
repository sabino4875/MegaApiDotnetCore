namespace Api.Megaman.Application.DTO
{
    using System;
    public sealed class RobotCreateDTO
    {
        public String Name { get; set; }
        public String Code { get; set; }
        public Int32 HP { get; set; }
        public String Picture { get; set; }
    }
}