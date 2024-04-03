using System;
namespace MuscleMagic.Models
{
    public class ExerciseListViewModel
    {
        public int ProgramId { get; set; }
        public int UserId { get; set; }
        public List<Exercise> exerciselist1 { get; set; }
        public List<Exercise> exerciselist2 { get; set; }
        public List<Exercise> exerciselist3 { get; set; }
        public List<Exercise> exerciselist4 { get; set; }
    }
}

