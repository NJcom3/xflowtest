using System.Collections.Generic;
using UnityEngine;

namespace Shop.Scriptables
{
    [CreateAssetMenu(fileName = "ShopScriptable", menuName = "XFLOW/Shop/ShopScriptable", order = 0)]
    public class ShopScriptable : ScriptableObject
    {
        public List<ShopItemScriptable> items;
    }
}