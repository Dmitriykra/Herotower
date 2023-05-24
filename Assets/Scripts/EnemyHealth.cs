using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//атрибу [RequireComponent] определяет, что требуемый компонент
//прикреплен к ГО, тогда  при создании новго ГО,
//у которого будет EnemyHealth скрипт,  автоматически
//подтянится скрипт Enemy, который  явно указан в атрибуте
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    //Добалвяю подсказку при наведении на объект в  инспекторе
    [Tooltip("Добавляю хитпоинты здоровья новому врагу")]
    [SerializeField] int difficulty = 1;

    int currentHitPoints = 0;
    Enemy enemy;
   
    private void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        currentHitPoints--;
        if(currentHitPoints<=0){

            //"уничтожаем" врага, скрываяего в пул обджект
            gameObject.SetActive(false); 

            //даем золото за врага
            enemy.RewardGold();

            //вобавляем хитпоинты жизней новым врагам
            maxHitPoints += difficulty;
        }
    }
}
