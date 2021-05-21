using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


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
    public GameObject PowerupTextObject;
    public GameObject GoldenCloudText;
    public GameObject Bridge;
    public bool Win = false;
    public bool Lose = false;
    public bool Wings = false;
    public bool gameactive = false;
    public AudioClip Harp;
    public AudioClip WingedJump;
    public AudioSource asPlayer;
    public Button WinButton;
    public Button LoseButton;
    public Button StartButton;
    private PlayerMovement playermovement;
    private MouseLook mouselook;
   

    void Start()
    {
        
        gameactive = false;
        GoldenCloudText.SetActive(true);
        StartButton.gameObject.SetActive(true);
        asPlayer = GetComponent<AudioSource>();
        playermovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        mouselook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        particlesGC.SetActive(false);
        playermovement.enabled = false; 
      
    }
   public void GameStart()
    {
        Win = false;
        Lose = false;
        Wings = false;
        count = 0;
        ExitTextObject.SetActive(false);
        Exit.SetActive(false);
        WinTextObject.SetActive(false);
        LoseTextObject.SetActive(false);
        GoldenCloudText.SetActive(false);
        PowerupTextObject.SetActive(false);
        WinButton.gameObject.SetActive(false);
        LoseButton.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        playermovement.enabled = true;
        gameactive = true;
        Bridge.SetActive(false);
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
        else if (other.gameObject.CompareTag("Exit"))
        {
            WinTextObject.SetActive(true);
            Win = true;
            asPlayer.PlayOneShot(Harp, 1);
            playermovement.enabled = false;
            particlesGC.SetActive(true);
            WinButton.gameObject.SetActive(true);
            ExitTextObject.SetActive(false);
            gameactive = false;
        }
         else if (other.gameObject.CompareTag("Dark Platform"))
        {
            LoseTextObject.SetActive(true);
            Lose = true;
            playermovement.enabled = false;
            LoseButton.gameObject.SetActive(true);
            ExitTextObject.SetActive(false);
            gameactive = false;
        }
         else if (other.gameObject.CompareTag("PowerUp"))
        {
            Wings = true;
            Destroy(other.gameObject);
            PowerupTextObject.SetActive(true);
        }
         else if (other.gameObject.CompareTag("PowerUpCube"))
        {
            Bridge.SetActive(true);
            other.gameObject.SetActive(false);
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
