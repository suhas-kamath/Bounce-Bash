using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class SkinItem : MonoBehaviour {

    public Button button;
    public Image Charcter;
    public TextMeshProUGUI Value;

    public void Setdata (int index, Sprite image, int Count) {
        int currentCount = PlayerPrefs.GetInt ("coins");
        Charcter.sprite = image;
        Value.text = Count.ToString ();
        button.onClick.RemoveAllListeners ();
        button.onClick.AddListener (() => {
            if (currentCount >= Count) {
                PlayerPrefs.SetInt ("coins", currentCount - Count);
                UiManager.Instance.UpdateUI (PlayerPrefs.GetInt ("score"), PlayerPrefs.GetInt ("coins"));
                UiManager.Instance.UpdateSkin (index);
            } else {
                Debug.LogError ("Low Count"); //Can Implement the flyer text if coin count is less
            }
        });
    }
}