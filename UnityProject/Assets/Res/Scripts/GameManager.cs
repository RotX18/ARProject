using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DigitalRuby.RainMaker;

public class GameManager : MonoBehaviour
{
    //PUBLIC VARS
    public GameObject rainEffect;
    public Light directionalLight;
    public Button btnRainToggle;

    //PRIVATE VARS
    private bool _rain = false;

    //ROPERTIES
    public bool Rain{ 
        get{
            return Rain;
        }
        set{
            _rain = value;
        }
    }

    private void Update() {
        if(_rain){
            //finding the RainScript component and setting the RainIntensity to 1 to add the rain
            rainEffect.GetComponent<RainScript>().RainIntensity = 1;

            //reducing the light intensity to give the impression of rainy day
            directionalLight.intensity = 0.45f;
            btnRainToggle.GetComponentInChildren<TextMeshProUGUI>().text = "Rainy";
        }
        else{
            //finding the RainScript component and setting the RainIntensity to 0 to remove the rain
            rainEffect.GetComponent<RainScript>().RainIntensity = 0;

            //increasing the light intensity to give the impression of sunny day
            directionalLight.intensity = 1.5f;
            btnRainToggle.GetComponentInChildren<TextMeshProUGUI>().text = "Sunny";
        }
        Debug.Log(directionalLight.intensity);
    }

    public void OnClick_BtnRainToggle(){
        //flipping the valie of _rain
        _rain = !_rain;
    }

    public void OnTargetFound_ShowButton(){
        btnRainToggle.gameObject.SetActive(true);
        rainEffect.GetComponent<RainScript>().RainIntensity = 0;
    }
    
    public void OnTargetLost_HideButton(){
        btnRainToggle.gameObject.SetActive(false);
        rainEffect.GetComponent<RainScript>().RainIntensity = 0;
    }
}
