using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotColorSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material HighlightedMaterial;

    [SerializeField]
    private int SlotIndex = 0;


    private Material defaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    public void ActiveSlotChanged(int newSlotIndex)
    {
        GetComponent<MeshRenderer>().material = SlotIndex != newSlotIndex ? defaultMaterial : HighlightedMaterial;

    }
}
