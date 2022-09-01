using System;
using UnityEngine;

public class FlagBaseDisableAttribute : PropertyAttribute
{
    public readonly string FlagVariableName;
    public readonly bool FalseThenDisable;
    public FlagBaseDisableAttribute(string flagVariableName, bool falseThenDisable = true)
    {
        this.FlagVariableName = flagVariableName;
        this.FalseThenDisable = falseThenDisable;
    }
}

public partial class ConditionalDisableInInspectorAttribute: PropertyAttribute
{
    public readonly string VariableName;
    public readonly bool FalseThenDisable;
    public readonly Type VariableType;

    public readonly string ComparedStr;
    public readonly int ComparedInt;
    public readonly float ComparedFloat;

    private ConditionalDisableInInspectorAttribute(string variableName, Type variableType, bool falseThenDisable = true)
    {
        this.VariableName = variableName;
        this.VariableType = variableType;
        this.FalseThenDisable = falseThenDisable;
    }

    public ConditionalDisableInInspectorAttribute(string boolVariableName, bool falseThenDisable = true)
    : this(boolVariableName, typeof(bool), falseThenDisable)
    {
    }

    public ConditionalDisableInInspectorAttribute(string strVariableName, string comparedStr,
                                                  bool equalThenActive = true)
    : this(strVariableName, comparedStr.GetType(), equalThenActive)
    {
        this.ComparedStr = comparedStr;
    }

    public ConditionalDisableInInspectorAttribute(string intVariableName, int comparedInt,
                                                  bool equalThenActive = true)
    : this(intVariableName, comparedInt.GetType(), equalThenActive)
    {
        this.ComparedInt = comparedInt;
    }

    public ConditionalDisableInInspectorAttribute(string floatVariableName, float comparedFloat,
                                                  bool greaterThanComparedThenActive = true)
    : this(floatVariableName, comparedFloat.GetType(), !greaterThanComparedThenActive)
    {
        this.ComparedFloat = comparedFloat;
    }
}