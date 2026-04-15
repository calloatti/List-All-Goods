using HarmonyLib;
using Timberborn.ModManagerScene;
using UnityEngine;

namespace Calloatti.ListAllGoods
{
  public class ModStarter : IModStarter
  {

    public void StartMod(IModEnvironment modEnvironment)
    {

      // This line finds all [HarmonyPatch] attributes in your project and runs them
      new Harmony("Calloatti.ListAllGoods").PatchAll();

      // This confirms the mod actually loaded in the Player.log
      Debug.Log("[ListAllGoods] Harmony Patches Applied.");
    }
  }
}