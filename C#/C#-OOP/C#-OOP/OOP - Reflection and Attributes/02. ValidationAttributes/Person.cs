namespace _02._ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        //[Required]
        [MyRequired]
        public string FullName { get; set; }

        //[Range(12, 90)]
        [MyRange(12, 90)]
        public int Age { get; set; }
    }
}
