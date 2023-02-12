using Assets.Scriptes.Save;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DaoManager : MonoBehaviour
{
    // ������ ���������� ������ ��������� ���
    public int currentExpCounter = 1;
    public Action<int> onMouseDown;

    public void OnMouseDown()
    {
        onMouseDown?.Invoke(currentExpCounter);
    }
}
