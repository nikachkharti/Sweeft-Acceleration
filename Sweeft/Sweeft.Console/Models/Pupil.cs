namespace Sweeft.Console.Models
{
    public class Pupil
    {
        public int PupilID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
