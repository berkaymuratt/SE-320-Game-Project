using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Gun gun;
    public int health;

    // Update is called once per frame
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
        }
    }

    public void getDamage(int value)
    {
        health -= value;
    }
}
