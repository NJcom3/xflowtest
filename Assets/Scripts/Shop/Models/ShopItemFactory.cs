using System.Collections.Generic;
using NUnit.Framework;
using Shop.Interfaces;
using Shop.Models.Changes;
using Shop.Models.Requirements;
using Shop.Scriptables;
using Shop.Structs.Changes;
using Shop.Structs.Requirements;
using Zenject;

namespace Shop.Models
{
    public class ShopItemFactory
    {
        private DiContainer _diContainer;

        [Inject]
        public void Construct(
            DiContainer diContainer
        )
        {
            _diContainer = diContainer;
        }
        
        public ShopItemModel CreateShopItem(ShopItemScriptable shopItemScriptable)
        {
            var model = new ShopItemModel(
                shopItemScriptable.itemName, 
                GetChangesList(shopItemScriptable),
                GetRequirementsList(shopItemScriptable)
                );
            _diContainer.Inject(model);
            return model;
        }

        private List<IRequirement> GetRequirementsList(ShopItemScriptable shopItemScriptable)
        {
            var list = new List<IRequirement>();
            foreach (var requirementData in shopItemScriptable.Requirements)
            {
                IRequirement requirement;
                switch (requirementData)
                {
                    case RequirementAllowedLocationData allowedLocationData:
                        requirement = new RequirementAllowedLocations(allowedLocationData.AllowedLocationList);
                        break;
                    case RequirementMaxGoldData maxGoldData:
                        requirement = new RequirementMaxGold(maxGoldData.MaxGoldCount);
                        break;
                    case RequirementMaxHealthData maxHealthData:
                        requirement = new RequirementMaxHealth(maxHealthData.MaxHealthCount);
                        break;
                    case RequirementMaxVipTimeData maxVipTimeData:
                        requirement = new RequirementMaxVipTime(maxVipTimeData.MaxVipHours, maxVipTimeData.MaxVipMinutes, maxVipTimeData.MaxVipSeconds);
                        break;
                    case RequirementMinGoldData minGoldData:
                        requirement = new RequirementMinGold(minGoldData.MinGoldCount);
                        break;
                    case RequirementMinHealthData minHealthData:
                        requirement = new RequirementMinHealth(minHealthData.MinHealthCount);
                        break;
                    case RequirementMinVipTimeData minVipTimeData:
                        requirement = new RequirementMinVipTime(minVipTimeData.MinVipHours, minVipTimeData.MinVipMinutes, minVipTimeData.MinVipSeconds);
                        break;          
                    case RequirementNotAllowedLocationData notAllowedLocationData:
                        requirement = new RequirementNotAllowedLocations(notAllowedLocationData.NotAllowedLocationList);
                        break;
                    default:
                        //TODO: Throw error
                        requirement = null;
                        break;
                }
                
                if (requirement != null)
                {
                    _diContainer.Inject(requirement); 
                    list.Add(requirement);
                }

            }
            return list;
        }

        private List<IChange> GetChangesList(ShopItemScriptable shopItemScriptable)
        {
            var list = new List<IChange>();
            foreach (var changeData in shopItemScriptable.Changes)
            {
                IChange change;
                switch (changeData)
                {
                    case ChangeAddGoldPercentData addGoldPercentData:
                        change = new ChangeAddGoldPercent(addGoldPercentData.GoldPercent);
                        break;
                    case ChangeAddGoldValueData addGoldValueData:
                        change = new ChangeAddGoldValue(addGoldValueData.GoldCount);
                        break;
                    case ChangeAddHealthPercentData changeAddHealthPercentData:
                        change = new ChangeAddHealthPercent(changeAddHealthPercentData.HealthPercent);
                        break;
                    case ChangeAddHealthValueData addHealthValue:
                        change = new ChangeAddHealthValue(addHealthValue.HealthCount);
                        break;
                    case ChangeAddVipTimePercentData addVipTimePercentData:
                        change = new ChangeAddVipTimePercent(addVipTimePercentData.VipTimePercent);
                        break;
                    case ChangeAddVipTimeValueData changeAddVipTimeValueData:
                        change = new ChangeAddVipTimeValue(changeAddVipTimeValueData.VipHours,
                            changeAddVipTimeValueData.VipMinutes, changeAddVipTimeValueData.VipSeconds);
                        break;
                    case ChangeGoToLocationData goToLocationData:
                        change = new ChangeGoToLocation(goToLocationData.LocationName);
                        break;
                    case ChangeRemoveGoldPercentData removeGoldPercentData:
                        change = new ChangeRemoveGoldPercent(removeGoldPercentData.GoldPercent);
                        break;
                    case ChangeRemoveGoldValueData removeGoldValueData:
                        change = new ChangeRemoveGoldValue(removeGoldValueData.GoldCount);
                        break;
                    case ChangeRemoveHealthPercentData changeRemoveHealthPercentData:
                        change = new ChangeRemoveHealthPercent(changeRemoveHealthPercentData.HealthPercent);
                        break;
                    case ChangeRemoveHealthValueData removeHealthValue:
                        change = new ChangeRemoveHealthValue(removeHealthValue.HealthCount);
                        break;
                    case ChangeRemoveVipTimePercentData removeVipTimePercentData:
                        change = new ChangeRemoveVipTimePercent(removeVipTimePercentData.VipTimePercent);
                        break;
                    case ChangeRemoveVipTimeValueData changeRemoveVipTimeValueData:
                        change = new ChangeRemoveVipTimeValue(changeRemoveVipTimeValueData.VipHours,
                            changeRemoveVipTimeValueData.VipMinutes, changeRemoveVipTimeValueData.VipSeconds);
                        break;
                    default:
                        //TODO: Throw error
                        change = null;
                        break;

                }

                if (change != null)
                {
                    _diContainer.Inject(change); 
                    list.Add(change);
                }
            }

            return list;
        }
    }
}