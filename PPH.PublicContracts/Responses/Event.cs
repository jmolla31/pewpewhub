using System;

namespace PPH.PublicContracts.Entities
{
    public class Event : LocationEntityBase
    {
        public Event(DateTime createdAt, string? createdBy, DateTime? updatedAt, string? updatedBy) 
            : base(createdAt, createdBy, updatedAt, updatedBy)
        {
        }
    }
}
