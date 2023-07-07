namespace Api.Megaman.Domain.Models
{
    using System;

    public class Robot
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Int32 HP { get; set; }
        public String Picture { get; set; }
    }
}