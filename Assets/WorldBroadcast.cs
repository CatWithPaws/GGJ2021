using UnityEngine;

namespace AndromedaCore.LevelManagement
{
    public static class WorldBroadcast
    {
        public static readonly GameEvent<GameObject> SomethingHappened = new GameEvent<GameObject>();

        public static readonly GameEvent<MaskType> MaskChanged = new GameEvent<MaskType>();
    }
}
