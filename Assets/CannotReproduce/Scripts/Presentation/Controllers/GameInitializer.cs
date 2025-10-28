using UnityEngine;
using CannotReproduce.Domain.UseCases;

namespace CannotReproduce.Presentation.Controllers
{
    public class GameInitializer : MonoBehaviour
    {
        private void Awake()
        {
            // 1. Domain層のUseCaseをインスタンス化
            var spawnCardUseCase = new SpawnCardUseCase();
            // 今後、他のUseCaseもここで生成する

            // 2. 依存性を注入する対象のControllerを検索
            var gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                // 3. 依存性を注入
                gameController.Initialize(spawnCardUseCase);
            }
            else
            {
                Debug.LogError("GameController not found in the scene.");
            }
        }
    }
}
