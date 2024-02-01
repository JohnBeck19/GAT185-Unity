using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] item;
    public Item currentItem { get; private set; }   
    // Start is called before the first frame update
    void Start()
    {
        currentItem = item[0];
        currentItem.Equip();
    }
    public void Use()
    {
        currentItem?.Use();

    }
    public void StopUse()
    { 
        currentItem?.StopUse();
    }
}
