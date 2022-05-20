using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipImage : MonoBehaviour
{
    [SerializeField] private List<GameObject> ships;
    [SerializeField] private List<int> shipCost;

    [SerializeField] private TextMeshProUGUI costTxt;

    public static int currentIndex;
    public static TextMeshProUGUI shs;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < ships.Count; i++) {
            ships[i].SetActive(false);
        }
        UpdateIcon();

        GlobalEventManager.OnSettingsChanged.AddListener(UpdateIcon);
    }

    void UpdateIcon() {
        for (int i = 0; i < ships.Count; i++) {
            ships[i].SetActive(false);
        }

        int index = PlayerPrefs.GetInt("ShipIndex");
        string namePlayerPref = "SH" + (index + 1).ToString();

        if (bool.Parse(PlayerPrefs.GetString(namePlayerPref))) {
            costTxt.SetText("Bought");
        }
        else {
            costTxt.SetText(shipCost[index].ToString());
        }

        ships[index].SetActive(true);
        currentIndex = index;
        shs = costTxt;
    }

    public static bool IsShipBought(int index) {
        return shs.text == "Bought";
    }
}
