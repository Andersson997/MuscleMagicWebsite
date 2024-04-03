using System;
namespace MuscleMagic.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }

        public Exercise(string ExerciseName, int Repetitions, int Sets)
        {
            this.ExerciseName = ExerciseName;
            this.Repetitions = Repetitions;
            this.Sets = Sets;
        }
    }
}

