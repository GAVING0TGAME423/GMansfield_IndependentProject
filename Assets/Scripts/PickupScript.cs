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
    public GameObject LoseTextObject;
    public GameObject goldencloud;
    public GameObject particlesGC;
    public bool Win = false;
    public bool Lose = false;
    public AudioClip Harp;
    private AudioSource asPlayer;
    private PlayerMovement playermovement;
    private MouseLook mouselook;
   

    void Start()
    {
        Win = false;
        Lose = false;
        count = 0;
        SetCountText();
        ExitTextObject.SetActive(false);
        Exit.SetActive(false);
        WinTextObject.SetActive(false);
        LoseTextObject.SetActive(false);
        asPlayer = GetComponent<AudioSource>();
        playermovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        mouselook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        particlesGC.SetActive(false);

    }


    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Pickup"))
        {
            count = count + 1;
            SetCountText();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            WinTextObject.SetActive(true);
            Win = true;
            asPlayer.PlayOneShot(Harp, 1);
            playermovement.enabled = false;
            mouselook.enabled = false;
            particlesGC.SetActive(true);
        }
         else if (other.gameObject.CompareTag("Dark Platform") && !Win)
        {
            LoseTextObject.SetActive(true);
            Lose = true;
            playermovement.enabled = false;
            mouselook.enabled = false;
        }
              
    }

   
    void SetCountText()
    {
        countText.text = "Orbs: " + count.ToString() + "/3";
        if (count == 3)
        {
            ExitTextObject.SetActive(true);
            Exit.SetActive(true);
            
        }
    }
}
