using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleState { Start,PlayerAction,PlayerMove, EnemyMove,Busy }

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud EnemyHud;
    [SerializeField] BattleDialog dialogBox;
    BattleState state;

    private void Start()
    {
        StartCoroutine(SetupBattle());
      
    }
    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        EnemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        EnemyHud.SetData(EnemyUnit.Pokemon);
        yield return  dialogBox.TypeDialog($" A wild {playerUnit.Pokemon.Base.Name} appeared.");
        yield return new WaitForSeconds(1f);
        PlayerAction();

      
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("choose an action"));
        dialogBox.EnableActionSelector(true);
    }
}
