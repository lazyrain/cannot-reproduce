using CannotReproduce.Domain.Entities;

namespace CannotReproduce.Domain.UseCases
{
    public enum PlayerAction
    {
        Active, // 「Active（対応中）」
        WaitForReproduction // 「再現待ち完了」
    }

    public class JudgeCardUseCase
    {
        // MVPでは判定ロジックを簡略化・ハードコードする
        private bool IsImportant(CardData card)
        {
            // 例：役職に「部長」や「PM」が含まれているか、特定の組織名か
            if (card.Role.Contains("部長") || card.Role.Contains("PM"))
            {
                return true;
            }

            if (card.Organization.Contains("御曹司ホールディングス"))
            {
                return true;
            }

            // 例：特定の気になるあの人（名前で判定）
            if (card.SenderName == "高嶺 愛花")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// カードとプレイヤーのアクションを元に正解かどうかを判定する
        /// </summary>
        /// <param name="card">判定対象のカード</param>
        /// <param name="action">プレイヤーが選択したアクション</param>
        /// <returns>正解ならtrue</returns>
        public bool Execute(CardData card, PlayerAction action)
        { 
            bool shouldBeActive = IsImportant(card);

            if (shouldBeActive)
            {
                return action == PlayerAction.Active;
            }
            else
            {
                return action == PlayerAction.WaitForReproduction;
            }
        }
    }
}
