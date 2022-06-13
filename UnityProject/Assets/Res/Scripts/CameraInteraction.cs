using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraInteraction : MonoBehaviour
{
    //PUBLIC VARS
    public Button btnPet;

    //PRIVATE VARS
    private RaycastHit _hit;
    private ParticleSystem _rabbitParticles;

    private void FixedUpdate() {
        if(Physics.Raycast(transform.position, transform.forward, out _hit, Mathf.Infinity)){
            //raycasting from the camera to 3f units infront
            if(_hit.transform.CompareTag("Rabbit")){
                //if the raycast obj has rabbit as its tag
                btnPet.gameObject.SetActive(true);

                //getting the game object responsible for the particles
                _rabbitParticles = _hit.transform.GetComponent<ParticleSystem>();
            }
        }
        else{
            btnPet.gameObject.SetActive(false);
        }
    }

    public void OnClick_BtnPet(){
        //playing the hearts particle and debug logging the coin
        _rabbitParticles.Play();
        Debug.Log("You have earned 1 coin!");
    }
}
