using System.Globalization;

namespace BaseLibS.Util {
	public static class Loc {
		private static CultureInfo cultureInfo;
		public static CultureInfo CultureInfo {
			get => cultureInfo ?? (cultureInfo = CultureInfo.CurrentCulture);
			set => cultureInfo = value;
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
					case TwoLetterLanguageCodes.arabic: return "...يرجى تأكيد";
					case TwoLetterLanguageCodes.chinese: return "请确认...";
					case TwoLetterLanguageCodes.czech: return "Prosím potvrďte...";
					case TwoLetterLanguageCodes.danish: return "Bekræft venligst...";
					case TwoLetterLanguageCodes.dutch: return "Bevestig alstublieft...";
					case TwoLetterLanguageCodes.finnish: return "Ole hyvä ja vahvista...";
					case TwoLetterLanguageCodes.french: return "Veuillez confirmer...";
					case TwoLetterLanguageCodes.german: return "Bitte bestätigen...";
					case TwoLetterLanguageCodes.greek: return "Παρακαλώ Επιβεβαιώστε...";
					case TwoLetterLanguageCodes.hebrew: return "...אנא אשר";
					case TwoLetterLanguageCodes.hindi: return "कृपया पुष्टि करें...";
					case TwoLetterLanguageCodes.italian: return "Si prega di confermare...";
					case TwoLetterLanguageCodes.japanese: return "確認してください...";
					case TwoLetterLanguageCodes.korean: return "확인해주세요...";
					case TwoLetterLanguageCodes.norwegian: return "Vennligst bekreft...";
					case TwoLetterLanguageCodes.polish: return "Proszę potwierdzić...";
					case TwoLetterLanguageCodes.portuguese: return "Por favor confirme...";
					case TwoLetterLanguageCodes.russian: return "Пожалуйста подтвердите...";
					case TwoLetterLanguageCodes.spanish: return "Por favor confirmar...";
					case TwoLetterLanguageCodes.swedish: return "Var god bekräfta...";
					case TwoLetterLanguageCodes.turkish: return "Lütfen onaylayın...";
					default: return "Please confirm...";
				}
			}
		}
		public static string Stop {
			get {
				switch (TwoLettName) {
					case TwoLetterLanguageCodes.arabic: return "توقف";
					case TwoLetterLanguageCodes.chinese: return "停止";
					case TwoLetterLanguageCodes.czech: return "Stop";
					case TwoLetterLanguageCodes.danish: return "Hold op";
					case TwoLetterLanguageCodes.dutch: return "Hou op";
					case TwoLetterLanguageCodes.finnish: return "Stop";
					case TwoLetterLanguageCodes.french: return "Arrêtez";
					case TwoLetterLanguageCodes.german: return "Stopp";
					case TwoLetterLanguageCodes.greek: return "Να σταματήσει";
					case TwoLetterLanguageCodes.hebrew: return "תפסיק";
					case TwoLetterLanguageCodes.hindi: return "रुकें";
					case TwoLetterLanguageCodes.italian: return "Stop";
					case TwoLetterLanguageCodes.japanese: return "やめる";
					case TwoLetterLanguageCodes.korean: return "중지";
					case TwoLetterLanguageCodes.norwegian: return "Stoppe";
					case TwoLetterLanguageCodes.polish: return "Zatrzymać";
					case TwoLetterLanguageCodes.portuguese: return "Pare";
					case TwoLetterLanguageCodes.russian: return "Стоп";
					case TwoLetterLanguageCodes.spanish: return "Detener";
					case TwoLetterLanguageCodes.swedish: return "Sluta";
					case TwoLetterLanguageCodes.turkish: return "Durdur";
					default: return "Stop";
				}
			}
		}
	}
}