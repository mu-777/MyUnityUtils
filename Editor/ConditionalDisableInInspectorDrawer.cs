using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using GetCondFunc = System.Func<UnityEditor.SerializedProperty, ConditionalDisableInInspectorAttribute, bool>;

[CustomPropertyDrawer(typeof(FlagConditionalDisableInInspectorAttribute))]
internal sealed class FlagConditionalDisableDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attr = base.attribute as FlagConditionalDisableInInspectorAttribute;
        var prop = property.serializedObject.FindProperty(attr.FlagVariableName);
        if(prop == null)
        {
            Debug.LogError($"Not found '{attr.FlagVariableName}' property");
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
        }
        EditorGUI.BeginDisabledGroup(attr.FalseThenDisable ? !prop.boolValue : prop.boolValue);
        EditorGUI.PropertyField(position, property, label);
        EditorGUI.EndDisabledGroup();
    }
}

[CustomPropertyDrawer(typeof(ConditionalDisableInInspectorAttribute))]
internal sealed class ConditionalDisableDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attr = base.attribute as ConditionalDisableInInspectorAttribute;
        var condProp = property.serializedObject.FindProperty(attr.VariableName);
        if(condProp == null)
        {
            Debug.LogError($"Not found '{attr.VariableName}' property");
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
        }

        GetCondFunc disableCondFunc;
        if(!DisableCondFuncMap.TryGetValue(attr.VariableType, out disableCondFunc))
        {
            Debug.LogError($"{attr.VariableType} type is not supported");            
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
        }
        EditorGUI.BeginDisabledGroup(disableCondFunc(condProp, attr));
        EditorGUI.PropertyField(position, property, label);
        EditorGUI.EndDisabledGroup();
    }

    private Dictionary<Type, GetCondFunc> DisableCondFuncMap = new Dictionary<Type, GetCondFunc>()
    {
        {
            typeof(bool), (prop, attr) =>
            {
                return attr.FalseThenDisable ? !prop.boolValue : prop.boolValue;
            }
        },
        {
            typeof(string), (prop, attr) => {
                return attr.FalseThenDisable
                ? prop.stringValue != attr.ComparedStr
                : prop.stringValue == attr.ComparedStr;
            }
        },
        {
            typeof(int), (prop, attr) => {
                return attr.FalseThenDisable
                ? prop.intValue != attr.ComparedInt
                : prop.intValue == attr.ComparedInt;
            }
        },
        {
            typeof(float), (prop, attr) => {
                return attr.FalseThenDisable
                ? prop.floatValue > attr.ComparedFloat
                : prop.floatValue <= attr.ComparedFloat;
            }
        }
    };
}




