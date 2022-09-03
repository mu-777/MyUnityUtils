using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDisableAttrTest : MonoBehaviour
{
    [Header("Flag control")]
    public bool flag = false;

    [FlagConditionalDisableInInspector("flag")]
    public string editableStrIfTrue = "a";

    [FlagConditionalDisableInInspector("flag", falseThenDisable: false)]
    public Rect editableRectIfFalse;

    [FlagConditionalDisableInInspector("flag", conditionalInvisible: true)]
    public float invisibleFloatIfFalse = 0f;

    [FlagConditionalDisableInInspector("flag", falseThenDisable: false, conditionalInvisible: true)]
    public Vector3 invisibleVec3IfTrue;

    // ---------
    [Header("Flag control2")]
    public bool flag2 = false;

    [ConditionalDisableInInspector("flag2")]
    public string editableStrIfTrue2 = "a";

    [ConditionalDisableInInspector("flag2", falseThenDisable: false)]
    public Rect editableRectIfFalse2;

    [ConditionalDisableInInspector("flag2", conditionalInvisible: true)]
    public float invisibleFloatIfFalse2 = 0f;

    [FlagConditionalDisableInInspector("flag2", falseThenDisable: false, conditionalInvisible: true)]
    public Vector3 invisibleVec3IfTrue2;


    // ---------
    [Header("String control")]
    public string flagStr = "A";

    [ConditionalDisableInInspector("flagStr", "A")]
    public AnimationCurve editableAminCurveIfA;

    [ConditionalDisableInInspector("flagStr", "A", equalThenActive: false)]
    public Vector2 editableVec2UnlessA;

    [ConditionalDisableInInspector("flagStr", "A", conditionalInvisible: true)]
    public Quaternion invisibleQuatIfA;

    [ConditionalDisableInInspector("flagStr", "A", equalThenActive: false, conditionalInvisible: true)]
    public int invisibleIntUnlessA;

    // ---------
    [Header("Int control")]
    public int flagInt = 1;

    [ConditionalDisableInInspector("flagInt", 1)]
    public string editableStrIf1;

    [ConditionalDisableInInspector("flagInt", 1, equalThenActive: false)]
    public Gradient editableGradUnless1;

    [ConditionalDisableInInspector("flagInt", 1, conditionalInvisible: true)]
    public Color invisibleColorIf1;

    [ConditionalDisableInInspector("flagInt", 1, equalThenActive: false, conditionalInvisible: true)]
    public Bounds invisibleBoundsUnless1;

    // ---------
    public enum FlagEnum { A = 0, B = 1, C = 2 }
    [Header("Enum control")]
    public FlagEnum flagEnum = FlagEnum.A;

    [ConditionalDisableInInspector("flagEnum", (int)FlagEnum.A, conditionalInvisible: true)]
    public string visibleStrIfEnumA = "AAAAAAAAAAAAAAAAAAAAAAA";

    [ConditionalDisableInInspector("flagEnum", (int)FlagEnum.B, conditionalInvisible: true)]
    public string visibleStrIfEnumB = "BBBBBBBBBBBBBBBBBBBBBBB";

    [ConditionalDisableInInspector("flagEnum", (int)FlagEnum.C, conditionalInvisible: true)]
    public string visibleStrIfEnumC = "CCCCCCCCCCCCCCCCCCCCCCC";


    // ---------
    [Header("Float control"), Range(-10f, 10f)]
    public float flagFloat = 0f;

    [ConditionalDisableInInspector("flagFloat", 0f)]
    public GameObject editableGameObjIfOver0;

    [ConditionalDisableInInspector("flagFloat", 0f, greaterThanComparedThenActive: false)]
    public FlagEnum editableEnumIfUnder0Or0;

    [ConditionalDisableInInspector("flagFloat", 0f, conditionalInvisible: true)]
    public List<float> invisibleListIfOver0;

    [ConditionalDisableInInspector("flagFloat", 0f, greaterThanComparedThenActive: false, conditionalInvisible: true)]
    public bool invisibleBoolIfUnder0Or0;


}
