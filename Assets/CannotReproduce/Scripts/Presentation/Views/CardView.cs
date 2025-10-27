using UnityEngine;
using TMPro;
using CannotReproduce.Domain.Entities;
using System.Collections;
using System;

namespace CannotReproduce.Presentation.Views
{
    [RequireComponent(typeof(RectTransform))]

    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _senderNameText;
        [SerializeField] private TextMeshProUGUI _roleText;
        [SerializeField] private TextMeshProUGUI _organizationText;
        [SerializeField] private TextMeshProUGUI _subjectText;
        [SerializeField] private TextMeshProUGUI _bodyText;
        [SerializeField] private TextMeshProUGUI _urgencyText;

        // アニメーション設定
        private const float SortAnimationDuration = 0.4f;
        private const float MoveDistance = 1200f;
        private const float RotationAngle = 30f;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetCardData(CardData cardData)
        {
            if (cardData == null) return;

            _senderNameText.text = cardData.SenderName;
            _roleText.text = cardData.Role;
            _organizationText.text = cardData.Organization;
            _subjectText.text = cardData.Subject;
            _bodyText.text = cardData.Body;
            _urgencyText.text = cardData.Urgency.ToString();
        }

        public void StartSortAnimation(bool swipeRight, Action onAnimationFinished)
        {
            StartCoroutine(SortAnimationCoroutine(swipeRight, onAnimationFinished));
        }

        private IEnumerator SortAnimationCoroutine(bool swipeRight, Action onAnimationFinished)
        {
            float elapsedTime = 0f;
            Vector2 startPosition = _rectTransform.anchoredPosition;
            Quaternion startRotation = _rectTransform.rotation;

            float direction = swipeRight ? 1f : -1f;
            Vector2 targetPosition = startPosition + new Vector2(MoveDistance * direction, 0);
            Quaternion targetRotation = Quaternion.Euler(0, 0, -RotationAngle * direction);

            while (elapsedTime < SortAnimationDuration)
            {
                float t = elapsedTime / SortAnimationDuration;
                // 少しイージングをかけて気持ち良い動きに
                t = 1 - Mathf.Pow(1 - t, 3);

                _rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
                _rectTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // アニメーション完了を通知
            onAnimationFinished?.Invoke();

            // 自身を破棄
            Destroy(gameObject);
        }
    }
}
