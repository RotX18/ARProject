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
    private GameObject _rabbitParticles;

    private void FixedUpdate() {
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        if(Physics.Raycast(transform.position, Vector3.forward, out _hit)){
            //raycasting from the camera to 3f units infront
            if(_hit.transform.CompareTag("Rabbit")){
                //if the raycast obj has rabbit as its tag
                btnPet.gameObject.SetActive(true);

                //getting the game object responsible for the particles
                _rabbitParticles = _hit.transform.GetChild(3).gameObject;
            }
        }
        else{
            btnPet.gameObject.SetActive(false);
        }
    }

    public void OnClick_BtnPet(){
        //playing the hearts particle and debug logging the coin
        _rabbitParticles.GetComponent<ParticleSystem>().Play();
        Debug.Log("You have earned 1 coin!");
    }
}
