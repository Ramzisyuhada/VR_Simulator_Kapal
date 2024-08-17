using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private float Health;
    private float Damage;
    
    public Player(float Health,float Damage)
    {
        this.Health = Health;
        this.Damage = Damage;   
    }

    public float GetHealth()
    {
        return this.Health;
    }

    public void SetHealth(float Health)
    {
        this.Health = Health;
    }


    public float GetDamage()
    {
        return this.Damage;

    }

    public void SetDamage(float Damage)
    {
        this.Damage = Damage;
    }
}
