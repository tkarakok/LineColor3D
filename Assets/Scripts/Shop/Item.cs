using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // 0 - not purchased 1 - purchased but non equipped 2 - purchased and equipped
    public string name;
    public int itemId;
    public Color color;

    public void CheckItem()
    {
        itemId = PlayerPrefs.GetInt("item" + name);
        if (itemId != 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            if (itemId == 1)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
            if (itemId == 2)
            {

                gameObject.GetComponent<Outline>().enabled = true;
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
