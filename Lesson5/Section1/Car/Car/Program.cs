using System;
using System.Threading;
using System.Threading.Tasks;

namespace Car
{
    class Car
    {
        volatile int fuel;
        int speed = 0;
        readonly int maxSpeed = 100;

        volatile bool running = false;

        public Car(int initialFuel)
        {
            this.fuel = initialFuel;
        }
        public int Fuel => this.fuel;

        public int Speed
        {
            get { return this.speed; }

        }

        public void AddSpeed(int amount)
        {
            if (this.speed == 0)
                this.Run();

            var newSpeed = this.speed += amount;
            this.speed = Math.Min(maxSpeed, newSpeed);

        }
        public void AddFuel(int amount)
        {

            this.fuel += amount;
        }

        public void DecreaseSpeed(int amount)
        {
            var newSpeed = this.speed -= amount;
            this.speed = Math.Max(0, newSpeed);
            if(this.speed == 0)
            {
                this.running = false;
            }
        }
        public void Run()
        {
            if(!running)
            {
                running = true;
                Task.Run(RunLoop);
            }

        }
        private void RunLoop()
        {
            while(running && fuel > 0)
            {
                Console.WriteLine($"Running at speed {this.speed} and current fuel is {this.fuel}");
                Thread.Sleep(1000);
                this.fuel -= Math.Min(fuel, speed);

            }
            Console.WriteLine("Car is stopped");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(100);
            car.AddSpeed(20);
            Thread.Sleep(1000);
            car.AddFuel(10);

            Console.ReadLine();
        }
    }
}
