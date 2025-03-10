using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int monsters = 0;

    //player HP

    private int hp;

    //ammo (eventually)
    public int maxHP;
    public int maxMagic;

    private int Magic;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        SetHP(maxHP);
        SetAmmo(maxMagic);
    }

    void Update()
    {
        //Debug.Log(GetMonsters());
    }

    public int GetHealth()
    {
        return hp;
    }

    public void SetHP(int a)
    {
        hp = a;
    }

    public void ManageHP(int a)
    {
        hp += a;
    }

    public void SetAmmo(int a)
    {
        Magic = a;
    }

    public int GetMonsters()
    {
        return monsters;
    }

    public void AddMonsters(int a)
    {
        monsters += a;
    }

    public void SubMonsters()
    {
        monsters--;
    }

    public void ManageAmmo(int a)
    {
        Magic += a;
    }

    public int getAmmo()
    {
        return Magic;
    }
}

