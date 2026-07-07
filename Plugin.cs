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
    public const string PluginVersion = "1.0.0";

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
            "scrip" => 99999,
            "romphus" => 9999,
            "gussula" => 9999,
            "beezia" => 9999,
            "yeucon" => 9999,
            "saxonite" => 9999,
            "strange_comp" => 9999,
            "scrap_standard" => 999,
            "scrap_rare" => 999,
            "scrap_epic" => 999,
            "scrap_exotic" => 999,
            "oyster" => 9999,
            "pa_token" => 99,
            "equip_loot" => 99,
            "r_replicator" => 99,
            "dur_drops" => 99,
            "antimass" => 9999,
            _ => __result
        };
    }
}