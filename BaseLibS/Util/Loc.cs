using System.Globalization;

namespace BaseLibS.Util {
	public static class Loc {
		public const string arabic = "ar";
		public const string chinese = "zh";
		public const string czech = "cs";
		public const string danish = "da";
		public const string dutch = "nl";
		public const string english = "en";
		public const string finnish = "fi";
		public const string french = "fr";
		public const string german = "de";
		public const string greek = "el";
		public const string hebrew = "he";
		public const string hindi = "hi";
		public const string italian = "it";
		public const string japanese = "ja";
		public const string korean = "ko";
		public const string norwegian = "no";
		public const string polish = "pl";
		public const string portuguese = "pt";
		public const string russian = "ru";
		public const string spanish = "es";
		public const string swedish = "sv";
		public const string tamil = "ta";
		public const string turkish = "tr";
		private static CultureInfo cultureInfo;

		public static CultureInfo CultureInfo {
			get => cultureInfo ?? (cultureInfo = CultureInfo.CurrentCulture);
			set {
				twoLettName = null;
				cultureInfo = value;
			}
		}

		private static string twoLettName;

		private static string TwoLettName {
			get {
				if (string.IsNullOrEmpty(twoLettName)) {
					twoLettName = CultureInfo.TwoLetterISOLanguageName;
				}
				return twoLettName;
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