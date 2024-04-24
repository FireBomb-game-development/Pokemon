using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
[SerializeField] BattleUnit playerUnit;
[SerializeField] BattleHud playerHud;
[SerializeField] BattleUnit EnemyUnit;
[SerializeField] BattleHud EnemyHud;

    private void Start()
    {
        SetupBattle();
    }
    public void SetupBattle()
    {
        playerUnit.Setup();
        EnemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        EnemyHud.SetData(EnemyUnit.Pokemon);
    }
}
