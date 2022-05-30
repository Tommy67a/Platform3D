using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndResult : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    [SerializeField] private IntSO scoreSO;

    void Start()
    {
        scoreText.text = scoreSO.Value + "";
    }    
}
