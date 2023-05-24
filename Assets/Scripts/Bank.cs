using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldBalance;
    [SerializeField] int startingBalanc = 100;
    [SerializeField] int currentBalance;

    //create property to get int currentBalance from enother scripts;
    public int GetCurrentBalance{ get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalanc;
        goldBalance.text = "Gold: " + currentBalance.ToString();
    }
    public void Deposit(int amount){

        //вернуть всегда позитивное значение числа (модуль) c Mathf.Abs
        currentBalance += Mathf.Abs(amount);
        goldBalance.text = "Gold: " + currentBalance.ToString();
    }

    public void Withdrow(int amount){

        //вернуть всегда позитивное значение числа (модуль) c Mathf.Abs
        currentBalance -= Mathf.Abs(amount);
        goldBalance.text = "Gold: " + currentBalance.ToString();

        if(currentBalance < 0){
            //lose game
            ReloadScene();
        }
    }

    void ReloadScene(){
        //получаем текущую сцену
        Scene curretScene = SceneManager.GetActiveScene();
        //перезагружаемэту текущую сцену по индексу
        SceneManager.LoadScene(curretScene.buildIndex);
    }
}
