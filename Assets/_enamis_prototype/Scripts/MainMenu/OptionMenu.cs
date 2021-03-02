using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    private GameObject optionMenu;
    void Start()
    {
        optionMenu = GameObject.Find("OptionMenu");
        optionMenu.SetActive(false);
    }
}
