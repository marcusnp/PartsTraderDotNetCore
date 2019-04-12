using System.Collections.Generic;
using Domain.Entities;
using Application.Configuration;
using Application.Interfaces;
using Domain.ValueObjects;
using System.Linq;

namespace Application.PartCatalogue
{
    public class PartCatalogue : IPartCatalogue
    {
        private readonly IPartsTraderPartsService _service;
        public PartCatalogue(IPartsTraderPartsService service)
        {
            _service = service;
        }

        public IEnumerable<PartSummary> GetCompatibleParts(string partNumber)
        {
            var list = new List<PartSummary>();

            PartNumber part = PartNumber.For(partNumber);
            //No to send to PartsTrader => return a empty list
            if (CheckExclusionList(partNumber))
            {
                return list;
            }
            //Allow to go to PartsTrader
            return _service.FindAllCompatibleParts(partNumber);
        }

        /// <summary>
        /// Return false is the partNumber do not exist inside the Exclusions.json
        /// </summary>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        private bool CheckExclusionList(string partNumber)
        {
            bool result = false;
            List<PartSummary> TotalList = new List<PartSummary>();
            TotalList = LoadExclusionList.LoadJson();
            if (TotalList.Count >= 0)
            {
                var list = from exclusionList in TotalList
                           where exclusionList.PartNumber == partNumber
                           select exclusionList;
                if (list.Count() > 0)
                {
                    result = true;
                }

            }

            return result;

        }
    }
}