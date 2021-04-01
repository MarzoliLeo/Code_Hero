using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    //Classe che gestisce lo stato di Idle.
    public class IdleState : ICharacterState
    {
        //Funzione che definisce il comportamento dello stato.
        public ICharacterState DoState(CharacterBase character)
        {
            Debug.Log("Sono nello stato di Idle!");
            //Gestisce gli altri stati in caso che il "character" possa attaccare...
            if (character.canAttack)
                return character.attackState;
            else if (character.isDead) //... oppure sia morto.
                return character.deadState;
            else //... altrimenti non succede nulla e rimane in Idle.
                return character.idleState;
        }
    }
}