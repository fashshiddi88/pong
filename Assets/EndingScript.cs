using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI endingtext;
    void Start()
    {
        if(ScoringScript.scoreP1 > ScoringScript.scoreP2){
            endingtext.text = "PLAYER 1 WIN!";
        }else if(ScoringScript.scoreP1 < ScoringScript.scoreP2){
            endingtext.text = "PLAYER 2 WIN!";
        }else {
            endingtext.text = "DRAW";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
