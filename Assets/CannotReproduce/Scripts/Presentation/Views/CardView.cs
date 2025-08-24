using UnityEngine;
using TMPro;
using CannotReproduce.Domain.Entities;

namespace CannotReproduce.Presentation.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _senderNameText;
        [SerializeField] private TextMeshProUGUI _roleText;
        [SerializeField] private TextMeshProUGUI _organizationText;
        [SerializeField] private TextMeshProUGUI _subjectText;
        [SerializeField] private TextMeshProUGUI _bodyText;
        // Urgencyはアイコンなどで表現する想定だが、一旦テキストで表示
        [SerializeField] private TextMeshProUGUI _urgencyText;

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
    }
}
