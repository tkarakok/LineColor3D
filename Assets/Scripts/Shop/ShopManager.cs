using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<Item> items;
    public List<Item> equipItem;
    public MeshRenderer cubeRenderer;
    public Material trail;
    public Button unlockButton;
    private float _emissionColorIntensityForCube = .002f;
    private bool _firstGame;

    private void Start()
    {
        _firstGame = PlayerPrefs.GetInt("firstgame") == 0;
        if (_firstGame)
        {
            PlayerPrefs.SetInt("firstgame", 1);
            PlayerPrefs.SetInt("item" + items[0].name, 2);
        }
        CheckItems();

    }
    private void Update()
    {
        if (GameManager.Instance.TotalCoin >= 1000)
        {
            unlockButton.interactable = true;
        }
        else
        {
            unlockButton.interactable = false;
        }
    }

    public void CheckItems()
    {
        foreach (Item item in items)
        {
            item.CheckItem();
            if (item.itemId == 2)
            {
                equipItem.Remove(equipItem[0]);
                equipItem.Add(item);
                cubeRenderer.material.color = item.color;
                
                cubeRenderer.material.SetColor("_EmissionColor", item.color * _emissionColorIntensityForCube);
                ChangeTrailColor(item);
            }
        }
    }
    public void ChangeTrailColor(Item item)
    {
        PathFollower.Instance.transform.GetChild(0).GetComponent<TrailRenderer>().material = trail;
        trail.color = item.color;
        trail.SetColor("_EmissionColor", item.color * 1f);
    }

    public void EquipButton(int index)
    {
        PlayerPrefs.SetInt("item" + equipItem[0].name, 1);
        equipItem[0].GetComponent<Outline>().enabled = false;
        equipItem[0].CheckItem();
        equipItem.Remove(equipItem[0]);
        PlayerPrefs.SetInt("item" + items[index].name, 2);
        items[index].GetComponent<Outline>().enabled = true;
        cubeRenderer.material.color = items[index].color;
        cubeRenderer.material.SetColor("_EmissionColor", items[index].color * _emissionColorIntensityForCube);
        items[index].CheckItem();
        equipItem.Add(items[index]);
        ChangeTrailColor(items[index]);
    }

    public void UnlockRandomItem()
    {
        PlayerPrefs.SetInt("Coin", (GameManager.Instance.TotalCoin - 1000));
        GameManager.Instance.TotalCoin = PlayerPrefs.GetInt("Coin");
    again:
        int random = Random.Range(0, 12);
        if (items[random].itemId == 0)
        {
            PlayerPrefs.SetInt("item" + items[random].name, 1);
            CheckItems();
        }
        else
        {
            goto again;
        }


    }
}
