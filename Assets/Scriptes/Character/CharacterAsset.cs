using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterAsset", menuName = "Custom/CharacterAsset", order = 0)]
public class CharacterAsset : ScriptableObject
{
    [Header("Base Parameters")]
    public int id;
    public float maxDao = 100;

    public float miltiplieIncDao = 3;
    public int level = 1;
}


