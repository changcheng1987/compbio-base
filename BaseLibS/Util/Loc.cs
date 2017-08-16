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
					case estonian: return "Andromeda";
					case finnish: return "Andromeda";
					case french: return "Andromeda";
					case german: return "Andromeda";
					case greek: return "Ανδρομέδα";
					case hebrew: return "אנדרומדה";
					case hindi: return "एंड्रोमेडा";
					case italian: return "Andromeda";
					case japanese: return "アンドロメダ";
					case korean: return "안드로메다";
					case latvian: return "Andromeda";
					case lithuanian: return "Andromeda";
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

		public static string DoYouReallyWantToExit {
			get {
				switch (TwoLettName) {
					case arabic: return "هل حقا تريد الخروج؟";
					case bulgarian: return "Наистина ли искате да излезете?";
					case chinese: return "你真的想退出吗？";
					case czech: return "Opravdu chcete opustit?";
					case danish: return "Vil du virkelig afslutte?";
					case dutch: return "Wil je echt verlaten?";
					case estonian: return "Kas sa tõesti tahad väljuda?";
					case finnish: return "Haluatko todella poistua?";
					case french: return "Voulez-vous vraiment sortir?";
					case german: return "Wollen Sie wirklich aussteigen?";
					case greek: return "Θέλετε πραγματικά να βγείτε;";
					case hebrew: return "האם אתה באמת רוצה לצאת?";
					case hindi: return "क्या आप वास्तव में बाहर निकलना चाहते हैं?";
					case italian: return "Vuoi veramente uscire?";
					case japanese: return "本当に退場したいですか？";
					case korean: return "정말로 나가고 싶니?";
					case latvian: return "Vai tiešām vēlaties iziet?";
					case lithuanian: return "Ar tikrai norite išeiti?";
					case norwegian: return "Vil du virkelig avslutte?";
					case persian: return "آیا واقعا می خواهید خروج کنید؟";
					case polish: return "Czy naprawdę chcesz wyjść?";
					case portuguese: return "Você realmente quer sair?";
					case romanian: return "Chiar vrei să ieși?";
					case russian: return "Вы действительно хотите выйти?";
					case spanish: return "¿Realmente quieres salir?";
					case swedish: return "Vill du verkligen avsluta?";
					case tamil: return "நீங்கள் உண்மையில் வெளியேற விரும்புகிறீர்களா?";
					case turkish: return "Gerçekten çıkmak istiyor musun?";
					default: return "Do you really want to exit?";
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
					case estonian: return "&Faili";
					case finnish: return "&Tiedosto";
					case french: return "&Fichier";
					case german: return "&Datei";
					case greek: return "&Αρχείο";
					case hebrew: return "קוֹבֶץ&";
					case hindi: return "&फ़ाइल";
					case italian: return "&File";
					case japanese: return "&ファイル";
					case korean: return "&파일";
					case latvian: return "&Fails";
					case lithuanian: return "&Failas";
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
					case estonian: return "&Abi";
					case finnish: return "&Auta";
					case french: return "&Aidez";
					case german: return "&Hilfe";
					case greek: return "&Βοήθεια";
					case hebrew: return "עֶזרָה&";
					case hindi: return "&मदद";
					case italian: return "&Aiuto";
					case japanese: return "&助けて";
					case korean: return "&도움";
					case latvian: return "&Palīdzība";
					case lithuanian: return "&Pagalba";
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
					case estonian: return "Kirje";
					case finnish: return "erä";
					case french: return "article";
					case german: return "Artikel";
					case greek: return "είδος";
					case hebrew: return "פריט";
					case hindi: return "मद";
					case italian: return "articolo";
					case japanese: return "項目";
					case korean: return "목";
					case latvian: return "Vienība";
					case lithuanian: return "Daiktas";
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
					case estonian: return "Esemed";
					case finnish: return "kohdetta";
					case french: return "articles";
					case german: return "Artikel";
					case greek: return "Αντικειμένων";
					case hebrew: return "פריטים";
					case hindi: return "आइटम";
					case italian: return "elementi";
					case japanese: return "アイテム";
					case korean: return "항목";
					case latvian: return "Priekšmetus";
					case lithuanian: return "Daiktai";
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
					case estonian: return "Perseus";
					case finnish: return "Perseus";
					case french: return "Perseus";
					case german: return "Perseus";
					case greek: return "Περσεύς";
					case hebrew: return "פרסאוס";
					case hindi: return "Perseus";
					case italian: return "Perseo";
					case japanese: return "ペルセウス";
					case korean: return "페르세우스";
					case latvian: return "Persejs";
					case lithuanian: return "Perseusas";
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
					case estonian: return "Palun kinnita";
					case finnish: return "Ole hyvä ja vahvista...";
					case french: return "Veuillez confirmer...";
					case german: return "Bitte bestätigen...";
					case greek: return "Παρακαλώ Επιβεβαιώστε...";
					case hebrew: return "...אנא אשר";
					case hindi: return "कृपया पुष्टि करें...";
					case italian: return "Si prega di confermare...";
					case japanese: return "確認してください...";
					case korean: return "확인해주세요...";
					case latvian: return "Lūdzu apstipriniet";
					case lithuanian: return "Prašome patvirtinti";
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
					case estonian: return "valitud";
					case finnish: return "valittu";
					case french: return "choisi";
					case german: return "ausgewählt";
					case greek: return "Επιλεγμένο";
					case hebrew: return "נבחר";
					case hindi: return "चयनित";
					case italian: return "selezionato";
					case japanese: return "選択された";
					case korean: return "선택된";
					case latvian: return "Izvēlēts";
					case lithuanian: return "pasirinkta";
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
					case estonian: return "seanss";
					case finnish: return "istunto";
					case french: return "session";
					case german: return "Sitzung";
					case greek: return "συνεδρία";
					case hebrew: return "מוֹשָׁב";
					case hindi: return "अधिवेशन";
					case italian: return "sessione";
					case japanese: return "セッション";
					case korean: return "세션";
					case latvian: return "sesija";
					case lithuanian: return "sesija";
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
					case estonian: return "Alusta";
					case finnish: return "Alkaa";
					case french: return "Début";
					case german: return "Start";
					case greek: return "Αρχή";
					case hebrew: return "הַתחָלָה";
					case hindi: return "प्रारंभ";
					case italian: return "Inizio";
					case japanese: return "開始";
					case korean: return "스타트";
					case latvian: return "Sākt";
					case lithuanian: return "Pradėti";
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
					case estonian: return "Peatus";
					case finnish: return "Stop";
					case french: return "Arrêtez";
					case german: return "Stopp";
					case greek: return "Να σταματήσει";
					case hebrew: return "תפסיק";
					case hindi: return "रुकें";
					case italian: return "Stop";
					case japanese: return "やめる";
					case korean: return "중지";
					case latvian: return "Apstāties";
					case lithuanian: return "Sustabdyti";
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

		public static string Tools {
			get {
				switch (TwoLettName) {
					case arabic: return "أدوات&";
					case bulgarian: return "&Инструменти";
					case chinese: return "&工具";
					case czech: return "&Nástroje";
					case danish: return "&Værktøj";
					case dutch: return "&Gereedschap";
					case estonian: return "&Tööriistad";
					case finnish: return "&Työkalut";
					case french: return "&Outils";
					case german: return "&Werkzeuge";
					case greek: return "&Εργαλεία";
					case hebrew: return "כלים&";
					case hindi: return "&उपकरण";
					case italian: return "&Utensili";
					case japanese: return "&ツール";
					case korean: return "&도구들";
					case latvian: return "&Rīki";
					case lithuanian: return "&Įrankiai";
					case norwegian: return "&Verktøy";
					case persian: return "ابزارها&";
					case polish: return "&Przybory";
					case portuguese: return "&Ferramentas";
					case romanian: return "&Unelte";
					case russian: return "&инструменты";
					case spanish: return "&Herramientas";
					case swedish: return "&Verktyg";
					case tamil: return "&கருவிகள்";
					case turkish: return "&Araçlar";
					default: return "&Tools";
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
					case estonian: return "Versioon";
					case finnish: return "Versio";
					case french: return "Version";
					case german: return "Version";
					case greek: return "Εκδοχή";
					case hebrew: return "גִרְסָה";
					case hindi: return "संस्करण";
					case italian: return "Versione";
					case japanese: return "バージョン";
					case korean: return "번역";
					case latvian: return "Versija";
					case lithuanian: return "Versija";
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

		public static string Window {
			get {
				switch (TwoLettName) {
					case arabic: return "نافذة او شباك&";
					case bulgarian: return "&прозорец";
					case chinese: return "&窗口";
					case czech: return "&Okno";
					case danish: return "&Vindue";
					case dutch: return "&Venster";
					case estonian: return "&Aken";
					case finnish: return "&Ikkuna";
					case french: return "&Fenêtre";
					case german: return "&Fenster";
					case greek: return "&Παράθυρο";
					case hebrew: return "חַלוֹן&";
					case hindi: return "&खिड़की";
					case italian: return "&Finestra";
					case japanese: return "&窓";
					case korean: return "&창문";
					case latvian: return "&Logu";
					case lithuanian: return "&Langas";
					case norwegian: return "&Vindu";
					case persian: return "پنجره&";
					case polish: return "&Okno";
					case portuguese: return "&Janela";
					case romanian: return "&Fereastră";
					case russian: return "&Окно";
					case spanish: return "&Ventana";
					case swedish: return "&Fönster";
					case tamil: return "&ஜன்னல்";
					case turkish: return "&Pencere";
					default: return "&Window";
				}
			}
		}
	}
}