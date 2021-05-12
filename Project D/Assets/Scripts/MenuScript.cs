using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    /*useless in finalized
    public CharacterSelection characterSelection1;
    public CharacterSelection characterSelection2;
    public CharacterSelection characterSelection3;

    private int selectedCharacter1;
    private int selectedCharacter2;
    private int selectedCharacter3;*/

    public void LoadCharacterSelection()
    {
        SceneManager.LoadScene("Test Dungeon");
    }

    /*useless in finalized
    public void LoadDungeon() //saves all the characters in playerprefs by their coresponding number
    {
        selectedCharacter1 = characterSelection1.characterNumber;
        selectedCharacter2 = characterSelection2.characterNumber;
        selectedCharacter3 = characterSelection3.characterNumber;

        PlayerPrefs.SetInt("selectedCharacter1", selectedCharacter1);
        PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter2);
        PlayerPrefs.SetInt("selectedCharacter3", selectedCharacter3);

        SceneManager.LoadScene("Test Dungeon");
    }*/

    public void QuitGame()
    {
        Application.Quit();
    }
}