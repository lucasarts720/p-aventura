using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour
{
    private Transform root;
    private IInventory inventory;

    private void Awake()
    {
        root = Camera.main.transform;
        inventory = GetComponent<IInventory>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && Physics.Raycast(root.position, root.forward, out RaycastHit hit, 3f, LayerMask.GetMask("Resources")))
        {
            IResource resource = hit.transform.GetComponentInParent<IResource>();
            if (resource != null) inventory.Add(resource.Collect, Random.Range(1, 4));
        }

        if (Input.GetKeyDown(KeyCode.E)
            && Physics.Raycast(root.position, root.forward, out RaycastHit collectHit, 3f, LayerMask.GetMask("Resources")))
        {

        }
    }
}
