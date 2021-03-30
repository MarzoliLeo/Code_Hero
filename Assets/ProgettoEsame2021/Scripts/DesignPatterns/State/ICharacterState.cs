using System;
using UnityEngine.UI;
using UnityEngine;

public interface ICharacterState
{
    ICharacterState DoState(CharacterBase character);
}
