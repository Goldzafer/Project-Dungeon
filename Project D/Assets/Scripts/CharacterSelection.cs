using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public int characterNumber = 0;
    public GameObject[] characters;

    public GameObject fighter;
    public GameObject paladin;
    public GameObject priest;

    public void CycleCharacter(int i) //changes the characterNumber depending on if the player pressed up or down
    {
        int newCharacterNumber = characterNumber + i;
        int listLength = characters.Length;

        if (newCharacterNumber >= listLength)
        {
            newCharacterNumber = 0;
        }

        else if (newCharacterNumber < 0)
        {
            newCharacterNumber = listLength - 1;
        }

        characterNumber = newCharacterNumber;

        switch (characterNumber) //sets the right character active and disables the others depending on characterNumber
        {
            case 0:
                fighter.SetActive(true);
                paladin.SetActive(false);
                priest.SetActive(false);
                break;
            case 1:
                paladin.SetActive(true);
                fighter.SetActive(false);
                priest.SetActive(false);
                break;
            case 2:
                priest.SetActive(true);
                paladin.SetActive(false);
                fighter.SetActive(false);
                break;
        }
    }
}