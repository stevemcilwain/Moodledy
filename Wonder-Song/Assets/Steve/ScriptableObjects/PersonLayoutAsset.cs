using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonLayoutAsset", menuName = "People/PersonLayoutAsset")]
public class PersonLayoutAsset : ScriptableObject 
{
    [Space(10)]
    [Header("Position Settings")]
    [Space(10)]

    public float HairY;
    public float PantsY;
    public float ShirtY;
    public float FaceY;
    public float BangsY;
}
