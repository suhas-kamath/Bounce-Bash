using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour {
    [SerializeField]
    CharcterImageData CharcterImageData;
    [SerializeField]
    Button CloseButton;
    [SerializeField]
    List<SkinItem> SkinItems;

    void Start () {
        CloseButton.onClick.RemoveAllListeners ();
        CloseButton.onClick.AddListener (() => {
            SetActive (false);
        });

        for (int i = 0; i < SkinItems.Count; i++) {
            CharcterData charcdata = CharcterImageData.GetData (i);
            SkinItems[i].Setdata (i, charcdata.sprite, charcdata.count);
        }

    }
    public void SetActive (bool inEnable) {
        gameObject.SetActive (inEnable);
    }
    public CharcterImageData GetCharcterImageData () {
        return CharcterImageData;
    }

}