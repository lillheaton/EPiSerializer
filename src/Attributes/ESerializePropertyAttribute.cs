﻿using System;

namespace ESerializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ESerializePropertyAttribute : Attribute
    {
    }
}
