using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public int age;
    public string occupation;
}
