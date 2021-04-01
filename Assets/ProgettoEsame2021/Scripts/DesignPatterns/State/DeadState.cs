using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    //Classe che gestisce lo stato di Morte.
    public class DeadState : ICharacterState
    {
        //Funzione che definisce il comportamento dello stato.
        public ICharacterState DoState(CharacterBase character)
        {
            Debug.Log("Sono nello stato di morte!");
            //cambia il colore del character.
            character.GetComponent<SpriteRenderer>().color = Color.red;
            return character.idleState;
        }
    }
}