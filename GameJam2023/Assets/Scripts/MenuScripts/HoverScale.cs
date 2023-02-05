using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScale : MonoBehaviour
{

    public AudioSource hoverSound;

    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
        hoverSound.Play();
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
