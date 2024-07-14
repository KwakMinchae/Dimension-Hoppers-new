using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionHopCard : MonoBehaviour
{
    [SerializeField] GameObject dimensionHopCard;
    private void OnMouseDown()
    {
        SceneManager.LoadScene("3D");
        Destroy(dimensionHopCard);
    }
}
