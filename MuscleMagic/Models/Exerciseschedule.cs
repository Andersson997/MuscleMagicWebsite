using System;
namespace MuscleMagic.Models
{
    public class Exerciseschedule
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public List<User> Users { get; set; }
        public Exerciseschedule(string ProgramName)
        {
            this.ProgramName = ProgramName;
        }
    }
}

