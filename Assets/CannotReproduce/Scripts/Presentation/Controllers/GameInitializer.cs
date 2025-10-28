using UnityEngine;
using CannotReproduce.Domain.UseCases;

namespace CannotReproduce.Presentation.Controllers
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField]
        private GameController _gameController;

        private void Awake()
        {
            // 1. Domain層のUseCaseをインスタンス化
            var spawnCardUseCase = new SpawnCardUseCase();
            // 今後、他のUseCaseもここで生成する

            // 2. 依存性を注入する対象のControllerを検索
            if (_gameController != null)
            {
                // 3. 依存性を注入
                _gameController.Initialize(spawnCardUseCase);
            }
            else
            {
                Debug.LogError("GameController not found in the scene.");
            }
        }
    }
}
