using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandHider : MonoBehaviour
{
    public GameObject handObject = null;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor interactor = null;

    public SkinnedMeshRenderer HandMesh = null;
    
    public SphereCollider SphereCollider_1 = null;
    public SphereCollider SphereCollider_2 = null;

    private void Awake()
    {
        interactor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor>();
        HandMesh = handObject.GetComponent<SkinnedMeshRenderer>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(Hide);
        interactor.selectExited.AddListener(Show);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(Hide);
        interactor.selectExited.RemoveListener(Show);
    }
    
    
    private void Show(UnityEngine.XR.Interaction.Toolkit.SelectExitEventArgs args)
    {
        HandMesh.enabled = true;
        SphereCollider_1.enabled = true;
        SphereCollider_2.enabled = true;
    }

    private void Hide(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
    {
        HandMesh.enabled = false;
        SphereCollider_1.enabled = false;
        SphereCollider_2.enabled = false;
    }
}
