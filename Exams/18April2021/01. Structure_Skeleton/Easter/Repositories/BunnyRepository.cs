using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnyes;

        public BunnyRepository()
        {
            bunnyes = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models { get { return this.bunnyes; } }

        public void Add(IBunny model)
        {
            this.bunnyes.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return this.bunnyes.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IBunny model)
        {
            return this.bunnyes.Remove(model);
        }
    }
}
