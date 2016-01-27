using UnityEngine;
using UnityEngine.UI;

namespace ULocalization
{
	/// <summary>
	/// Demo script. Load localization and try to change language when the button is pressed.
	/// </summary>
	public class ChangeLocalization : MonoBehaviour
	{
		#region [public members]

		public string[] m_Languages = {"fr", "en", "de", "es", "jp"};
		public int m_CurrentLanguageIndex = -1; // Initially the system language is loaded

		public Text scoreLabel;

		#endregion

		#region [Private members]

		LocalizationManager localizationManager;

		#endregion

		#region [Unity]

		// Use this for initialization
		void Start ()
		{
			localizationManager = GetComponent<LocalizationManager>();
			NextLanguage();
		}

		#endregion

		#region [PUBLIC METHODS]

		public void NextLanguage()
		{
			m_CurrentLanguageIndex = (m_CurrentLanguageIndex + 1) % m_Languages.Length;

			Debug.Log("Set language to: " + m_Languages[m_CurrentLanguageIndex]);

			localizationManager.LoadLanguage(m_Languages[m_CurrentLanguageIndex]);

			scoreLabel.text = "" + m_CurrentLanguageIndex;
    }

		#endregion
	}
}
