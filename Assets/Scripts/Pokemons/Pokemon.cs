using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase _base;
    int level;
    public int HP { get; set; }
    public List<Move> Moves {get;set;}

    public Pokemon( PokemonBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
        HP = _base.MaxHp;


        //generate moves
        Moves = new List<Move>();
        foreach(var move in _base.LearnableMoves)
        {
            if (move.Level <= level)
                Moves.Add(new Move(move.Base));
            if (Moves.Count >= 4)
                break;
        }
    
    }

    public int Attack
    {
        //the  origianl formula for attack Damage in pokemon game 
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }

    public int Defence
    {

        get { return Mathf.FloorToInt((_base.Defence * level) / 100f) + 5; }
    }

    public int SpAttack
    {

        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }

    public int SpDefence
    {
    
        get { return Mathf.FloorToInt((_base.SpDefence * level) / 100f) + 5; }
    }

    public int Speed
    {
   
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }

    public int MaxHp
    {
  
        get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 10; }
    }


}
