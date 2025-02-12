using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PPH.PublicContracts.Payloads;

public class CreateMap : CreateNamedObjectBase
{
    public CreateMap(string name, string? description) : base(name, description)
    {
    }
}


public class CreateNamedObjectBase
{
    [Required]
    [StringLength(100)]
    public string Name { get; }

    [StringLength(500)]
    public string? Description { get; }

    public CreateNamedObjectBase(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}