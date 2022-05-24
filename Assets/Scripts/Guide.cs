using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    [SerializeField] private List<Button> guides;

    private int index = 0;

    void Start() {
        for (int i = 0; i < guides.Count; i++)
            guides[i].gameObject.SetActive(true);
    }

    public void OnGuideClick() {
        guides[index].gameObject.SetActive(false);
        index++;
        if (index >= guides.Count)
            GlobalEventManager.OnGameStatusChanged.Invoke(4);
    }
}
