﻿using BepInEx;
using R2API.Utils;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace HellDiverMod
{
    [BepInDependency("com.DestroyedClone.AncientScepter", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.weliveinasociety.CustomEmotesAPI", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class HellDiverPlugin : BaseUnityPlugin
    {
        public static bool failFaster = false;
        public const string MODUID = "com.SuperEarthArmedForces.Helldiver";
        public const string MODNAME = "Helldiver";
        public const string MODVERSION = "0.0.0";

        public const string DEVELOPER_PREFIX = "LIBERTEA";

        public static HellDiverPlugin instance;
        
        void Start()
        {
            Modules.SoundBanks.Init();
        }
        
        void Awake()
        {
            instance = this;
            Log.Init(Logger);

            //GeneralConfig.Init();
            //GeneralCompat.Init();
            //GeneralStates.Init();
            //GeneralHooks.Init();

            Modules.Language.Init();

            new Survivors.HellDiver.HellDiverSurvivor().Initialize();

            Modules.ContentPacks contentPacks = new Modules.ContentPacks();
            contentPacks.Initialize();

            if (failFaster) {
                StartCoroutine(contentPacks.LoadCoroutine);
            }
        }
    }
}
