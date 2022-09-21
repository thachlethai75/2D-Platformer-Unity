using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject[] skins;
    [SerializeField] int selectCharacter;
    [SerializeField] Character[] characters;
    [SerializeField] Button unLockButton;
    [SerializeField] TextMeshProUGUI coinText;

    private void Awake()
    {
        selectCharacter = PlayerPrefs.GetInt("SelectCharacter", 0);
        foreach(GameObject player in skins)
            player.SetActive(false);
        skins[selectCharacter].SetActive(true);

        foreach(Character c in characters)
        {
            if (c.pice == 0)
                c.isUnlock = true;
            else
            {
                if(PlayerPrefs.GetInt(c.name, 0) == 0)
                {
                    c.isUnlock = false;
                }else
                {
                    c.isUnlock= true;
                }
                c.isUnlock = PlayerPrefs.GetInt(c.name, 0) == 0 ? false:true;
            }
        }

        UpdateUI();
    }

    public void ChangeNext()
    {
        skins[selectCharacter].SetActive(false);
        selectCharacter++;
        if(selectCharacter == skins.Length)
            selectCharacter = 0;
        skins[selectCharacter].SetActive(true);
        if (characters[selectCharacter].isUnlock)
            PlayerPrefs.SetInt("SelectCharacter", selectCharacter);
        UpdateUI();
    }

    public void ChangePrevious()
    {
        skins[selectCharacter].SetActive(false);
        selectCharacter--;
        if (selectCharacter == -1)
            selectCharacter = skins.Length -1;
        skins[selectCharacter].SetActive(true);
        if (characters[selectCharacter].isUnlock)
            PlayerPrefs.SetInt("SelectCharacter", selectCharacter);
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinText.text = "Coin:" + PlayerPrefs.GetInt("NumberOfCoin", 0);
        if (characters[selectCharacter].isUnlock == true)
            unLockButton.gameObject.SetActive(false);
        else
        {
            unLockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[selectCharacter].pice;
            if (PlayerPrefs.GetInt("NumberOfCoin", 0) < characters[selectCharacter].pice)
            {
                unLockButton.gameObject.SetActive(true);
                unLockButton.interactable = false;
            }
            else
            {
                unLockButton.gameObject.SetActive(true);
                unLockButton.interactable = true;
            }
        }
    }

    public void UnLock()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoin", 0);
        int price = characters[selectCharacter].pice;
        PlayerPrefs.SetInt("NumberOfCoin", coins - price);
        PlayerPrefs.SetInt(characters[selectCharacter].name, 1);
        PlayerPrefs.SetInt("SelectCharacter", selectCharacter);
        characters[selectCharacter].isUnlock = true;
        UpdateUI();
    }
}
