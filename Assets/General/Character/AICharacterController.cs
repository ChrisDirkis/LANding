using System;

namespace Vilkas.GameState {
    public class AICharacterController : CharacterController {
        private Type type;

        public AICharacterController(Type type) {
            this.type = type;
        }
    }
}