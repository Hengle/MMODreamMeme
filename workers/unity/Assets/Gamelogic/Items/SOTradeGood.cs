using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using ItemCode;
[System.Serializable]
[CreateAssetMenu(menuName = "Items/TradeGood")]
public class SOTradeGood : SOItem {

        

        [EnumFlags]
        public TradeGoodType m_TradeGoodType;
}
