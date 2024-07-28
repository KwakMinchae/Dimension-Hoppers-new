using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionHopCard : MonoBehaviour //specifically attached to the Dimension Hop Card
{
    public AudioClip popSoundEffect;
    [SerializeField] GameObject dimensionHopCard;
    private void OnMouseDown() //when pressed by mouse, go to 3D scene
    {       
        AudioManager.Instance.Play(popSoundEffect);
        SceneManager.LoadScene("3D");
        Destroy(dimensionHopCard);
    }
}
