using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[ExecuteAlways]

[RequireComponent(typeof(TextMeshPro))]
public class CoordinatsLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    
    TextMeshPro label;
    Vector2Int coordinats = new Vector2Int();
    WayPoint wayPoint;
    
    private void Awake()
    {
        
        wayPoint = GetComponentInParent<WayPoint>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinats();
        label.enabled = false;
    }

    void Update()
    {
        if(!Application.isPlaying){
            DisplayCoordinats();
            UpdateObjectName();
        }

        SetLabelTextColor();
        ToggleLabels();
    }

    public void ToggleLabels(){
        if(Input.GetKeyDown(KeyCode.C)){
        label.enabled = !label.IsActive();
        }
    }
     
    void SetLabelTextColor(){
        if(!wayPoint.IsPlaceble){
            label.color = blockedColor;
        } else {
            label.color = defaultColor;
        }
    }

    private void DisplayCoordinats()
    {
        //создаю переменную для сокращения до целого натураль ного числа

        //присваиваем координате х координату роsition родительского объекта и  убираем десятіе части
        
        coordinats.x = Mathf.RoundToInt(transform.parent.position.x / 10);

        coordinats.y = Mathf.RoundToInt(transform.parent.position.z / 10);
        

        label.text = coordinats.x + ":" + coordinats.y;
    }

    void UpdateObjectName(){
        transform.parent.name = coordinats.ToString();
    }
}
