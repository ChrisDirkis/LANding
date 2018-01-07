using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

using Vilkas.GameState;

namespace Vilkas.Tests {
    public class StageTests {
        #region strings
        private string ZeroWidthStage =
@"


";
        private string UnevenWidthStage =
@"###
####";

        private string InvalidCharStage =
@"###
#?#";

        private string BasicSuccessfulStage =
@"#####
#1 2#
#   #
#3 4#
#####";
        #endregion

        [Test]
        public void StageStringIsNotNullOrEmpty() {
            Assert.Throws<ArgumentNullException>(() => new Stage(""));
            Assert.Throws<ArgumentNullException>(() => new Stage(null));
        }

        [Test]
        public void StageHasValidWidth() {
            Assert.Throws<InvalidStageException>(() => new Stage(ZeroWidthStage));
            Assert.Throws<InvalidStageException>(() => new Stage(UnevenWidthStage));
        }

        [Test]
        public void StageDoesNotContainInvalidChars() {
            Assert.Throws<InvalidStageException>(() => new Stage(InvalidCharStage));
        }
        [Test]
        public void ValidStageLoad() {
            var validStage = new Stage(BasicSuccessfulStage);
            // TODO test valid stage contents
        }


    }
}