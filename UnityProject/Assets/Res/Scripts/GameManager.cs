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
    public enum RainMode{ 
        Sunny,
        Rain,
        Storm
    }
    private RainMode _rain = RainMode.Sunny;
    private int _rainValue = 0; //0 = Sunny, 1 = Rain, 2 = Storm

    //ROPERTIES
    public bool Rain{ 
        get{
            return Rain;
        }
    }

    private void Update() {
        if(_rain == RainMode.Storm){
            //STORM STATE
            //finding the RainScript component and setting the RainIntensity to 1 to have the maximum rain effect
            rainEffect.GetComponent<RainScript>().RainIntensity = 1f;

            //further reducing the light intensity to 1f to give the impression of heavy storms
            directionalLight.intensity = 0.8f;
            btnRainToggle.GetComponentInChildren<TextMeshProUGUI>().text = "Stormy";

            //enabling the wind sounds
            rainEffect.GetComponent<RainScript>().EnableWind = true;
        }
        else if(_rain == RainMode.Rain){
            //RAIN STATE
            //finding the RainScript component and setting the RainIntensity to 0.75 to add the rain
            rainEffect.GetComponent<RainScript>().RainIntensity = 0.75f;

            //reducing the light intensity to give the impression of rainy day
            directionalLight.intensity = 1.3f;
            btnRainToggle.GetComponentInChildren<TextMeshProUGUI>().text = "Rainy";

            //disabling wind sounds
            rainEffect.GetComponent<RainScript>().EnableWind = false;
        }
        else{
            //finding the RainScript component and setting the RainIntensity to 0 to remove the rain
            rainEffect.GetComponent<RainScript>().RainIntensity = 0;

            //increasing the light intensity to give the impression of sunny day
            directionalLight.intensity = 2.5f;
            btnRainToggle.GetComponentInChildren<TextMeshProUGUI>().text = "Sunny";

            //disabling wind sounds
            rainEffect.GetComponent<RainScript>().EnableWind = false;
        }
    }

    public void OnClick_BtnRainToggle(){
        //cycling the values of _rain
        _rainValue += 1;

        if(_rainValue >= 3){
            //if _rainValue is >= number of items in RainMode, change the value to 0 (RainMode.Sunny)
            _rainValue = 0;
        }

        switch(_rainValue){
            case 0:
                //0 = Sunny mode
                _rain = RainMode.Sunny;
                break;
            case 1:
                //1 = Rain mode
                _rain = RainMode.Rain;
                break;
            case 2:
                //2 = Storm mode
                _rain = RainMode.Storm;
                break;
        }
    }

    public void OnTargetFound_ShowButton(){
        btnRainToggle.gameObject.SetActive(true);
        rainEffect.GetComponent<RainScript>().RainIntensity = 0;
        rainEffect.GetComponent<RainScript>().EnableWind = false;
    }
    
    public void OnTargetLost_HideButton(){
        btnRainToggle.gameObject.SetActive(false);
        rainEffect.GetComponent<RainScript>().RainIntensity = 0;
        rainEffect.GetComponent<RainScript>().EnableWind = false;
    }
}
