using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    public class DeadState : ICharacterState
    {
        public ICharacterState DoState(CharacterBase character)
        {
            Debug.Log("Sono nello stato di morte!");
            return character.idleState;
        }
    }
}