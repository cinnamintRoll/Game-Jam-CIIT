using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactionDistance = 3f;
    public Material outlineMaterial;
    public GameObject promptPrefab;

    private Material originalMaterial;
    private Renderer objectRenderer;
    private GameObject promptInstance;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    private void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactionDistance))
        {
            if (hitInfo.collider.gameObject == gameObject)
            {
                objectRenderer.material = outlineMaterial;

                if (promptInstance == null)
                {
                    promptInstance = Instantiate(promptPrefab, transform.position + Vector3.up, Quaternion.identity);
                }

                promptInstance.transform.LookAt(Camera.main.transform);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interacted");
                }
            }
            else
            {
                objectRenderer.material = originalMaterial;

                if (promptInstance != null)
                {
                    Destroy(promptInstance);
                }
            }
        }
        else
        {
            objectRenderer.material = originalMaterial;

            if (promptInstance != null)
            {
                Destroy(promptInstance);
            }
        }
    }
}
