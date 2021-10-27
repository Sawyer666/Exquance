using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using GameApi;
using GameApi.AlgoritmService;
using GameApi.ValidateService;
using NUnit.Framework;

namespace GameApiTest
{
    public class MiniMaxTest
    {
        private IAlgorithmService _currentAlgorithm;
        
        [SetUp]
        public void Setup()
        {
            _currentAlgorithm = new MiniMaxService(new GameProcessValidate());
        }

        [Test]
        [TestCaseSource(typeof(MiniMaxTest), nameof(TestCases))]
        public async Task GetBestMove_ReturnSuccessValue(TestCaseData data)
        {
            //Assert
            var expectedMove = data.BestMove;

            //Act

            var bestMove = await _currentAlgorithm.GetSquare(data.CurrentBoard);

            //Assert
            Assert.AreEqual(bestMove, expectedMove);
        }

        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                    new char[,]
                    {
                        {'X', '0', 'X'},
                        {'_', '0', '_'},
                        {'_', '_', '_'}
                    },
                    new[] {2, 1});

                yield return new TestCaseData(
                    new char[,]
                    {
                        {'X', '0', 'X'},
                        {'0', 'X', '0'},
                        {'_', '_', '_'}
                    },
                    new[] {2, 0});
                
                yield return new TestCaseData(
                    new char[,]
                    {
                        {'0', '0', 'X'},
                        {'0', 'X', '_'},
                        {'_', '_', '_'}
                    },
                    new[] {2, 0});
                
                yield return new TestCaseData(
                    new char[,]
                    {
                        {'0', '0', 'X'},
                        {'0', '0', 'X'},
                        {'X', '_', '_'}
                    },
                    new[] {2, 2});
                
                yield return new TestCaseData(
                    new char[,]
                    {
                        {'0', '0', 'X'},
                        {'0', '_', 'X'},
                        {'_', '_', '_'}
                    },
                    new[] {2, 0});
       
            }
        }

        public class TestCaseData
        {
            public char[,] CurrentBoard { get; set; }
            public int[] BestMove { get; set; }

            public TestCaseData(char[,] currentBoard, int[] bestMove)
            {
                CurrentBoard = currentBoard;
                BestMove = bestMove;
            }
        }
    }
}