using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceble;
    [SerializeField] Tower balistaTower;
    //this is the property
    public bool IsPlaceble { get { return isPlaceble; } }

    void  OnMouseDown(){
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)){
            if (isPlaceble){

                bool isPlaced = balistaTower.CreateTower(balistaTower, transform.position);

                isPlaceble = !isPlaced;
                
            } else {
                Debug.Log("road");
            }
        }  
    }
}
