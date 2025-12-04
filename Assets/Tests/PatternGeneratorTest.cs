using NUnit.Framework;

namespace AutoBattleCoop {
    public class PatternGeneratorTest {

        [Test]
        public void GeneratePatternMap_ForwardWithDistanceOne_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Forward, 1);
            // Assert
            bool[,] expected = new bool[,] {
            { true }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_ForwardWithDistanceThree_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Forward, 3);
            // Assert
            bool[,] expected = new bool[,] {
            { true },
            { true },
            { true }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_ManhattanWithDistanceOne_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Manhattan, 1);
            // Assert
            bool[,] expected = new bool[,] {
            { false, true, false },
            { true,  false, true  },
            { false, true, false }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_ManhattanWithDistanceTwo_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Manhattan, 2);
            // Assert
            bool[,] expected = new bool[,] {
            { false, false, true, false, false },
            { false, true, true, true, false },
            { true, true, false, true, true },
            { false, true, true, true, false },
            { false, false, true, false, false }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_CrossWithDistanceOne_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Cross, 1);
            // Assert
            bool[,] expected = new bool[,] {
            { false, true, false },
            { true,  false, true  },
            { false, true, false }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_CrossWithDistanceTwo_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Cross, 2);
            // Assert
            bool[,] expected = new bool[,] {
            { false, false, true, false, false },
            { false, false, true, false, false },
            { true,  true,  false, true,  true  },
            { false, false, true, false, false },
            { false, false, true, false, false }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_DiagonalsWithDistanceOne_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Diagonals, 1);
            // Assert
            bool[,] expected = new bool[,] {
            { true, false, true },
            { false, false, false },
            { true, false, true }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_DiagonalsWithDistanceTwo_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Diagonals, 2);
            // Assert
            bool[,] expected = new bool[,] {
            { true, false, false, false, true },
            { false, true, false, true, false },
            { false, false, false, false, false },
            { false, true, false, true, false },
            { true, false, false, false, true }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_StarWithDistanceOne_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Star, 1);
            // Assert
            bool[,] expected = new bool[,] {
            { true,  true,  true },
            { true,  false, true  },
            { true,  true,  true }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_StarWithDistanceTwo_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Star, 2);
            // Assert
            bool[,] expected = new bool[,] {
            { true,  false, true,  false, true  },
            { false, true,  true,  true,  false },
            { true,  true,  false, true,  true  },
            { false, true,  true,  true,  false },
            { true,  false, true,  false, true  }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_ConeWithDistanceOne_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Cone, 1);
            // Assert
            bool[,] expected = new bool[,] {
            { true }
        };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GeneratePatternMap_ConeWithDistanceThree_ReturnsProperPattern() {
            // Act
            bool[,] result = PatternGenerator.GeneratePatternMap(EAttackPattern.Cone, 3);
            // Assert
            bool[,] expected = new bool[,] {
            { false, false, true,  false, false },
            { false, true,  true,  true,  false },
            { true,  true,  true,  true,  true  }
        };
            Assert.AreEqual(expected, result);
        }

    }
}
