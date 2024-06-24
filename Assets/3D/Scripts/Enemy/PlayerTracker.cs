using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    #region Singleton; 
    public static PlayerTracker instance;

    void Awake()
    {
        instance = this; 
    } 
    #endregion

    public GameObject player; 
}
