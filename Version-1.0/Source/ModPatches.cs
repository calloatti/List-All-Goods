using HarmonyLib;
using Timberborn.CoreUI;
using Timberborn.Modding;
using Timberborn.ResourceCountingSystem;
using Timberborn.ResourceCountingSystemUI;
using Timberborn.TopBarSystem;
using UnityEngine.UIElements;

namespace AlwaysShowGoods
{

  [HarmonyPatch(typeof(TopBarCounterRow), nameof(TopBarCounterRow.UpdateAndGetStock))]
  public static class TopBarCounterRow_UpdateAndGetStock_Patch
  {
    // Harmony treats 'out' parameters as 'ref' parameters in patches.
    // We use '____root' (4 underscores) to access the private readonly '_root' field.
    public static void Postfix(
        ref bool isVisible,
        VisualElement ____root,
        string ____goodId,
        ContextualResourceCountingService ____contextualResourceCountingService)
    {

      // If vanilla already set it to true, avoid running any further mod logic
      if (isVisible)
      {
        return;
      }

      bool onlyListGoodsWithStorage = Calloatti.ListAllGoods.ModStarter.Config.GetBool("OnlyListGoodsWithStorage");

      if (onlyListGoodsWithStorage)
      {
        ResourceCount contextualResourceCount = ____contextualResourceCountingService.GetContextualResourceCount(____goodId);

        // Direct access via publicized assembly
        if (contextualResourceCount.InputOutputCapacity > 0)
        {
          isVisible = true;
          ____root.ToggleDisplayStyle(true);
        }
      }
      else
      {
        // Force the row to register as visible to the parent ExtendableTopBarCounter
        isVisible = true;

        // Force the UI element to display
        ____root.ToggleDisplayStyle(true);
      }
    }
  }
}