using System.Threading.Tasks;

namespace GameApi.AlgoritmService
{
    public interface IAlgorithmService
    {
        Task<int[]> GetSquare(char[,] board);
    }
}