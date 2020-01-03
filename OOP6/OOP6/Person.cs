namespace OOP_5_6
{
    public abstract class Person
    {
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Person: " + Name + ", Age: " + Age;
        }

        public abstract void write();
    }
}
