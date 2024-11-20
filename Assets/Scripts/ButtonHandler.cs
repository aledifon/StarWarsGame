using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject menuCanvas;    

    private AudioSource startAudio;

    public TextMeshProUGUI myText;
    public Button myButton;
    private Image buttonImage;
    private TextMeshProUGUI buttonText;    

    private void Awake()
    {
        startAudio = GetComponent<AudioSource>();

        //buttonImage = myButton.GetComponent<Image>(); // El componente Image que representa el fondo del botón
        //buttonText = myButton.GetComponentInChildren<TextMeshProUGUI>(); // El texto del botón (si existe)
    }

    public void StartGame() 
    {
        //Debug.Log("boton pulsado");
        if (menuCanvas != null)
        {
            startAudio.Play();              // Start playing music
            //menuCanvas.SetActive(false);            
        }
        HideUIControls();
        Invoke("LoadGameScene", 3f);
        //SceneManager.LoadScene("GameScene");  // Cambia "GameScene" por el nombre de tu escena de juego
    }

    private void HideUIControls()
    {
        //Disable the Title Game Text
        myText.gameObject.SetActive(false);

        // Set the Title Game Text as transparent
        //HideText();

        //Disable the Play button
        myButton.gameObject.SetActive(false);

        // Set the Play button as transparent
        //HideButton();
    }
    //void HideText()
    //{
    //    // Set the Title Game Text as transparent
    //    Color textGameColor = myText.color;
    //    textGameColor.a = 0f;
    //    myText.color = textGameColor;
    //}
    //void HideButton()
    //{
    //    Color imgColor = buttonImage.color;
    //    imgColor.a = 1f;  // Establecer el alpha a 1 (opaco)
    //    buttonImage.color = imgColor;

    //    Color textColor = buttonText.color;
    //    textColor.a = 1f;  // Establecer el alpha a 1 (opaco)
    //    buttonText.color = textColor;
    //}

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");  // Cambia "GameScene" por el nombre de tu escena de juego
    }
}
