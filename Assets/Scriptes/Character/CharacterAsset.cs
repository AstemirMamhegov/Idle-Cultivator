using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterAsset", menuName = "Custom", order = 0)]
public class CharacterAsset : ScriptableObject
{
    [Header("Base Parameters")]
    public int id;
    public float maxDao;

    public float incDao;
    public float miltiplieIncDao;
}
