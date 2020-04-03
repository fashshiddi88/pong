using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public int speed=20;
    public Rigidbody2D sesuatu;
    // Start is called before the first frame update
    public Animator animtr;
    void Start()
    {
        sesuatu.velocity = new Vector2(-1,-1) * speed;
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
           StartCoroutine(jeda());
        }
    }
    IEnumerator jeda(){
        sesuatu.velocity = Vector2.zero;
        animtr.SetBool("IsMove", false);
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        yield return new WaitForSeconds(1);
        sesuatu.velocity = new Vector2(-1,-1) * speed;
        animtr.SetBool("IsMove", true);
    }
}
