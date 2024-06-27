using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionHopCard : MonoBehaviour
{
    [SerializeField] GameObject dimensionHopCard;
    bool canActivate = true;
    int count = -1; 

    // Start is called before the first frame update
    void Start()
    {
        count++;
        Debug.Log("count is " + count);
    }
    void Update()
    {
        if (canActivate == true && count % 3 == 0 && Input.GetKeyDown(KeyCode.F))
        {
           
                canActivate = false;
                count++;
                SceneManager.LoadScene("3D");
                Debug.Log("count is " + count);
            
        }
    }   
}
