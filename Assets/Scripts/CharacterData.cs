using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public GameObject characterPrefab;  
    //public CharacterData inLoveWith;
    public Player enchantedBy;
    public Sprite appearance; 
}
