﻿using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Game;
using Sandbox.Common.ObjectBuilders;
using VRage.Game.ModAPI;

namespace AILogisticsAutomation
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OreDetector), false, "AIAssemblerController", "AIAssemblerControllerReskin")]
    public class AIAssemblerControllerBlock : BaseAIBlock<IMyOreDetector, AIAssemblerControllerSettings, AIAssemblerControllerSettingsData>
    {

        protected override bool GetHadWorkToDo()
        {
            return false; // TODO
        }

        protected override bool GetIsValidToWork()
        {
            return CountAIAssemblerController(Grid) == 1;
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            Settings = new AIAssemblerControllerSettings();
            base.OnInit(objectBuilder);
            NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME;
        }

        protected int CountAIAssemblerController(IMyCubeGrid grid)
        {
            var count = 0;
            var validSubTypes = new string[] { "AIAssemblerController", "AIAssemblerControllerReskin" };
            foreach (var item in validSubTypes)
            {
                count += grid?.CountBlocks(new MyDefinitionId(typeof(MyObjectBuilder_OreDetector), item)) ?? 0;
            }
            return count;
        }

        protected override void DoExecuteCycle()
        {

        }

    }

}