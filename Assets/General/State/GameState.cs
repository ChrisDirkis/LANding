using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vilkas.GameState {
    [Serializable]
    public class GameState {

        public float GameTime { get; set; }

        public List<Character> Characters { get; } = new List<Character>();
        public List<GameEffect> Effects { get; set; } = new List<GameEffect>();
        public Stage Stage { get; internal set; }
    }
}