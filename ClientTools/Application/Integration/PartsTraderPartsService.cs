using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Application.Interfaces;
using Persistence.Configuration;

namespace Application.Integration

{
    public class PartsTraderPartsService : IPartsTraderPartsService
    {
        private readonly PartsTraderDBContext _context;
        public PartsTraderPartsService(PartsTraderDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Bring the compatibleParts using the partNumber
        /// </summary>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public IEnumerable<PartSummary> FindAllCompatibleParts(string partNumber)
        {
            yield return _context.PartSummaries.SingleOrDefault(parts => parts.PartNumber == partNumber);
        }
    }
}
