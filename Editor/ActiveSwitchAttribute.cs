using UnityEngine;
using UnityEditor;

public class ActiveSwitchAttribute : PropertyAttribute
{
    public readonly bool IsActive;
    public ActiveSwitchAttribute(bool isActive)
    {
        this.IsActive = isActive;
    }
}

[CustomPropertyDrawer(typeof(ActiveSwitchAttribute))]
internal sealed class ActiveSwitchDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {     
        var attr = base.attribute as ActiveSwitchAttribute;
        EditorGUI.BeginDisabledGroup(!attr.IsActive);
        EditorGUI.PropertyField(position, property, label);
        EditorGUI.EndDisabledGroup();
    }
}
