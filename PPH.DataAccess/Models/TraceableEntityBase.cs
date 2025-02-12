using System.ComponentModel.DataAnnotations.Schema;

namespace PPH.DataAccess.Models;

/// <summary>
///     Base class for objects requiring create/update tracing (who and when).
/// </summary>
public abstract class TraceableEntityBase
{
    public DateTime CreatedAt { get; }

    public string CreatedBy { get; }

    public DateTime? UpdatedAt { get; }

    public string? UpdatedBy { get; }

    protected TraceableEntityBase(DateTime createdAt, string createdBy, DateTime? updatedAt, string? updatedBy)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
    }
}
