﻿using System.Globalization;

namespace BaseLibS.Util {
	public class Loc : TwoLetterLanguageCode {
		protected Loc() { }
		private static CultureInfo cultureInfo;

		public static CultureInfo CultureInfo {
			get => cultureInfo ?? (cultureInfo = CultureInfo.CurrentCulture);
			set {
				twoLettName = null;
				cultureInfo = value;
			}
		}

		private static string twoLettName;

		protected static string TwoLettName {
			get {
				if (string.IsNullOrEmpty(twoLettName)) {
					twoLettName = CultureInfo.TwoLetterISOLanguageName;
				}
				return twoLettName;
			}
		}

		public static string Andromeda {
			get {
				switch (TwoLettName) {
					case arabic: return "أندروميدا";
					case bulgarian: return "Андромеда";
					case chinese: return "仙女星座";
					case czech: return "Andromeda";
					case danish: return "Andromeda";
					case dutch: return "Andromeda";
					case finnish: return "Andromeda";
					case french: return "Andromeda";
					case german: return "Andromeda";
					case greek: return "Ανδρομέδα";
					case hebrew: return "אנדרומדה";
					case hindi: return "एंड्रोमेडा";
					case italian: return "Andromeda";
					case japanese: return "アンドロメダ";
					case korean: return "안드로메다";
					case norwegian: return "Andromeda";
					case persian: return "آندرومدا";
					case polish: return "Andromeda";
					case portuguese: return "Andrômeda";
					case romanian: return "Andromeda";
					case russian: return "Андромеда";
					case spanish: return "Andrómeda";
					case swedish: return "Andromeda";
					case tamil: return "ஆந்த்ரோமெடா";
					case turkish: return "Andromeda";
					default: return "Andromeda";
				}
			}
		}

		public static string File {
			get {
				switch (TwoLettName) {
					case arabic: return "ملف&";
					case bulgarian: return "&досие";
					case chinese: return "&文件";
					case czech: return "&Soubor";
					case danish: return "&Fil";
					case dutch: return "&Dossier";
					case finnish: return "&Tiedosto";
					case french: return "&Fichier";
					case german: return "&Datei";
					case greek: return "&Αρχείο";
					case hebrew: return "קוֹבֶץ&";
					case hindi: return "&फ़ाइल";
					case italian: return "&File";
					case japanese: return "&ファイル";
					case korean: return "&파일";
					case norwegian: return "&Fil";
					case persian: return "پرونده&";
					case polish: return "&Plik";
					case portuguese: return "&Arquivo";
					case romanian: return "&Fişier";
					case russian: return "&файл";
					case spanish: return "&Archivo";
					case swedish: return "&Fil";
					case tamil: return "&கோப்பு";
					case turkish: return "&Dosya";
					default: return "&File";
				}
			}
		}

		public static string Help {
			get {
				switch (TwoLettName) {
					case arabic: return "مساعدة&";
					case bulgarian: return "&Помогне";
					case chinese: return "&帮帮我";
					case czech: return "&Pomoc";
					case danish: return "&Hjælp";
					case dutch: return "&Helpen";
					case finnish: return "&Auta";
					case french: return "&Aidez";
					case german: return "&Hilfe";
					case greek: return "&Βοήθεια";
					case hebrew: return "עֶזרָה&";
					case hindi: return "&मदद";
					case italian: return "&Aiuto";
					case japanese: return "&助けて";
					case korean: return "&도움";
					case norwegian: return "&Hjelp";
					case persian: return "کمک&";
					case polish: return "&Wsparcie";
					case portuguese: return "&Socorro";
					case romanian: return "&Ajutor";
					case russian: return "&Помогите";
					case spanish: return "&Ayuda";
					case swedish: return "&Hjälpa";
					case tamil: return "&உதவி";
					case turkish: return "&Yardım et";
					default: return "&Help";
				}
			}
		}

		public static string Item {
			get {
				switch (TwoLettName) {
					case arabic: return "بند";
					case bulgarian: return "вещ";
					case chinese: return "项目";
					case czech: return "položka";
					case danish: return "vare";
					case dutch: return "item";
					case finnish: return "erä";
					case french: return "article";
					case german: return "Artikel";
					case greek: return "είδος";
					case hebrew: return "פריט";
					case hindi: return "मद";
					case italian: return "articolo";
					case japanese: return "項目";
					case korean: return "목";
					case norwegian: return "punkt";
					case persian: return "آیتم";
					case polish: return "pozycja";
					case portuguese: return "item";
					case romanian: return "articol";
					case russian: return "пункт";
					case spanish: return "ít";
					case swedish: return "Artikel";
					case tamil: return "உருப்படியை";
					case turkish: return "madde";
					default: return "item";
				}
			}
		}

		public static string Items {
			get {
				switch (TwoLettName) {
					case arabic: return "العناصر";
					case bulgarian: return "елементи";
					case chinese: return "项目";
					case czech: return "Položek";
					case danish: return "elementer";
					case dutch: return "items";
					case finnish: return "kohdetta";
					case french: return "articles";
					case german: return "Artikel";
					case greek: return "Αντικειμένων";
					case hebrew: return "פריטים";
					case hindi: return "आइटम";
					case italian: return "elementi";
					case japanese: return "アイテム";
					case korean: return "항목";
					case norwegian: return "elementer";
					case persian: return "موارد";
					case polish: return "przedmiotów";
					case portuguese: return "Unid";
					case romanian: return "articole";
					case russian: return "Предметы";
					case spanish: return "artículos";
					case swedish: return "objekt";
					case tamil: return "பொருட்களை";
					case turkish: return "ürün";
					default: return "items";
				}
			}
		}

		public static string MaxQuant {
			get {
				switch (TwoLettName) {
					case hebrew: return "מקסימום";
					default: return "MaxQuant";
				}
			}
		}

		public static string Perseus {
			get {
				switch (TwoLettName) {
					case arabic: return "الغول";
					case bulgarian: return "Персей";
					case chinese: return "英仙座";
					case czech: return "Perseus";
					case danish: return "Perseus";
					case dutch: return "Perseus";
					case finnish: return "Perseus";
					case french: return "Perseus";
					case german: return "Perseus";
					case greek: return "Περσεύς";
					case hebrew: return "פרסאוס";
					case hindi: return "Perseus";
					case italian: return "Perseo";
					case japanese: return "ペルセウス";
					case korean: return "페르세우스";
					case norwegian: return "Perseus";
					case persian: return "پرسئوس";
					case polish: return "Perseusz";
					case portuguese: return "Perseu";
					case romanian: return "Perseu";
					case russian: return "Персей";
					case spanish: return "Perseo";
					case swedish: return "Perseus";
					case tamil: return "பெர்ஸியல்";
					case turkish: return "Perseus";
					default: return "Perseus";
				}
			}
		}

		public static string PleaseConfirm {
			get {
				switch (TwoLettName) {
					case arabic: return "...يرجى تأكيد";
					case bulgarian: return "Моля потвърди...";
					case chinese: return "请确认...";
					case czech: return "Prosím potvrďte...";
					case danish: return "Bekræft venligst...";
					case dutch: return "Bevestig alstublieft...";
					case finnish: return "Ole hyvä ja vahvista...";
					case french: return "Veuillez confirmer...";
					case german: return "Bitte bestätigen...";
					case greek: return "Παρακαλώ Επιβεβαιώστε...";
					case hebrew: return "...אנא אשר";
					case hindi: return "कृपया पुष्टि करें...";
					case italian: return "Si prega di confermare...";
					case japanese: return "確認してください...";
					case korean: return "확인해주세요...";
					case norwegian: return "Vennligst bekreft...";
					case persian: return "...لطفا تایید کنید";
					case polish: return "Proszę potwierdzić...";
					case portuguese: return "Por favor confirme...";
					case romanian: return "Vă rugăm să confirmați...";
					case russian: return "Пожалуйста подтвердите...";
					case spanish: return "Por favor confirmar...";
					case swedish: return "Var god bekräfta...";
					case tamil: return "தயவுசெய்து உறுதிப்படுத்தவும்...";
					case turkish: return "Lütfen onaylayın...";
					default: return "Please confirm...";
				}
			}
		}

		public static string Selected {
			get {
				switch (TwoLettName) {
					case arabic: return "المحدد";
					case bulgarian: return "подбран";
					case chinese: return "选";
					case czech: return "vybraný";
					case danish: return "valgte";
					case dutch: return "gekozen";
					case finnish: return "valittu";
					case french: return "choisi";
					case german: return "ausgewählt";
					case greek: return "Επιλεγμένο";
					case hebrew: return "נבחר";
					case hindi: return "चयनित";
					case italian: return "selezionato";
					case japanese: return "選択された";
					case korean: return "선택된";
					case norwegian: return "valgt";
					case persian: return "انتخاب شد";
					case polish: return "wybrany";
					case portuguese: return "selecionado";
					case romanian: return "selectat";
					case russian: return "выбранный";
					case spanish: return "seleccionado";
					case swedish: return "vald";
					case tamil: return "தேர்ந்தெடுக்கப்பட்டுள்ளன";
					case turkish: return "seçilmiş";
					default: return "selected";
				}
			}
		}

		public static string Session {
			get {
				switch (TwoLettName) {
					case arabic: return "جلسة";
					case bulgarian: return "сесия";
					case chinese: return "会议";
					case czech: return "zasedání";
					case danish: return "session";
					case dutch: return "sessie";
					case finnish: return "istunto";
					case french: return "session";
					case german: return "Sitzung";
					case greek: return "συνεδρία";
					case hebrew: return "מוֹשָׁב";
					case hindi: return "अधिवेशन";
					case italian: return "sessione";
					case japanese: return "セッション";
					case korean: return "세션";
					case norwegian: return "økt";
					case persian: return "جلسه";
					case polish: return "sesja";
					case portuguese: return "sessão";
					case romanian: return "sesiune";
					case russian: return "сессия";
					case spanish: return "sesión";
					case swedish: return "session";
					case tamil: return "அமர்வு";
					case turkish: return "oturum";
					default: return "session";
				}
			}
		}

		public static string Start {
			get {
				switch (TwoLettName) {
					case arabic: return "بداية";
					case bulgarian: return "начало";
					case chinese: return "开始";
					case czech: return "Start";
					case danish: return "Start";
					case dutch: return "Begin";
					case finnish: return "Alkaa";
					case french: return "Début";
					case german: return "Start";
					case greek: return "Αρχή";
					case hebrew: return "הַתחָלָה";
					case hindi: return "प्रारंभ";
					case italian: return "Inizio";
					case japanese: return "開始";
					case korean: return "스타트";
					case norwegian: return "Start";
					case persian: return "شروع کنید";
					case polish: return "Początek";
					case portuguese: return "Começar";
					case romanian: return "Start";
					case russian: return "Начало";
					case spanish: return "Comienzo";
					case swedish: return "Start";
					case tamil: return "தொடக்கம்";
					case turkish: return "Başlama";
					default: return "Start";
				}
			}
		}

		public static string Stop {
			get {
				switch (TwoLettName) {
					case arabic: return "توقف";
					case bulgarian: return "Спри се";
					case chinese: return "停止";
					case czech: return "Stop";
					case danish: return "Hold op";
					case dutch: return "Hou op";
					case finnish: return "Stop";
					case french: return "Arrêtez";
					case german: return "Stopp";
					case greek: return "Να σταματήσει";
					case hebrew: return "תפסיק";
					case hindi: return "रुकें";
					case italian: return "Stop";
					case japanese: return "やめる";
					case korean: return "중지";
					case norwegian: return "Stoppe";
					case persian: return "متوقف کردن";
					case polish: return "Zatrzymać";
					case portuguese: return "Pare";
					case romanian: return "Stop";
					case russian: return "Стоп";
					case spanish: return "Detener";
					case swedish: return "Sluta";
					case tamil: return "நிறுத்து";
					case turkish: return "Durdur";
					default: return "Stop";
				}
			}
		}

		public static string Version {
			get {
				switch (TwoLettName) {
					case arabic: return "الإصدار";
					case bulgarian: return "версия";
					case chinese: return "版";
					case czech: return "Verze";
					case danish: return "Version";
					case dutch: return "Versie";
					case finnish: return "Versio";
					case french: return "Version";
					case german: return "Version";
					case greek: return "Εκδοχή";
					case hebrew: return "גִרְסָה";
					case hindi: return "संस्करण";
					case italian: return "Versione";
					case japanese: return "バージョン";
					case korean: return "번역";
					case norwegian: return "Versjon";
					case persian: return "نسخه";
					case polish: return "Wersja";
					case portuguese: return "Versão";
					case romanian: return "Versiune";
					case russian: return "Версия";
					case spanish: return "Versión";
					case swedish: return "Version";
					case tamil: return "பதிப்பு";
					case turkish: return "Versiyon";
					default: return "Version";
				}
			}
		}
	}
}