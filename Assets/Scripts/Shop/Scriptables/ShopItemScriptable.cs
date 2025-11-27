using System.Collections.Generic;
using Shop.Interfaces;
using Shop.Structs.Changes;
using UnityEngine;
using UnityEngine.Serialization;

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