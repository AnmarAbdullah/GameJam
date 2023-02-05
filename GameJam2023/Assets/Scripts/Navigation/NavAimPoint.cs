using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NavAimPoint : MonoBehaviour
{

    Navigation navControl;
    LookAtConstraint lookAt;
    NavigationPoint connectedPoint;
    AudioSource audio;

    private void Awake()
    {
        navControl = FindObjectOfType<Navigation>();
        audio = GetComponent<AudioSource>();
    }

    public void AimAtPoint(NavigationPoint point)
    {
        connectedPoint = point;
        lookAt = GetComponent<LookAtConstraint>();
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = point.transform;
        source.weight = 1;

        lookAt.AddSource(source);
        lookAt.constraintActive = true;
    }

    public void SelectPoint()
    {
        navControl.SetPosition(connectedPoint);
        audio.Play();
    }
}
