using System.Collections.Generic;
using CannotReproduce.Domain.Entities;
using UnityEngine;

namespace CannotReproduce.Domain.UseCases
{
    public class SpawnCardUseCase
    {
        private readonly List<CardData> _cardTemplates = new List<CardData>();

        public SpawnCardUseCase()
        {
            // MVP用のカードテンプレートをいくつか用意する
            // 重要人物カード
            _cardTemplates.Add(new CardData { SenderName = "田中 実", Role = "部長", Organization = "第1開発部", Contact = "tanaka.makoto@example.com", Urgency = Urgency.HIGH, Subject = "[至急] ログインできない", Body = "至急対応お願いします。" });
            _cardTemplates.Add(new CardData { SenderName = "鈴木 一郎", Role = "顧客PM", Organization = "御曹司ホールディングス", Contact = "suzuki.ichiro@keyclient.co", Urgency = Urgency.MAX, Subject = "本番環境でのデータ不整合", Body = "ユーザー影響大。即時調査を。" });
            _cardTemplates.Add(new CardData { SenderName = "高嶺 愛花", Role = "デザイナー", Organization = "デザイン部", Contact = "takane.manaka@example.com", Urgency = Urgency.LOW, Subject = "ボタンの色について", Body = "少しだけ相談いいですか？" });

            // 通常カード
            _cardTemplates.Add(new CardData { SenderName = "佐藤 次郎", Role = "エンジニア", Organization = "第2開発部", Contact = "sato.jiro@example.com", Urgency = Urgency.MID, Subject = "開発環境のDBエラー", Body = "たまに発生します。" });
            _cardTemplates.Add(new CardData { SenderName = "山本 三郎", Role = "QA", Organization = "品質保証部", Contact = "yamamoto.saburo@example.com", Urgency = Urgency.LOW, Subject = "軽微な文言修正", Body = "お時間あるときで大丈夫です。" });
            _cardTemplates.Add(new CardData { SenderName = "中村 四郎", Role = "アシスタント", Organization = "営業部", Contact = "nakamura.shiro@example.com", Urgency = Urgency.LOW, Subject = "資料の場所が分かりません", Body = "教えてください。" });
        }

        public CardData Execute()
        {
            int index = Random.Range(0, _cardTemplates.Count);
            return _cardTemplates[index];
        }
    }
}
