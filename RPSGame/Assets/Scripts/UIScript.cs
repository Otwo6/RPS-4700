using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIScript : MonoBehaviour
{
    public GameObject rockUI;
    public GameObject paperUI;
    public GameObject scissorUI;
    public TMP_Text healthText;


    void Update() {
        if(Input.GetKeyDown("1")) {
            setWeaponUI(1);
        }
        if(Input.GetKeyDown("2")) {
            setWeaponUI(2);
        }
        if(Input.GetKeyDown("3")) {
            setWeaponUI(3);
        }
    }

    void setWeaponUI(int itemIndex) {
        rockUI.SetActive(false);
        paperUI.SetActive(false);
        scissorUI.SetActive(false);

        if(itemIndex == 1) {
            rockUI.SetActive(true);
        }
        else if(itemIndex == 2) {
            paperUI.SetActive(true);
        }
        else {
            scissorUI.SetActive(true);
        }
    }

    public void subtractHealth(int lives) {
        healthText.text = lives.ToString();
    }
}
