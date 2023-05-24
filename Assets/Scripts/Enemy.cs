using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 20;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold(){
        if(bank == null){ return; }
        bank.Deposit(goldReward);
    }

    public void PenaltyGold(){
        Debug.Log("Penalty" + goldPenalty);
        if(bank == null){ return; }
        bank.Withdrow(goldPenalty);
    }
}
