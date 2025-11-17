using HarmonyLib;
using BepInEx;
using BepInEx.Logging;

namespace ItemCapPlus;

[MycoMod(null, ModFlags.IsClientSide)]
[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    public const string PluginGUID = "hed14.itemcapplus";
    public const string PluginName = "ItemCapPlus";
    public const string PluginVersion = "0.1.0";

    internal new static ManualLogSource Logger;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {PluginGUID} is loaded!");

        var harmony = new Harmony(PluginGUID);
        harmony.PatchAll();
        Logger.LogInfo("Harmony patches applied.");
    }
}

[HarmonyPatch(typeof(PlayerResource), nameof(PlayerResource.Max), MethodType.Getter)]
public class PlayerResourceMaxPatch
{
    private static void Postfix(PlayerResource __instance, ref int __result)
    {
        __result = __instance.ID switch
        {
            "equip_loot" => 99,
            "pa_token" => 99,
            "dur_drops" => 99,
            "r_replicator" => 99,
            "scrap_standard" => 999,
            "scrap_rare" => 999,
            "scrap_epic" => 999,
            "scrap_exotic" => 999,
            _ => __result
        };
    }
}