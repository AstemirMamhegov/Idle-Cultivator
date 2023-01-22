using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public int currentExpCounter = 1;

    public void OnMouseDown()
    {
        LevelUp.instance.AddXp(currentExpCounter);
    }
}
