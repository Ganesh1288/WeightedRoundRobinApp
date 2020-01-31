using System;

namespace WeightedRoundRobinApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int Noofserver = 0;
                int Count = 1;
                WeightedRoundRobin weightedRoundRobin = new WeightedRoundRobin();
                do
                {
                    Console.WriteLine("Enter No Of Sever #:");
                    int.TryParse(Console.ReadLine(), out Noofserver);

                    // If there is no valid value provided or provided string. 
                    // Same logic we can apply below variables also
                    if (Noofserver == 0)
                    {
                        Console.WriteLine("Please enter valid value");
                        continue;
                    }

                    Server server = null;
                    while (Count <= Noofserver)
                    {
                        server = new Server
                        {
                            Name = "Server " + Count.ToString()
                        };

                        Console.WriteLine(string.Concat(server.Name, " Weight # "));
                        server.Weight = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(string.Concat(server.Name, " CPU Threshold # "));
                        server.CPUThreshold = Convert.ToInt32(Console.ReadLine());
                        server.CPUUsage = server.CPUThreshold;

                        weightedRoundRobin.LstServers.Add(server);

                        Count++;
                    }
                    weightedRoundRobin.SetProp();
                    Console.WriteLine("================================");
                    Console.WriteLine("Option 1 to Update CPU Usage");
                    Console.WriteLine("Option 2 to get server");
                    Console.WriteLine("Option 3 to Exist");
                    Console.WriteLine("================================");
                    int option = 0;
                    do
                    {
                        Server updateServer = null;
                        Console.WriteLine("Enter Option");
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option == 2)
                        {
                            Console.WriteLine(string.Concat("New connection from ", weightedRoundRobin.GetServer().Name));
                        }
                        else if (option == 1)
                        {
                            Console.WriteLine("Enter Sever #");
                            int serverInput = Convert.ToInt32(Console.ReadLine());
                            Server exsitingServer = weightedRoundRobin.GetLastAccessServer(serverInput - 1);
                            if (exsitingServer != null)
                            {
                                updateServer = exsitingServer;
                                Console.WriteLine(string.Concat(exsitingServer.Name, " CPU Usage # "));
                                updateServer.CPUUsage = Convert.ToInt32(Console.ReadLine());
                                weightedRoundRobin.UpdateSever(serverInput - 1, updateServer);
                            }
                            else
                            {
                                Console.WriteLine("Enter valid server");
                            }
                        }
                        updateServer = null;
                    } while (option != 3);
                    Console.ReadLine();

                }
                while (Noofserver == 0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //
    }
}
