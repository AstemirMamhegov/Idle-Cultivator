using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDao : MonoBehaviour
{
    //����� ����������� ��������� ������� ��������� ���������� ��� ��� ���������
    public Component[] passiveComponents;

    public int currentPassiveDao;
    public float timeTick = 1;
    private float t;

    public List<IPassiveELement> passiveELements = new List<IPassiveELement>();
    public Action<int> onDaoUpdate;

    void Start()
    {
        //
        foreach (var component in passiveComponents)
        {
            if(component is IPassiveELement)
            {
                passiveELements.Add(component as IPassiveELement);
            }
        }
    }

    void Update()
    {
        //
        if (t < 0)
        {
            UpdateDao();
            onDaoUpdate?.Invoke(currentPassiveDao);
            t = timeTick;
        }
        t -= Time.deltaTime;
    }

    /// <summary>
    /// ������� ��������� ���������� �������������� ���������� ��� - ���������.
    /// </summary>
    /// <param name="el"></param>
    public void AddPassiveElement(IPassiveELement el)
    {
        passiveELements.Add(el);
    }

    /// <summary>
    /// ������� ��������� ������� ��� ��� ���������� ���������� ����������
    /// </summary>
    private void UpdateDao()
    {
        currentPassiveDao = 0;

        foreach (var passive in passiveELements)
        {
            currentPassiveDao += passive.GetDao();
        }
    }
}

// ��������� ����������� �������������� ��� ��� ���� ��� �������� �� �����������
public interface IPassiveDao
{
    public int Dao { get; }
}

// 
public interface IPassiveELement
{
    public int GetDao();
}
