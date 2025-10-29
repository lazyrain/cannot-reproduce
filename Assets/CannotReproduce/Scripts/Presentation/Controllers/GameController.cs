using UnityEngine;
using CannotReproduce.Domain.Entities;
using CannotReproduce.Domain.UseCases;
using CannotReproduce.Presentation.Views;

namespace CannotReproduce.Presentation.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private Transform _cardSpawnPoint;

        private SpawnCardUseCase _spawnCardUseCase;
        private InputSystem_Actions _input;
        private CardView _activeCardView;

        private void Awake()
        {
            _input = new InputSystem_Actions();
        }

        public void Initialize(SpawnCardUseCase spawnCardUseCase)
        {
            _spawnCardUseCase = spawnCardUseCase;
        }

        private void OnEnable()
        {
            _input.Gameplay.Enable();
        }

        private void OnDisable()
        {
            _input.Gameplay.Disable();
        }

        private void Start()
        {
            SpawnNewCard();
        }

        private void Update()
        {
            // カードがない、またはアニメーション中は入力を受け付けない
            if (_activeCardView == null) return;

            if (_input.Gameplay.SortLeft.WasPressedThisFrame())
            {
                HandleSort(false);
            }
            else if (_input.Gameplay.SortRight.WasPressedThisFrame())
            {
                HandleSort(true);
            }
        }

        private void HandleSort(bool isRight)
        {
            // アニメーションを開始し、終わったら次のカードを出す
            _activeCardView.StartSortAnimation(isRight, () => SpawnNewCard());
            // 連続で入力できないように、参照をnullにする
            _activeCardView = null;
        }

        private void SpawnNewCard()
        {
            CardData newCardData = _spawnCardUseCase.Execute();
            _activeCardView = Instantiate(_cardViewPrefab, _cardSpawnPoint);
            _activeCardView.SetCardData(newCardData);
        }

        private void OnDestroy()
        {
            _input.Dispose();
        }
    }
}
