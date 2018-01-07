using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections.Specialized;

namespace Vilkas.GameState {
    public class GameStateManager : MonoBehaviour {

        public List<GameState> States { get; } = new List<GameState>();
        private List<Character> Characters { get; } = new List<Character>();
        private Stage Stage { get; set; }


        public void OnEnable() {
            // Initialize the game
            var state = new GameState();
            foreach (var character in Characters) {
                state.Characters.Add(character);
            }
            state.Stage = Stage;
        }

        public void AddCharacter([NotNull] Character character) {
            Characters.Add(character);
        }

        public void SetStage([NotNull] Stage stage) {
            Stage = stage;
        }
    }
}