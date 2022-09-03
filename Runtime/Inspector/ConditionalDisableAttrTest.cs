using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDisableAttrTest : MonoBehaviour
{
    [System.Serializable]
    public class TestStruct
    {
        public Vector3 p;
        public Quaternion q;
    }

    [Header("Flag control")]
    public bool flag = false;

    [FlagConditionalDisableInInspector("flag")]
    public string editableStrIfTrue = "a";

    [FlagConditionalDisableInInspector("flag", trueThenDisable: true)]
    public Rect editableRectIfFalse;

    [FlagConditionalDisableInInspector("flag", conditionalInvisible: true)]
    public float visibleFloatIfTrue = 0f;

    [FlagConditionalDisableInInspector("flag", trueThenDisable: true, conditionalInvisible: true)]
    public TestStruct visibleStructIfFalse;

    // ---------
    [Header("Flag control2")]
    public bool flag2 = false;

    [ConditionalDisableInInspector("flag2")]
    public string editableStrIfTrue2 = "a";

    [ConditionalDisableInInspector("flag2", trueThenDisable: true)]
    public Rect editableRectIfFalse2;

    [ConditionalDisableInInspector("flag2", conditionalInvisible: true)]
    public float visibleFloatIfTrue2 = 0f;

    [ConditionalDisableInInspector("flag2", trueThenDisable: true, conditionalInvisible: true)]
    public TestStruct visibleStructIfFalse2;


    // ---------
    [Header("String control")]
    public string flagStr = "A";

    [ConditionalDisableInInspector("flagStr", "A")]
    public AnimationCurve editableAminCurveIfA;

    [ConditionalDisableInInspector("flagStr", "A", notEqualThenEnable: true)]
    public Vector2 editableVec2UnlessA;

    [ConditionalDisableInInspector("flagStr", "A", conditionalInvisible: true)]
    public Quaternion visibleQuatIfA;

    [ConditionalDisableInInspector("flagStr", "A", notEqualThenEnable: true, conditionalInvisible: true)]
    public int visibleIntUnlessA;

    // ---------
    [Header("Int control")]
    public int flagInt = 1;

    [ConditionalDisableInInspector("flagInt", 1)]
    public string editableStrIf1;

    [ConditionalDisableInInspector("flagInt", 1, notEqualThenEnable: true)]
    public Gradient editableGradUnless1;

    [ConditionalDisableInInspector("flagInt", 1, conditionalInvisible: true)]
    public Color visibleColorIf1;

    [ConditionalDisableInInspector("flagInt", 1, notEqualThenEnable: true, conditionalInvisible: true)]
    public Bounds visibleBoundsUnless1;

    // ---------
    public enum FlagEnum { A, B, C }
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

    [ConditionalDisableInInspector("flagFloat", 0f, greaterThanComparedThenEnable: false)]
    public FlagEnum editableEnumIfUnder0Or0;

    [ConditionalDisableInInspector("flagFloat", 0f, conditionalInvisible: true)]
    public List<float> invisibleListIfOver0;

    [ConditionalDisableInInspector("flagFloat", 0f, greaterThanComparedThenEnable: false, conditionalInvisible: true)]
    public Vector3 invisibleVec3IfUnder0Or0;

}
