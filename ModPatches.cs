using HarmonyLib;
using Timberborn.CoreUI;
using Timberborn.Modding;
using Timberborn.TopBarSystem;
using UnityEngine.UIElements;

namespace AlwaysShowGoods
{

    [HarmonyPatch(typeof(TopBarCounterRow), nameof(TopBarCounterRow.UpdateAndGetStock))]
    public static class TopBarCounterRow_UpdateAndGetStock_Patch
    {
        // Harmony treats 'out' parameters as 'ref' parameters in patches.
        // We use '____root' (4 underscores) to access the private readonly '_root' field.
        public static void Postfix(ref bool isVisible, VisualElement ____root)
        {
            // Force the row to register as visible to the parent ExtendableTopBarCounter
            isVisible = true;
            
            // Force the UI element to display
            ____root.ToggleDisplayStyle(true);
        }
    }
}