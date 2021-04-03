using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    //public GameObject popup;
    public void ClosePopUp()
    {
        this.gameObject.SetActive(false);
        //popup.SetActive(false);
    }
}
