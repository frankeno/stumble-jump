using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEditor;
using System.Net;
using System.Text; 
using System.IO; 

public class Lang : MonoBehaviour {

    //-------------------------------------------
    // MARK - GAME NAME
    //-------------------------------------------
    public static String gameNameStr() { return "Stumble Jump"; }


    public static String playStr() {
        String str = "Play";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Gioca";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "jouer";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "spielen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "jugar";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "遊ぶ";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "играть";
        }
        return str;
    }

    public static String bestStr() {
        String str = "best: ";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "best: ";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "meilleure: ";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "beste: ";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "La mejor: ";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "ベスト： ";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "лучший: ";
        }
        return str;
    }

    public static String distanceStr() {
        String str = "current distance: ";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "distanza attuale: ";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "distance actuelle: ";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "aktuelle Entfernung: ";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "distancia actual: ";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "現在の距離: ";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "текущее расстояние: ";
        }
        return str;
    }

    public static String inUseStr() {
        String str = "in use";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "in uso";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "en usage";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "in Benutzung";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "en uso";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "使用中で";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "в использовании";
        }
        return str;
    }

    public static String feedbackStr() {
        String str = "feedback";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "feedback";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "feedback";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Rückkoppelung";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "feedback";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "フィードバック";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "обратная связь";
        }
        return str;
    }

    public static String supportStr() {
        String str = "and support the developer";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "e supporta lo sviluppatore";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "et soutenir le développeur";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "und den Entwickler unterstützen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "y apoyar al desarrollador";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "そして開発者をサポート";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "и поддержите разработчика";
        }
        return str;
    }


    public static String gameOverStr() {
        String str = "game over";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "game over";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "jeu terminé";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Spiel ist aus";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "juego terminado";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "ゲームオーバー";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "игра закончена";
        }
        return str;
    }

    public static String wantToBuyStr() {
        String str = "do you want to buy this character?";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "vuoi acquistare questo personaggio?";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Voulez-vous acheter ce personnage?";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Möchtest du diesen Charakter kaufen?";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "¿Quieres comprar este personaje?";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "このキャラクターを購入しますか？";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "вы хотите купить этого персонажа?";
        }
        return str;
    }

    public static String continueStr() {
        String str = "want to continue?";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "vuoi continuare?";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "voulez-vous continuer?";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "möchtest du fortfahren?";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "¿Quieres continuar?";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "続けたいですか？";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "хотите продолжить?";
        }
        return str;
    }

    public static String noEnoughCoinsStr() {
        String str = "you don't have enough coins to buy this character";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "non hai abbastanza monete per acquistare questo personaggio";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "vous n'avez pas assez de pièces pour acheter ce personnage";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Sie haben nicht genug Münzen, um diesen Charakter zu kaufen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "no tienes suficientes monedas para comprar este personaje";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "このキャラクターを購入するのに十分なコインがありません";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "у вас недостаточно монет для покупки этого персонажа";
        }
        return str;
    }

    public static String noEnoughCoinsStr2() {
        String str = "you don't have enough coins to continue";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "non hai abbastanza monete per continuare";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "vous n'avez pas assez de pièces pour continuer";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Sie haben nicht genug Münzen, um fortzufahren";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "no tienes suficientes monedas para continuar";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "続行するのに十分なコインがありません";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "у вас недостаточно монет для продолжения";
        }
        return str;
    }

    public static String buyStr() {
        String str = "buy";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "acquista";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "achat";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Kaufen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "comprar";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "購入";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "купить";
        }
        return str;
    }

    public static String exitStr() {
        String str = "exit";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "esci";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "quitter";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "verlassen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "dejar";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "出る";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "выйти";
        }
        return str;
    }

    public static String pausedStr() {
        String str = "game paused";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "gioco in pausa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "jeu en pause";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Spiel pausiert";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "juego pausado";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "ゲームは一時停止しました";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "игра приостановлена";
        }
        return str;
    }

    public static String resumeStr() {
        String str = "resume";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "riprendi";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "continuer";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "fortsetzen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "reanudar";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "履歴書";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "продолжить";
        }
        return str;
    }

    // Purchase button
    public static String purchaseStr() {
        String str = "Remove Ads";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Rimuovi Pubblicita'";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Supprimez la pub";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Anzeigen entfernen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Quitar anuncios";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "広告を削除";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Удалить объявления";
        }
        return str;
    }


    // Restore Purchase button
    public static String restorePurchaseStr() {
        String str = "";
        if(Application.systemLanguage == SystemLanguage.English) {
            str = "Restore Purchase";
        } else if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Ripristina acquisto";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Restaurer l'achat";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Kauf wiederherstellen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Restaurar compra";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "購入商品を復元する";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Восстановить покупку";
        
        } else { str = "Restore Purchase"; }
        return str;
    }


    // More Games
    public static String moreGamesStr() {
        String str = "More games";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Altri giochi";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "D'autres jeux";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Andere Spiele";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Otros juegos";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "他のゲーム";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Другие игры";
        }
        return str;
    }

    // Cancel
    public static String cancelStr() {
        String str = "";
        if(Application.systemLanguage == SystemLanguage.English) {
            str = "Cancel";
        } else if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Annulla";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Annuler";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Abbrechen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Anular";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "キャンセル";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Аннулировать";
        
        } else { str = "Cancel"; }
        return str;
    }


    // Rate title 
    public static String rateTitleStr() {
        String str = "Are you having fun?";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Ti stai divertendo?";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Est-ce que tu t'amuses?";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Hast du Spaß?";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "¿Te estás divirtiendo?";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "楽しんでますか？";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Вам весело?";
        }
        return str;
    }


    // Rate message 
    public static String rateMessageStr() {
        String str = "Please leave us a feedback, we will appreciate your support. Thank you!";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Lasciaci un feedback, il tuo supporto sarà enormemente apprezzato. Grazie!";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Veuillez nous laisser un commentaire, nous apprécierons votre soutien. Merci!";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Bitte lassen Sie uns ein Feedback, werden wir Ihre Unterstützung zu schätzen wissen. Vielen Dank!";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Por favor, háganos una retroalimentación, apreciaremos su apoyo. ¡Gracias!";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "フィードバックをお寄せください。ご支援をよろしくお願いいたします。 ありがとうございました！";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Пожалуйста, оставьте нам отзыв, мы будем признательны за вашу поддержку. Спасибо!";
        }
        return str;
    }


    /// Rate button 
    public static String rateButtonStr() {
        String str = "Rate now";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Vota ora";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Évaluez maintenant!";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Jetzt bewerten!";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Valorar ahora!";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "今すぐ評価します";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Оценить сейчас";
        }
        return str;
    }

    public static String maybeLaterStr() {
        String str = "Maybe later";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Forse dopo";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Plus tard";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Später vielleicht";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Quizas mas tarde";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "多分後で";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Может позже";
        }
        return str;
    }

    public static String shareAchTitleStr() {
        String str = "New Challenge completed on Stumble Jump!";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Nuova sfida completata a Stumble Jump!";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Nouveau défi terminé sur Stumble Jump!";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Neue Herausforderung bei Stumble Jump abgeschlossen!";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "¡Nuevo desafío completado el Stumble Jump!";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "Stumble ump で新しいチャレンジが完了しました!";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Новое испытание завершено Stumble Jump!";
        }
        return str;
    }
    public static String shareAchMessageStr() {
        String str = "Look what achievement I've reached on Stumble Jump:\n";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "Guarda che traguardo ho raggiunto su Stumble Jump:\n";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Regardez quel succès j'ai atteint sur Stumble Jump:\n";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Sieh dir an, welche Errungenschaft ich bei Stumble Jump erreicht habe:\n";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Mira qué logro he alcanzado en Stumble Jump:\n";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "Stumble Jump で達成した成果を見てください:\n";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "Посмотрите, какого достижения я достиг в прыжках спотыкаясь:\n";
        }
        return str;
    }


    //-------------------------------------------
    // MARK - CHALLENGES TEXT
    //-------------------------------------------
    public static String chTitleStr() {
        String str = "challenges";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "sfide";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "défis";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Herausforderungen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "desafíos";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "チャレンジ";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "бросает вызов";
        }
        return str;
    }

    public static String chSubtitleStr() {
        String str = "complete them all!";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "completale tutte!";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "complétez-les tous!";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "vervollständige sie alle!";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "¡Complétalos todos!";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "それらをすべて完了してください！";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "завершить их все!";
        }
        return str;
    }

    public static String cTxt0() {
        String str = "young runner\n\nmake your first 10 meters";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "giovane corridore\n\nfai i tuoi primi 10 metri";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "jeune coureur\n\nfaites vos 10 premiers mètres";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "junger Läufer\n\nMachen Sie Ihre ersten 10 Meter";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "joven corredor\n\nhaz tus primeros 10 metros";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "若いランナー\n\n最初の10メートルを作る";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "молодой бегун\n\nсделать свои первые 10 метров";
        }
        return str;
    }

    public static String cTxt1() {
        String str = "nice dude\n\nreach 200 meters in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "bel tipo\n\nraggiungi 200 metri in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "gentil mec\n\natteindre 200 mètres en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "netter Typ\n\n200 Meter in einem einzigen Lauf erreichen";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "lindo amigo\n\nllegar a 200 metros en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "ナイスガイ\n\n1回の走行で200メートルに達する";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "хороший чувак\n\nдостичь 200 метров в одном забеге";
        }
        return str;
    }

    public static String cTxt2() {
        String str = "your first 50\n\ncollect 50 coins in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "le tue prime 50 monete\n\naccogli 50 monete in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "vos 50 premiers\n\ncollecter 50 pièces en une seule manche";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "deine ersten 50\n\nSammle 50 Münzen in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "tus primeros 50\n\nrecoger 50 monedas en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "最初の 50\n\n1 回の実行で 50 コインを集める";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "твои первые 50\n\nсобрать 50 монет за один проход";
        }
        return str;
    }

    public static String cTxt3() {
        String str = "young jumper\n\njump 50 times in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "giovane saltatore\n\nsalta 50 volte in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "jeune sauteur\n\nsauter 50 fois en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "junger Springer\n\nSpringe 50 Mal in einem einzigen Durchgang";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "saltador joven\n\nsalta 50 veces en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "若いジャンパー\n\n1回のランで50回ジャンプする";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "молодой прыгун\n\nпрыгнуть 50 раз за один раз";
        }
        return str;
    }

    public static String cTxt4() {
        String str = "strong runner\n\nreach 500 meters in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "forte corridore\n\nraggiungi 500 metri in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "coureur puissant\n\natteindre 500 mètres en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "starker Läufer\n\nErreiche 500 Meter in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "corredor fuerte\n\nllegar a 500 metros en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "強いランナー\n\n1 回の走行で 500 メートルに達する";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "сильный бегун\n\nдостичь 500 метров в одном забеге";
        }
        return str;
    }

    public static String cTxt5() {
        String str = "almost rich\n\ncollect 200 coins in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "quasi ricco\n\ncolleziona 200 monete in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "presque riche\n\ncollecter 200 pièces en une seule manche";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "fast reich\n\nSammle 200 Münzen in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "casi rico\n\nrecoger 200 monedas en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "ほぼ金持ち\n\n1 回の実行で 200 コインを集める";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "почти богатый\n\nсобрать 200 монет за один проход";
        }
        return str;
    }

    public static String cTxt6() {
        String str = "furious sharer\n\nshare one achievement on social media";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "condivisore furioso\n\ncondividi un risultato sui social media";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "heureux partage\n\npartager une réalisation sur les réseaux sociaux";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "fröhliches Teilen\n\nTeilen Sie einen Erfolg in den sozialen Medien";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "feliz compartiendo\n\ncompartir un logro en las redes sociales";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "幸せな分かち合い\n\nソーシャル メディアで 1 つの成果を共有する";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "счастливый обмен\n\nподелиться одним достижением в социальных сетях";
        }
        return str;
    }

    public static String cTxt7() {
        String str = "furious runner\n\nreach 1000 meters in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "corridore furioso\n\nraggiungi 1000 metri in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "coureur furieux\n\natteindre 1000 mètres en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "wütender Läufer\n\nErreiche 1000 Meter in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "corredor furioso\n\nllegar a 1000 metros en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "猛烈なランナー\n\n1 回の走行で 1000 メートルに達する";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "яростный бегун\n\nдостичь 1000 метров в одном забеге";
        }
        return str;
    }

    public static String cTxt8() {
        String str = "rich dude\n\ncollect 500 coins in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "tizio ricco\n\ncolleziona 500 monete in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "mec riche\n\ncollecter 500 pièces en une seule manche";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "reicher Kerl\n\nSammle 500 Münzen in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "tipo rico\n\nrecoger 500 monedas en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "金持ち\n\n1 回の実行で 500 コインを集める";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "богатый чувак\n\nсобрать 500 монет за один проход";
        }
        return str;
    }

    public static String cTxt9() {
        String str = "dizzy jumper\n\njump 500 times in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "saltatore vertiginoso\n\nsalta 500 volte in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "sauteur étourdi\n\nsauter 500 fois en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Schwindeliger Pullover\n\nSpringe 500 Mal in einem einzigen Durchgang";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "saltador mareado\n\nsalta 500 veces en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "めまいジャンパー\n\n1回のランで500回ジャンプする";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "головокружительный джемпер\n\nпрыгнуть 500 раз за один раз";
        }
        return str;
    }

    public static String cTxt10() {
        String str = "rockfeller\n\ncollect 1000 coins in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "rockfeller\n\nraccogli 1000 monete in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "Rockefeller\n\ncollecte 1000 pièces en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "Rockefeller\n\nsammelt 1000 Münzen in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "Rockefeller\n\nrecolecta 1000 monedas en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "ロックフェラーは1つのランで1000枚のコインを集めます";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "rockfeller\n\nсобирает 1000 монет за один заезд";
        }
        return str;
    }

    public static String cTxt11() {
        String str = "furious jumper\n\njump 1000 times in a single run";
        if(Application.systemLanguage == SystemLanguage.Italian) {
            str = "saltatore furioso\n\nsalta 1000 volte in una singola corsa";
        } else if(Application.systemLanguage == SystemLanguage.French) {
            str = "pull furieux\n\nsauter 1000 fois en une seule course";
        } else if(Application.systemLanguage == SystemLanguage.German) {
            str = "wütender Springer\n\nSpringe 1000 Mal in einem einzigen Lauf";
        } else if(Application.systemLanguage == SystemLanguage.Spanish) {
            str = "saltador furioso\n\nsaltar 1000 veces en una sola carrera";
        } else if(Application.systemLanguage == SystemLanguage.Japanese) {
            str = "猛烈なジャンパー\n\n1回のランで1000回ジャンプする";
        } else if(Application.systemLanguage == SystemLanguage.Russian) {
            str = "яростный прыгун\n\nпрыгнуть 1000 раз за один раз";
        }
        return str;
    }


} //./ end
