namespace FluentBuilder
{

    public class Person
    {
        public string Name;
        public string Position;

        public class Builder:PersonJobBuilder<Builder>
        {

        }

        public static Builder  New => new Builder();
        public override string? ToString()
        {
            return $"{nameof(Name)}:{Name},{nameof(Position)}: {Position}";
        }
    }


    public class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }
    public class PersonInforBuilder<self>: PersonBuilder
        where self : PersonInforBuilder<self>
    {
        public self Called(string name)
        {
            person.Name = name;
            return (self)this;

        }

    }

    public class PersonJobBuilder<self> : PersonInforBuilder<PersonJobBuilder<self>>
        where self : PersonJobBuilder<self>
    {
        public self WorksAs(string jobtitle)
        {
            person.Position = jobtitle;
            return (self) this;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           var buil =  Person.New.Called("deep").WorksAs("software engineer").Build();
            Console.WriteLine(buil.ToString());
        }
    }
}