namespace Sweeft.Console.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
    }
}
