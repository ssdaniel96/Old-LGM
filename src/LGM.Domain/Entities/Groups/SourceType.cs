﻿using LGM.Domain.Entities.Base;

namespace LGM.Domain.Entities.Groups;

public sealed class SourceType : Entity
{

    private SourceType() { }
    public SourceType(string description)
    {
        Description = description;
    }

    public string Description { get; private set; }
}

