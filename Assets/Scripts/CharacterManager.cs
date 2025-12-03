using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject characterPrefab;
    public List<Transform> spawnPoints;
    //public List<Character> characters = new List<Character>();
    public List<CharacterData> characterDataList;
    public List<Character> spawnedCharacters = new List<Character>();
    
    void Start()
    {
        SpawnCharacters();
    }
    
    void SpawnCharacters()
    {
        Shuffle(spawnPoints);

        // Spawn each character at a random spawn point
        for (int i = 0; i < characterDataList.Count; i++)
        {
            GameObject characterObj = Instantiate(characterPrefab, spawnPoints[i].position, Quaternion.identity);
            
            Character character = characterObj.GetComponent<Character>();
            if (character != null)
            {
                character.Initialize(characterDataList[i]);
                spawnedCharacters.Add(character);
            }
        }
    }
    
    // Helper method to find a character by name
    public Character GetCharacterByName(string name)
    {
        return spawnedCharacters.Find(c => c.characterData.characterName == name);
    }
    public void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }
}
