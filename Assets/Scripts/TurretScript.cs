using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TurretScript : MonoBehaviour
{
    public Transform turret;
    public GameObject bullet;

    public GameObject[] enemies;

    //cooldown
    public float cooldown = 3f;
    public float last;
    public float range = 30f;
    
    public float elapsedTime;
    public float duration = 1f;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            //Look at Enemy
            var dotproduct = Vector3.Dot(turret.transform.up, enemy.transform.position.normalized);
            var crossproduct = Vector3.Cross(turret.transform.up,enemy.transform.position.normalized);
            var angle = Mathf.Atan2(dotproduct, dotproduct) * Mathf.Rad2Deg;

            int clockwise = 1;

            if (crossproduct.z < 0)
            {
                clockwise = -1;
            }
        
            turret.rotation = Quaternion.Lerp(turret.rotation, Quaternion.Euler(0, 0,angle * clockwise), Time.deltaTime * 3f);
            
            //If in Range Shoot enemy
            if ( dotproduct > 0.9f && enemy.transform.position.magnitude < range)
            {
                Debug.DrawLine(turret.position,enemy.transform.position,Color.red);
                Shoot();
            }
        }
    }
    
private void Shoot()
    {
        //cooldown
        if (Time.time - last < cooldown)
        {
            return;
        }
        last = Time.time;

        elapsedTime = Time.deltaTime;
            
        GameObject bulletObject = Instantiate(bullet,turret.position, turret.rotation);
    }
}
