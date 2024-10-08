﻿using VRage.ObjectBuilders;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRageMath;

namespace AILogisticsAutomation
{
    public class AIInventoryManagerCargoDefinition
    {

        public long EntityId { get; set; }
        public Vector3I Position { get; set; }
        public HashSet<MyDefinitionId> ValidIds { get; set; } = new HashSet<MyDefinitionId>();
        public HashSet<MyObjectBuilderType> ValidTypes { get; set; } = new HashSet<MyObjectBuilderType>();
        public HashSet<MyDefinitionId> IgnoreIds { get; set; } = new HashSet<MyDefinitionId>();
        public HashSet<MyObjectBuilderType> IgnoreTypes { get; set; } = new HashSet<MyObjectBuilderType>();

        public AIInventoryManagerCargoDefinitionData GetData()
        {
            var data = new AIInventoryManagerCargoDefinitionData()
            {
                entityId = EntityId,
                position = Position
            };
            data.validIds = ValidIds.Select(x => new DocumentedDefinitionId(x)).ToArray();
            data.validTypes = ValidTypes.Select(x => x.ToString()).ToArray();
            data.ignoreIds = IgnoreIds.Select(x => new DocumentedDefinitionId(x)).ToArray();
            data.ignoreTypes = IgnoreTypes.Select(x => x.ToString()).ToArray();
            return data;
        }

        public bool UpdateData(string key, string action, string value)
        {
            MyDefinitionId valueAsId;
            MyObjectBuilderType valueAsType;
            switch (key.ToUpper())
            {
                case "VALIDIDS":
                    if (MyDefinitionId.TryParse(value, out valueAsId))
                    {
                        switch (action)
                        {
                            case "ADD":
                                ValidIds.Add(valueAsId);
                                return true;
                            case "DEL":
                                ValidIds.Remove(valueAsId);
                                return true;
                        }
                    }
                    break;
                case "VALIDTYPES":
                    if (MyObjectBuilderType.TryParse(value, out valueAsType))
                    {
                        switch (action)
                        {
                            case "ADD":
                                ValidTypes.Add(valueAsType);
                                return true;
                            case "DEL":
                                ValidTypes.Remove(valueAsType);
                                return true;
                        }
                    }
                    break;
                case "IGNOREIDS":
                    if (MyDefinitionId.TryParse(value, out valueAsId))
                    {
                        switch (action)
                        {
                            case "ADD":
                                IgnoreIds.Add(valueAsId);
                                return true;
                            case "DEL":
                                IgnoreIds.Remove(valueAsId);
                                return true;
                        }
                    }
                    break;
                case "IGNORETYPES":
                    if (MyObjectBuilderType.TryParse(value, out valueAsType))
                    {
                        switch (action)
                        {
                            case "ADD":
                                IgnoreTypes.Add(valueAsType);
                                return true;
                            case "DEL":
                                IgnoreTypes.Remove(valueAsType);
                                return true;
                        }
                    }
                    break;
            }
            return false;
        }

        public void UpdateData(AIInventoryManagerCargoDefinitionData data)
        {
            Position = data.position;
            ValidIds.Clear();
            foreach (var item in data.validIds)
            {
                var id = item.GetId();
                if (id.HasValue)
                {
                    ValidIds.Add(id.Value);
                }
            }
            ValidTypes.Clear();
            foreach (var item in data.validTypes)
            {
                MyObjectBuilderType type;
                if (MyObjectBuilderType.TryParse(item, out type))
                    ValidTypes.Add(type);
            }
            IgnoreIds.Clear();
            foreach (var item in data.ignoreIds)
            {
                var id = item.GetId();
                if (id.HasValue)
                {
                    IgnoreIds.Add(id.Value);
                }
            }
            IgnoreTypes.Clear();
            foreach (var item in data.ignoreTypes)
            {
                MyObjectBuilderType type;
                if (MyObjectBuilderType.TryParse(item, out type))
                    IgnoreTypes.Add(type);
            }
        }

    }

}