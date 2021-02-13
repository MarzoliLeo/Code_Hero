using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleState : ICharacterState
{
    public ICharacterState DoState(CharacterBase character)
    {
        Debug.Log("in idle stai fermo.!!!1h1h1h");
        if (character.canAttack)
            return character.attackState;
        else if (character.isDead)
            return character.deadState;
        else
            return character.idleState;
    }
}