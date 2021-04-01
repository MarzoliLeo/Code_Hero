using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    //Classe che gestisce lo stato di Attacco.
    public class AttackState : ICharacterState
    {
        //Funzione che definisce il comportamento dello stato.
        public ICharacterState DoState(CharacterBase character)
        {
            Debug.Log("sto attaccando!");

            if (character.canAttack)
            {
                character.Shoot();
                character.canAttack = false;
            }
            
            return character.idleState;
        }
    
    }
}
