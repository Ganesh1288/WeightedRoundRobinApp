using System.Collections.Generic;
using System.Linq;

namespace WeightedRoundRobinApp
{
    public class WeightedRoundRobin
    {
        public List<Server> LstServers { get; set; }
        private int i = -1;//last choosen server
        private int gcd = 0;
        private int cw = 0;
        private int max = 0;
        private int n = 0; //server count

        public WeightedRoundRobin()
        {
            LstServers = new List<Server>();
        }

        public void SetProp()
        {
            gcd = GetGcd(LstServers.OrderBy(a => a.Weight).ToList());
            max = GetMaxWeight(LstServers.OrderBy(a => a.Weight).ToList());
            n = LstServers.Count;
        }

        public Server GetLastAccessServer(int item)
        {
            Server server = LstServers[item];
            return server;
        }

        public void UpdateSever(int item, Server server)
        {
            Server removedServer = new Server();
            removedServer = LstServers[item];
            if (removedServer != null)
                LstServers.Remove(removedServer);
            if (server != null)
                LstServers.Add(server);
            SetProp();
        }

        /**
         * an implmentation of  Weight Round Robin
         */
        public Server GetServer()
        {
            while (true)
            {
                i = (i + 1) % n;
                if (i == 0)
                {
                    cw = cw - gcd;
                    if (cw <= 0)
                    {
                        cw = max;
                        if (cw == 0)
                            return null;
                    }
                }
                if (LstServers[i].Weight >= cw && LstServers[i].CPUUsage <= LstServers[i].CPUThreshold)
                {
                    return LstServers[i];
                }
            }
        }


        /// <summary>
        /// Get Greatest Common Divisor
        /// </summary>
        /// <param name="servers"></param>
        /// <returns></returns>
        private int GetGcd(List<Server> servers)
        {
            return 1;
        }
        /// <summary>
        /// Get max weight
        /// </summary>
        /// <param name="servers"></param>
        /// <returns></returns>
        private int GetMaxWeight(List<Server> servers)
        {
            int max = 0;
            foreach (var s in servers)
            {
                if (s.Weight > max)
                    max = s.Weight;
            }
            return max;
        }
    }
}
