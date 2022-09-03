using System;
using UnityEngine;

public class FlagConditionalDisableInInspectorAttribute : PropertyAttribute
{
    public readonly string FlagVariableName;
    public readonly bool FalseThenDisable;
    public readonly bool ConditionalInvisible;

    public FlagConditionalDisableInInspectorAttribute(string flagVariableName,
                                                      bool falseThenDisable = true,
                                                      bool conditionalInvisible = false)
    {
        this.FlagVariableName = flagVariableName;
        this.FalseThenDisable = falseThenDisable;
        this.ConditionalInvisible = conditionalInvisible;
    }
}

public partial class ConditionalDisableInInspectorAttribute: PropertyAttribute
{
    public readonly string VariableName;
    public readonly Type VariableType;
    public readonly bool FalseThenDisable;
    public readonly bool ConditionalInvisible;

    public readonly string ComparedStr;
    public readonly int ComparedInt;
    public readonly float ComparedFloat;

    private ConditionalDisableInInspectorAttribute(string variableName, Type variableType,
                                                   bool falseThenDisable = true,
                                                   bool conditionalInvisible = false)
    {
        this.VariableName = variableName;
        this.VariableType = variableType;
        this.FalseThenDisable = falseThenDisable;
        this.ConditionalInvisible = conditionalInvisible;
    }

    public ConditionalDisableInInspectorAttribute(string boolVariableName,
                                                  bool falseThenDisable = true,
                                                  bool conditionalInvisible = false)
    : this(boolVariableName, typeof(bool), falseThenDisable, conditionalInvisible)
    {
    }

    public ConditionalDisableInInspectorAttribute(string strVariableName, string comparedStr,
                                                  bool equalThenActive = true,
                                                  bool conditionalInvisible = false)
    : this(strVariableName, comparedStr.GetType(), equalThenActive, conditionalInvisible)
    {
        this.ComparedStr = comparedStr;
    }

    public ConditionalDisableInInspectorAttribute(string intVariableName, int comparedInt,
                                                  bool equalThenActive = true,
                                                  bool conditionalInvisible = false)
    : this(intVariableName, comparedInt.GetType(), equalThenActive, conditionalInvisible)
    {
        this.ComparedInt = comparedInt;
    }

    public ConditionalDisableInInspectorAttribute(string floatVariableName, float comparedFloat,
                                                  bool greaterThanComparedThenActive = true,
                                                  bool conditionalInvisible = false)
    : this(floatVariableName, comparedFloat.GetType(), !greaterThanComparedThenActive, conditionalInvisible)
    {
        this.ComparedFloat = comparedFloat;
    }
}