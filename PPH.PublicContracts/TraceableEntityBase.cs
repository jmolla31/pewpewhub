using System;

namespace PPH.PublicContracts
{
    /// <summary>
    ///     Base class for objects requiring create/update tracing (who and when).
    /// </summary>
    public abstract class TraceableEntityBase
    {
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
