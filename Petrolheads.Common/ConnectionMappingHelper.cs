namespace Petrolheads.Common
{
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectionMappingHelper
    {
        private readonly Dictionary<string, HashSet<string>> connections =
            new Dictionary<string, HashSet<string>>();

        public int Count
        {
            get
            {
                return this.connections.Count;
            }
        }

        public void Add(string key, string connectionId)
        {
            lock (this.connections)
            {
                HashSet<string> connections;
                if (!this.connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    this.connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public List<string> GetConnections()
        {
            if (this.connections.Count > 0)
            {
                return this.connections.Keys.ToList();
            }

            return null;
        }

        public void Remove(string key, string connectionId)
        {
            lock (this.connections)
            {
                HashSet<string> connections;
                if (!this.connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        this.connections.Remove(key);
                    }
                }
            }
        }
    }
}
