using BepInEx;
using BepInEx.Configuration;
using EpicLoot;
using EpicLoot_UnityLib;
using HarmonyLib;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace EpicLootLeslieAlphaTest.src
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency("randyknapp.mods.epicloot")]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class EpicLootAlphaTestPlugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.leslie.epiclootlesliealphatest";
        public const string PluginName = "EpicLootLeslieAlphaTest";
        public const string PluginVersion = "0.1.0";

        // Config entries
        // private ConfigEntry<string> _exampleConfig;

        private void Awake()
        {
            // Server-synced config (admin only — pushed to all clients)
            // _exampleConfig = Config.Bind("Server config", "ExampleSetting", "default",
            //     new ConfigDescription("Description here", null,
            //     new ConfigurationManagerAttributes { IsAdminOnly = true }));

            // Client-only config (each player sets their own)
            // Config.Bind("Client config", "LocalSetting", true,
            //     new ConfigDescription("Client side setting"));

            // Listen for config sync events
            SynchronizationManager.OnConfigurationSynchronized += (obj, attr) =>
            {
                if (attr.InitialSynchronization)
                    Logger.LogInfo("Initial config sync received");
                else
                    Logger.LogInfo("Config sync event received");
            };

            // Listen for admin status changes
            SynchronizationManager.OnAdminStatusChanged += () =>
            {
                Logger.LogInfo($"Admin status changed: {SynchronizationManager.Instance.PlayerIsAdmin}");
            };

            // uncomment to add M.E through api
            MagicEffects.Init();
            EpicLootAPI.EpicLoot.RegisterAll(); // fuckin really

            new Harmony(PluginGUID).PatchAll();

            Logger.LogInfo($"{PluginName} v{PluginVersion} loaded");
        }
    }
}
