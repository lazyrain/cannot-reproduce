using UnityEngine;
using CannotReproduce.Domain.Entities;
using CannotReproduce.Domain.UseCases;
using CannotReproduce.Presentation.Views;

namespace CannotReproduce.Presentation.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private Transform _cardSpawnPoint; // カードを生成する場所（Canvasの子を想定）

        private SpawnCardUseCase _spawnCardUseCase;

        private void Awake()
        {
            _spawnCardUseCase = new SpawnCardUseCase();
        }

        private void Start()
        {
            SpawnNewCard();
        }

        private void SpawnNewCard()
        {
            // 1. ドメイン層からカードデータを取得
            CardData newCardData = _spawnCardUseCase.Execute();

            // 2. プレハブからカードUIを生成
            CardView newCardView = Instantiate(_cardViewPrefab, _cardSpawnPoint);
            
            // 3. カードUIにデータを設定して表示
            newCardView.SetCardData(newCardData);
        }
    }
}
