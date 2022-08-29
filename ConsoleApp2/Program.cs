using System;

namespace ConsoleApp2
{
    public class Shape
    {
       public string GetName()
        {
            return "shape";
        }
    }

    public class Ball : Shape
    {
       new public string GetName()
        {
            return "Ball";
        }
    }

    public class Pet
    {
        public virtual string GetName()
        {
            return "Pet";
        }
    }
    public class Cat : Pet
    {
        public override string GetName()
        {
            return "Cat";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Pet pet = new Cat();
            Shape shape = new Ball();

            Console.WriteLine(string.Format("My {0} is playing with a {1}.", pet.GetName(), shape.GetName()));
        }
    }
}
