using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionHopCard : MonoBehaviour
{
    public AudioClip popSoundEffect;
    [SerializeField] GameObject dimensionHopCard;
    private void OnMouseDown()
    {       
        AudioManager.Instance.Play(popSoundEffect);
        SceneManager.LoadScene("3D");
        Destroy(dimensionHopCard);
    }
}
