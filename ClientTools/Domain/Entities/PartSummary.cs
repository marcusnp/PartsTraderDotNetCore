﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Provides summary details of a part.
    /// </summary>
    public class PartSummary
    {
        /// <summary>
        /// The part number.
        /// </summary>
        public PartNumber PartNumber { get; set; }

        /// <summary>
        /// The description of the part.
        /// </summary>
        public string Description { get; set; }
    }
}