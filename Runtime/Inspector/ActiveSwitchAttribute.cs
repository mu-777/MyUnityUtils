using UnityEngine;
using UnityEditor;

public class ActiveSwitchAttribute : PropertyAttribute
{
    public readonly string FlagVariableName;
    public ActiveSwitchAttribute(string flagVariableName)
    {
        this.FlagVariableName = flagVariableName;
    }
}

[CustomPropertyDrawer(typeof(ActiveSwitchAttribute))]
internal sealed class ActiveSwitchDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {     
        var attr = base.attribute as ActiveSwitchAttribute;
        var flagProp = property.serializedObject.FindProperty(attr.FlagVariableName);
        Debug.Log($"{flagProp.boolValue}, {flagProp.propertyType}, {flagProp.type}");
        EditorGUI.BeginDisabledGroup(!flagProp.boolValue);
        EditorGUI.PropertyField(position, property, label);
        EditorGUI.EndDisabledGroup();
    }
}
