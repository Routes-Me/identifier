using IdentifiersService.Abstraction;
using IdentifiersService.Models;
using System;

namespace IdentifiersService.Repository
{
    public class IdentifiersRepository : IIdentifiersRepository
    {
        public IdentifiersRepository()
        {
        }

        public dynamic GenerateIdentifiers()
        {
            GeneratedIdentifierResponse generatedIdentifier = new GeneratedIdentifierResponse()
            {
                Identifier = DateTimeOffset.Now.ToUnixTimeMilliseconds()+1
            };
            return generatedIdentifier;
        }
    }
}
