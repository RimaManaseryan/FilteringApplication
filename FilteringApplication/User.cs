namespace FilteringApplication
{
    public class User
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public Courses? Course { get; set; }
        public User() { }
        public User(string name, string lname, int age, Courses course)
        {
            Name = name;
            LastName = lname;
            Age = age;
            Course = course;
        }
    }

    public enum Courses
    {
        CSharp,
        JavaScript,
        Html,
        Css,
        FSharp
    }
}

