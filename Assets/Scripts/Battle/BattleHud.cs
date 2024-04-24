using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI lvl;
    [SerializeField] HPBar HP;



    public void SetData(Pokemon pokemon)
    {
        name.text = pokemon.Base.Name;
        lvl.text = "Lvl " + pokemon.Level;
        HP.SetHP((float)pokemon.HP / pokemon.MaxHp);

    }
}
