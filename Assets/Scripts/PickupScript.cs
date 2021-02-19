using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    public GameObject ExitTextObject;
    public GameObject Exit;
    public GameObject WinTextObject;
    
   

    void Start()
    {
        count = 0;
        SetCountText();
        ExitTextObject.SetActive(false);
        Exit.SetActive(false);
        WinTextObject.SetActive(false);
       
    }

    void Update()
    {  
            
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Pickup"))
        {
            count = count + 1;
            SetCountText();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            WinTextObject.SetActive(true);
           
        }
              
    }
    void SetCountText()
    {
        countText.text = "Orbs: " + count.ToString() + "/3";
        if (count >= 3)
        {
            ExitTextObject.SetActive(true);
            Exit.SetActive(true);
            
        }
    }
}
