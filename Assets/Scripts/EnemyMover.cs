using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//атрибу [RequireComponent] определяет, что требуемый компонент
//прикреплен к ГО, тогда  при создании новго ГО,
//у которого будет EnemyMover скрипт,  автоматически
//подтянится скрипт Enemy, который  явно указан в атрибуте
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] public List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    Enemy enemy;
    
    private void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    
    private void OnEnable()
    {
        FindPath();
        ReturnEnemyToStart();
        StartCoroutine(PrintWayPointName());
    }

    void FindPath(){
        //чистим массив плиток
        path.Clear();

        //получаем родительский ГО, в котором сохранены 
        //плитки пути по тэгу Path
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        //для каждого наследника в иерахии родителя определяем трансформ
        foreach(Transform child in parent.transform){
            
            //создаем экземпляр класса WayPoint в переменную waypoint
            WayPoint  waypoint = child.GetComponent<WayPoint>();

            if(waypoint !=null){
                //и теперь эту переменную помещаем в список пути path
                path.Add(waypoint);
            }
        }
    }

    void ReturnEnemyToStart(){
        //берем transform.position врага и присваеваем изначальной позиции первого єл-та (плитки) в массиве path
        transform.position = path[0].transform.position;
    }
    void Finishpath(){
        gameObject.SetActive(false);
        enemy.PenaltyGold();
    }

    IEnumerator PrintWayPointName()
    {   
        //для каждого єлемента типа скрипт WayPoint, которій мі назвали wayPoint, в массиве с именем path применить действие
        foreach(WayPoint wayPoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = wayPoint.transform.position;
            float travelPercent = 0f;

            //разворачивать врага лицом к конечной точке
            transform.LookAt(endPos);

            while(travelPercent < 1f){
                travelPercent += Time.deltaTime * speed;
                //делаем плавное перемещение
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);

                //ждем окончания перемещения в конце кадра
                yield return new WaitForEndOfFrame();
            }
        }
        Finishpath();
    }
}
