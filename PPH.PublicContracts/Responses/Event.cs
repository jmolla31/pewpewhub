using System;

namespace PPH.PublicContracts.Entities
{
    public class Event : LocatableEntityBase
    {
        /// <summary>
        ///     Optional. Identifies the unit that caused or was involved in this event.
        /// </summary>
        public int? UnitId { get; set; }

        public Event(DateTime createdAt, string? createdBy, DateTime? updatedAt, string? updatedBy) 
            : base(createdAt, createdBy, updatedAt, updatedBy)
        {
        }
    }
}
