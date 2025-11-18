using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Character> charactersEnchanted;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charactersEnchanted = new List<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // adds character to player's list if they successfully get enchanted
    public void EnchantCharacterWithLovePotion(Character character)
    {
        charactersEnchanted.Add(character);
        // remove character from any other players' lists
    }
}
