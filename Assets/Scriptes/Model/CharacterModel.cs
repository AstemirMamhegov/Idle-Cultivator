using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterModel : MonoBehaviour
{
    public static CharacterModel instance;
    // Градация возвышения
    public int LevelID { get; set; }
    public string CiltivationRange { get; set; }

    // Жизни и энергия
    public int HealthPoint { get; set; }
    public int DaoEnergy { get; set; }
    public int DaoMaxEnregy { get; set; }

    //Физические статистики
    public int Strength { get; set; }
    public int Vitality { get; set; }
    public int Aguilty { get; set; }
    public int Stamina { get; set; }
    public int Wisdom { get; set; }
    public int Intellect { get; set; }

    //Рассчетные статистики
    public double Damage { get; set; }
    public double CriticalChance { get; set; }
    public double CriticalDamage { get; set; }
    public double Defense { get; set; }

}
