using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField] private IntSO scoreSO;

    void Start()
    {
        scoreSO.Value = 0;
    }
}
