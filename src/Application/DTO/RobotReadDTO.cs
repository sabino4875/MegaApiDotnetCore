namespace Api.Megaman.Application.DTO
{
    using System;
    public sealed class RobotReadDTO
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Int32 HP { get; set; }
        public String Picture { get; set; }
    }
}