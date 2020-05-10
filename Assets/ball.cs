﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
   // public int speed=20;
    public Rigidbody2D sesuatu;
    
    public GameObject masterScript;
    public Animator animtr;
    public AudioSource hitEffect;
    void Start()
    {
        int x = Random.Range(0, 2) * 2 - 1; // x bisa -1 atau 1
        int y = Random.Range(0, 2) * 2 - 1; // y bisa -1 atau 1
        int speed = Random.Range(20, 26);
        sesuatu.velocity = new Vector2(x, y) * speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero; //mulai bola dari tengah
        animtr.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(sesuatu.velocity.x > 0){ //bola bergerak ke kana
            sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);    
        }else {
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name=="DindingKanan" || other.collider.name=="DindingKiri") {
           masterScript.GetComponent<ScoringScript>().UpdateScore(other.collider.name);
           StartCoroutine(jeda());
        }
        if (other.collider.tag == "Player")
        {
            hitEffect.Play();
        }
    }
    IEnumerator jeda(){
        sesuatu.velocity = Vector2.zero;
        animtr.SetBool("IsMove", false);
        sesuatu.GetComponent<Transform>().position = Vector2.zero;

        yield return new WaitForSeconds(1);

        int x = Random.Range(0, 2) * 2 - 1; // x bisa -1 atau 1
        int y = Random.Range(0, 2) * 2 - 1; // y bisa -1 atau 1
        int speed = Random.Range(20, 26);
        sesuatu.velocity = new Vector2(x, y) * speed;
        animtr.SetBool("IsMove", true);
    }
}
