// Thanks to Zenya (https://steamcommunity.com/profiles/76561197980466749) for sharing the 'Profitable Tourism' source, which this mod extends from!

using System.Reflection;
using ColossalFramework.Plugins;
using UnityEngine;
using ICities;
// !! Do not perform code updates that depend on features from .NET 4 or higher (i.e expression body styles, null coalescing, etc.) !!

namespace CS_Profitable_Offices
{
    public class ProfitableOfficesMod : IUserMod
    {
        private string Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }
        public string Name
        {
            get
            {
                return "Profitable Offices Mod (version " + Version + ")";
            }
        }

        public string Description
        {
            get
            {
                return "Helps you earn more from office zones";
            }
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddDropdown(
                "Office Income Multiplier",
                ModOptions.OfficeIncomeMultipliersStr,
                ModOptions.Instance.GetOfficeIncomeMultiplierIndex(),
                OfficeIncomeMultiplierOnSelected
            );
        }

        private static void OfficeIncomeMultiplierOnSelected(int sel)
        {
            ModOptions.Instance.OfficeIncomeMultiplier = ModOptions.OfficeIncomeMultipliers[sel];
            ModOptions.Instance.Save();
        }
    }
}


