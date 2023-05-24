using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocation : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectletileParticles;

    Transform target;
    float range  = 15f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    private void FindClosestEnemy()
    {
        //создаем массив всех врагов на сцене
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        //Находим ближайшего с помощью трансоформ
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies){
            //замеряем дистанцию между балистой и позицей каждого врага на сцене
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            //если замерянная дистанция меньше максимальной
            if(targetDistance < maxDistance){

                //новой переменной ближайшей цели присваевам позицию даннного врга
                closestTarget = enemy.transform;

                //и обновляем ближайшую дистанцию до только что замерянной
                maxDistance = targetDistance;
            }
        }

        //устанавливаем цель на ближайшего врага
        target = closestTarget;

    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.transform.LookAt(target);
        if(targetDistance < range) {
            Attack(true);
        }else {
            Attack(false);
        }
       
    }

    void Attack(bool isActive){
        var emissionModule = projectletileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
