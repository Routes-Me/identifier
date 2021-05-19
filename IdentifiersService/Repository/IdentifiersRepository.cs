using IdentifiersService.Abstraction;
using IdentifiersService.Models;
using IdentifiersService.Models.DBModels;
using System;
using System.Linq;

namespace IdentifiersService.Repository
{
    public class IdentifiersRepository : IIdentifiersRepository
    {
        private readonly IdentifiersServiceContext _context;
        public IdentifiersRepository(IdentifiersServiceContext context)
        {
            _context = context;
        }

        public dynamic GenerateIdentifiers()
        {
            GeneratedIdentifierResponse generatedIdentifier = new GeneratedIdentifierResponse()
            {
                Identifier = DateTimeOffset.Now.ToUnixTimeMilliseconds()+1
            };
            return generatedIdentifier;
        }

        public string GenerateResourceNames(string key)
        {
            string resourceName = "";

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                Counters counter = _context.Counters.Where(c => c.Key == key).FirstOrDefault();
                if (counter == null)
                    counter = new Counters { Key = key, Value = 1 };
                else
                    counter.Value++;

                resourceName = "A00" + counter.Value.ToString();
                _context.Counters.Update(counter);
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            return resourceName;
        }
    }
}
