using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World(new WoodWorldFactory());
            world.RunFoodChain();
            world = new World(new SeaWorldFactory());
            world.RunFoodChain();
        }
    }
    class World
    {
        public World(WorldFactory worldFactory)
        {
            plant = worldFactory.CreatePlant();
            herbiwore = worldFactory.CreateHerbiwore();
            predator = worldFactory.CreatePredator();
        }
        private Plant plant;
        private Herbiwore herbiwore;
        private Predator predator;
        public void RunFoodChain()
        {
            plant.Grow();
            herbiwore.Eat(plant);
            predator.Eat(herbiwore);
        }
    }
    abstract class Plant
    {
        public string Name { get; set; }
        public abstract void Grow();
    }
    class Grass : Plant
    {
        public override void Grow()
        {
            Console.WriteLine($"{Name} растет");
        }
    }
    class SeaWeed : Plant
    {
        public override void Grow()
        {
            Console.WriteLine($"{Name} растет");
        }
    }
    abstract class Herbiwore
    {
        public string Name { get; set; }
        public abstract void Eat(Plant plant);
    }
    class Rabbit : Herbiwore
    {
        public override void Eat(Plant plant)
        {
            Console.WriteLine($"{Name} ест {plant.Name}");
        }
    }
    class Fish : Herbiwore
    {
        public override void Eat(Plant plant)
        {
            Console.WriteLine($"{Name} ест {plant.Name}");
        }
    }
    abstract class Predator
    {
        public string Name { get; set; }
        public abstract void Eat(Herbiwore herbiwore);
    }
    class Wolf : Predator
    {
        public override void Eat(Herbiwore herbiwore)
        {
            Console.WriteLine($"{Name} ест {herbiwore.Name}");
        }
    }
    class Shark : Predator
    {
        public override void Eat(Herbiwore herbiwore)
        {
            Console.WriteLine($"{Name} ест {herbiwore.Name}");
        }
    }
    abstract class WorldFactory
    {
        public abstract Plant CreatePlant();
        public abstract Herbiwore CreateHerbiwore();
        public abstract Predator CreatePredator();
    }
    class WoodWorldFactory : WorldFactory
    {
        public override Plant CreatePlant()
        {
            return new Grass() { Name = "Трава" };
        }

        public override Herbiwore CreateHerbiwore()
        {
            return new Rabbit() { Name = "Кролик" };
        }

        public override Predator CreatePredator()
        {
            return new Wolf() { Name = "Волк" };
        }
    }
    class SeaWorldFactory : WorldFactory
    {
        public override Plant CreatePlant()
        {
            return new SeaWeed() { Name = "Водоросли" };
        }

        public override Herbiwore CreateHerbiwore()
        {
            return new Fish() { Name = "Рыба" };
        }

        public override Predator CreatePredator()
        {
            return new Shark() { Name = "Акула" };
        }
    }
}