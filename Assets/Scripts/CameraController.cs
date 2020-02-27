﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSteps = 10f; 
    private float currentStep;
    private bool lavaFirstTutorial = true;
    public Camera cameratarget;
    public GameObject player;
    public GameObject wall;
    public Rigidbody2D bird;

    void LateUpdate()
    {
        if(player.transform.position.x>-11)
        {
            currentStep += Time.deltaTime;
            Vector3 oldposition = this.transform.position;
            this.transform.position = Vector3.Lerp(oldposition, cameratarget.transform.position, currentStep / panSteps);
            wall.SetActive(true);
            if(bird.gameObject.activeInHierarchy)
            {
                bird.velocity = new Vector2(bird.velocity.x + 0.04f, bird.velocity.y + 0.03f);
            }
            if (lavaFirstTutorial)
            {
                player.GetComponent<Movement>().playerPos = player.transform.position;
                GetComponentInParent<Cubes>().LavaTutorial();
                lavaFirstTutorial = false;
            }
            //GetComponentInParent<Cubes>().lavaFall = true;
        }
    }
}
