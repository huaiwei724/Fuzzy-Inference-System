using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R11546004FuzzySetNamespace
{
    public enum DefuzzificationType
    {
        COA,
        BOA,
        MOM,
        SOM,
        LOM
    }
    public enum FireStrengthComputeType
    {
        Min,
        Max,
        AlgebraicSum,
        AlgebraicProduct,
    }
    public enum CompositionType
    {
        MaxMin,
        MaxProduct
    }
    public enum Weighted_Type
    {
        Average,
        WeigtedAverage,
        WeigtedSum
    }
}