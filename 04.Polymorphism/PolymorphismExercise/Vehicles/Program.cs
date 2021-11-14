using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            IVehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (inputInfo[0] == "Drive")
                    {
                        if (inputInfo[1] == "Car")
                        {
                            if (car.CanDrive(double.Parse(inputInfo[2])))
                            {
                                car.Drive(double.Parse(inputInfo[2]));
                                Console.WriteLine($"Car travelled {double.Parse(inputInfo[2])} km");
                            }
                            else
                            {
                                Console.WriteLine("Car needs refueling");
                            }
                        }
                        else if (inputInfo[1] == "Truck")
                        {
                            if (truck.CanDrive(double.Parse(inputInfo[2])))
                            {
                                truck.Drive(double.Parse(inputInfo[2]));
                                Console.WriteLine($"Truck travelled {double.Parse(inputInfo[2])} km");
                            }
                            else
                            {
                                Console.WriteLine("Truck needs refueling");
                            }
                        }
                        else if (inputInfo[1] == "Bus")
                        {
                            bus.IsEmpty = false;
                            if (bus.CanDrive(double.Parse(inputInfo[2])))
                            {
                                bus.Drive(double.Parse(inputInfo[2]));
                                Console.WriteLine($"Bus travelled {double.Parse(inputInfo[2])} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }
                    }
                    else if (inputInfo[0] == "Refuel")
                    {
                        if (inputInfo[1] == "Car")
                        {
                            car.Refuel(double.Parse(inputInfo[2]));
                        }
                        else if (inputInfo[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(inputInfo[2]));
                        }
                        else if (inputInfo[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(inputInfo[2]));
                        }
                    }else if (inputInfo[0] == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        if (bus.CanDrive(double.Parse(inputInfo[2])))
                        {
                            bus.Drive(double.Parse(inputInfo[2]));
                            Console.WriteLine($"Bus travelled {double.Parse(inputInfo[2])} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
