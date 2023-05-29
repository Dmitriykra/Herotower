using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldBalance;
    [SerializeField] int startingBalanc = 150;
    [SerializeField] int currentBalance;
    [SerializeField] GameState gameState;

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
            gameState.LoseGame();
        } 
        
        if (currentBalance >= 500){
            gameState.WinGame();
        }
    }
}
