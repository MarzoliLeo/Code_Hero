using ProgettoEsame2021.Scripts.DesignPatterns.State;

public interface ICharacterState
{
    ICharacterState DoState(CharacterBase character);
}
