using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDisableAttrTest : MonoBehaviour
{
    public bool flag = false;

    [FlagBaseDisable("flag")]
    public string flagControlledData = "a";

    [ConditionalDisableInInspector("flag")]
    public Vector3 flagControlledData2 = Vector3.one;


    public string flagStr = "aaa";

    [ConditionalDisableInInspector("flagStr", "aaa")]
    public Vector3 strControlledData = Vector3.one;

    [ConditionalDisableInInspector("flagStr", "aaa", false)]
    public List<string> strControlledData2;


    public int flagInt = 1;

    [ConditionalDisableInInspector("flagInt", 1)]
    public int intControlledData = 2;

    public enum FlagEnum { A=0, B=1, C=2}
    public FlagEnum flagEnum = FlagEnum.A;

    [ConditionalDisableInInspector("flagEnum", (int)FlagEnum.A)]
    public int enumControlledDataA = 2;

    [ConditionalDisableInInspector("flagEnum", (int)FlagEnum.B)]
    public int enumControlledDataB = 2;


    public float flagFloat = 1.0f;

    [ConditionalDisableInInspector("flagFloat", 0f)]
    public float floatControlledData0;
    [ConditionalDisableInInspector("flagFloat", 0f, false)]
    public float floatControlledData0LessThan;

    [ConditionalDisableInInspector("flagFloat", 10f)]
    public float floatControlledData10;

    [ConditionalDisableInInspector("flagFloat", 1f)]
    public float floatControlledData1;

}
