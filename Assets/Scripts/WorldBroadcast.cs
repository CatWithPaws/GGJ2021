﻿using UnityEngine;


    public static class WorldBroadcast
    {
        public static readonly GameEvent<GameObject> SomethingHappened = new GameEvent<GameObject>();

        public static readonly GameEvent<MaskType> MaskChanged = new GameEvent<MaskType>();
        public static readonly GameEvent<Sprite> ItemCollected = new GameEvent<Sprite>();
        public static readonly GameEvent<Sprite> CollectionGameEnded = new GameEvent<Sprite>();
    }

