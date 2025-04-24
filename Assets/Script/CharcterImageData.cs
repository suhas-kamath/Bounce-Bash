using System;
using UnityEngine;

[Serializable]
public class CharcterData {

    public Sprite sprite;
    public int count;

}

[CreateAssetMenu (fileName = "charcterImageData", menuName = "ScriptableObjects/charcterImageData")]
public class CharcterImageData : ScriptableObject {
    [SerializeField]
    CharcterData[] m_OfferPackPanel;

    public CharcterData GetData (int index) {
        return m_OfferPackPanel[index];
    }

}