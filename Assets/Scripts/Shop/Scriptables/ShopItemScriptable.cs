using System.Collections.Generic;
using Core.Interfaces.Shop;
using UnityEngine;

namespace Shop.Scriptables
{
    [CreateAssetMenu(fileName = "ShopItemScriptable", menuName = "XFLOW/Shop/ShopItemScriptable", order = 1)]
    public class ShopItemScriptable : ScriptableObject
    {
        public string itemName;

        [SerializeReference]
        public List<IRequirementData> Requirements;

        [SerializeReference]
        public List<IChangeData> Changes;
    }
}