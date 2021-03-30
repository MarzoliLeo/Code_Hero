using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : ICharacterState
{
    public ICharacterState DoState(CharacterBase character)
    {
        Debug.Log("sto attaccando!!!");
        //Todo impostare il booleano  canAttack nel gamemanager;
        //character.Shoot();
        if (character.canAttack)
        {
            character.Shoot();
            character.canAttack = false;
        }
            
        return character.idleState;
    }
    
}
