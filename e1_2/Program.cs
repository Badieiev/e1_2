using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace e1_2
{
    //—оздать абстрактный класс со свойством Name и абстрактным методом AboutMe()
    //—оздать интерфейсы : летающий обьект, плавающий обьект, бегающий обьект, имеющий двигатель обьект
    //—оздать классы, наследующие абстрактный класс и реализовующий соответствующие интерфейсы: самолет, орел, утка, курица, моторна€ лодка, за€ц
    //—оздать обьекты разработанных классов и продемонстрировать работоспособность методов
    //—оздать два массива-летающие обьекты и плавающие обьекты и вывести информацию о каждом обьекте на экран
    abstract class AbstractClass
    {
        public string Name { get; set; }

        abstract public void AboutMe();
    }

    interface IFly
    {
        void Fly();
    }

    interface ISwim
    {
        void Swim();
    }

    interface IRun
    {
        void Run();
    }

    interface IHaveEngine
    {
        void HaveEngine();
    }

    class Plane : AbstractClass, IFly, IHaveEngine
    {
        public override void AboutMe()
        {
            Console.WriteLine("Every weekend I visit Italy");
        }

        public void Fly()
        {
            Console.WriteLine("I fly fast");
        }

        public void HaveEngine()
        {
            Console.WriteLine("My motors are incredibly powerful");
        }
    }

    class Eagle : AbstractClass, IFly
    {
        public override void AboutMe()
        {
            Console.WriteLine("I have good eyesight"); 
        }

        public void Fly()
        {
            Console.WriteLine("I fly high");
        }
    }

    class Duck : AbstractClass, IFly, ISwim
    {
        public override void AboutMe()
        {
            Console.WriteLine("I can grunt"); 
        }

        public void Fly()
        {
            Console.WriteLine("I fly over the lake");
        }

        public void Swim()
        {
            Console.WriteLine("I love swimming");
        }
    }

    class Chiken : AbstractClass, ISwim, IRun
    {
        public override void AboutMe()
        {
            Console.WriteLine("What used to be an egg or chicken?"); 
        }

        public void Swim()
        {
            Console.WriteLine("I can swim");
        }

        public void Run()
        {
            Console.WriteLine("I love to stroll");
        }
    }

    class Powerboat : AbstractClass, ISwim, IHaveEngine
    {
        public override void AboutMe()
        {
            Console.WriteLine("Sea storm"); 
        }

        public void Swim()
        {
            Console.WriteLine("I swim fast");
        }

        public void HaveEngine()
        {
            Console.WriteLine("My motor is my heart");
        }
    }

    class Rabbit : AbstractClass, IRun
    {
        public override void AboutMe()
        {
            Console.WriteLine("I love carrots");
        }

        public void Run()
        {
            Console.WriteLine("I run fast");
        }
    }

    class Program
    {
        //имена всех методов класса Plane
        static void ListMethods(Plane plane)
        {
            Type t = plane.GetType();
            MethodInfo[] mi = t.GetMethods(System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.DeclaredOnly);

            foreach (MethodInfo m in mi)
                Console.WriteLine("Method: {0}", m.Name);
        }


        static void Main(string[] args)
        {

            Plane pl = new Plane();
            Eagle e = new Eagle();
            Duck d = new Duck();
            Chiken c = new Chiken();
            Powerboat pb = new Powerboat();
            Rabbit r = new Rabbit();

            IFly[] birds = new IFly[] {pl};

            foreach (var bird in birds)
            {
                bird.Fly();
            }

            Program.ListMethods(pl);
            //попытка вывести все классы, кторые реализуют интерфейс IFly
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IFly).IsAssignableFrom(p));
            foreach (var item in types)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
