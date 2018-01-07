using System.Runtime.Serialization;
using System;
using JetBrains.Annotations;
using System.Linq;
using System.Collections.Generic;

namespace Vilkas.GameState {

    [Serializable]
    public class Stage {

        public int Width { get; private set; }
        public int Height { get; private set; }

        private StageComponent[,] stage;
        public StageComponent this[int x, int y] {
            get {
                return stage[x, y];
            }
        }

        private static readonly Dictionary<char, StageComponent> stageComponents = new Dictionary<char, StageComponent> {
            {' ', new StageComponent() },   // Empty space
            {'#', new StageComponent() },   // Wall
            {'1', new StageComponent() },   // Spawn 1
            {'2', new StageComponent() },   // Spawn 2
            {'3', new StageComponent() },   // Spawn 3
            {'4', new StageComponent() },   // Spawn 4
        };

        public Stage([NotNull] string stageData) {
            if (string.IsNullOrEmpty(stageData)) {
                throw new ArgumentNullException("stageData");
            }

            foreach (var newline in new[] { "\r\n", "\n", "\r" }) {
                var lines = stageData.Split(new[] { newline }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length == 0) continue;

                // Now we're here, we've got the right newlines, at least. Now we're checking for file validity.

                var lineLength = lines[0].Length;

                if (lineLength == 0) continue;

                for (int i = 0; i < lines.Length; i++) { 
                    if (lines[i].Length != lineLength) {
                        throw new InvalidStageException($"Stage width not constant (error detected on line {i}).");
                    }
                }

                Width = lineLength;
                Height = lines.Length;
                stage = new StageComponent[Width, Height];

                for (int i = 0; i < Width; i++) {
                    for (int j = 0; j < Height; j++) {
                        try {
                            stage[i, j] = stageComponents[lines[j][i]];
                        } 
                        catch (KeyNotFoundException) {
                            throw new InvalidStageException($"Invalid character found at ({i}, {j}): {lines[j][i]}");
                        }
                    }
                }

                return;
            }

            throw new InvalidStageException("Stage file was invalid.");
        }
    }


    [Serializable]
    public class InvalidStageException : Exception {
        public InvalidStageException() { }
        public InvalidStageException(string message) : base(message) { }
        public InvalidStageException(string message, Exception inner) : base(message, inner) { }
        protected InvalidStageException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}