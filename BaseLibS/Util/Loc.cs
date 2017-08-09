using System.Globalization;

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
					case polish: return "Andromeda";
					case portuguese: return "Andrômeda";
					case russian: return "Андромеда";
					case spanish: return "Andrómeda";
					case swedish: return "Andromeda";
					case tamil: return "ஆந்த்ரோமெடா";
					case turkish: return "Andromeda";
					default: return "Andromeda";
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
					case polish: return "Perseusz";
					case portuguese: return "Perseu";
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
					case polish: return "Proszę potwierdzić...";
					case portuguese: return "Por favor confirme...";
					case russian: return "Пожалуйста подтвердите...";
					case spanish: return "Por favor confirmar...";
					case swedish: return "Var god bekräfta...";
					case tamil: return "தயவுசெய்து உறுதிப்படுத்தவும்...";
					case turkish: return "Lütfen onaylayın...";
					default: return "Please confirm...";
				}
			}
		}

		public static string Start {
			get {
				switch (TwoLettName) {
					case arabic: return "بداية";
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
					case polish: return "Początek";
					case portuguese: return "Começar";
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
					case polish: return "Zatrzymać";
					case portuguese: return "Pare";
					case russian: return "Стоп";
					case spanish: return "Detener";
					case swedish: return "Sluta";
					case tamil: return "நிறுத்து";
					case turkish: return "Durdur";
					default: return "Stop";
				}
			}
		}
	}
}