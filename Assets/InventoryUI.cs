using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemUIPrefab;
    public List<GameObject> itemList = new List<GameObject>();
    public Transform Items;

    private float offset = 100;
    void Awake()
    {
        WorldBroadcast.ItemCollected.Subscribe(OnItemCollected);
        WorldBroadcast.ItemCollected.Subscribe(OnItemCollected);
    }

    private void OnDestroy()
    {
        WorldBroadcast.ItemCollected.Unsubscribe(OnItemCollected);
    }

    private void OnItemCollected(Sprite sprite)
    {
        Add(sprite);
    }

    private void Update()
    {

        var locPos = Items.transform.localPosition;
        var newPos = (itemList.Count - 2.8f) * offset / 2 * Vector3.left;
        Items.transform.localPosition += (newPos - locPos) / 20f;
    }

    private void Add(Sprite sprite)
    {
        var o = Instantiate(itemUIPrefab, Items);
        o.transform.localPosition = Vector3.right * (offset * (itemList.Count - 1));
        o.GetComponent<Image>().sprite = sprite;
        itemList.Add(o);
    }
    
}

