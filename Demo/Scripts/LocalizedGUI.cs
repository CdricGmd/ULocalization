using UnityEngine;

namespace ULocalization
{
    /// <summary>
    /// This is a simple demo script of a Localized GUI.
    /// It is only meant to be run from the Editor.
    /// Inspired by http://forum.unity3d.com/threads/add-multiple-language-support-to-your-unity-projects.206271/
    /// </summary>
    public class LocalizedGUI : MonoBehaviour
    {

		#region [Public members]

		[ContextMenuItem("Set language", "SetLanguage")]
		public string m_language = "en";
		public string m_fileName = "strings";
		public string m_xmlString = "";
		public string m_key = "app_name";

		public int m_score = 0;
		public string m_playerName = "Toto";

		public Localization m_localization;

		#endregion

		#region [Private members]

		Vector2 m_scrollPosition = Vector2.zero;

		#endregion

		#region [MonoBehaviour]

		void Awake ()
		{
			#if ! UNITY_EDITOR
			Debug.LogError("This script should only be run in Unity Editor, because of unsafe/direct file access");
			#endif

			m_localization = ScriptableObject.CreateInstance<Localization>();
			TextAsset textAsset = Resources.Load<TextAsset>(m_fileName);
			if(textAsset != null)
			{
				m_xmlString = textAsset.text;
			}
			else
			{
				Debug.LogError("[LocalizedGUI] Resource not found : " + m_fileName);
				m_xmlString = "";
			}
			SetLanguage() ;// init
		}

		void OnGUI()
		{
			m_scrollPosition = GUILayout.BeginScrollView(m_scrollPosition);
			GUILayout.BeginVertical();

			//
			// Edition : change language and localization texts
			//

			GUILayout.Label("<b>--- Edit ---</b>");

			GUILayout.BeginHorizontal();
			GUILayout.Label("Language: ");
			m_language = GUILayout.TextField(m_language); // Edit this field to change the language
			GUILayout.EndHorizontal();

			GUILayout.Label("Language file: ");
			m_xmlString = GUILayout.TextField(m_xmlString); // Edit this field to change the values (equivalent to live-editing xml file)

			if(GUILayout.Button("Apply language")) // Apply and see the result
			{
				SetLanguage();
			}

			GUILayout.Space(20);

			//
			// Application : display some values
			//

			GUILayout.Label("<b>--- Game ---</b>");

			// NB: Calling every frame Localization["key"] is not optimal but is more readable for a simple demo script;
			GUILayout.Label("<b>" + m_localization["app_name"] + "</b>");
			GUILayout.Label("<i>" + m_localization["welcome_text"] + "</i>");
			GUILayout.Label(m_localization["score_text"] + m_score);

			GUILayout.BeginHorizontal();
			GUILayout.Label(m_localization["player_text"]);
			m_playerName = GUILayout.TextField(m_playerName);
			GUILayout.EndHorizontal();

			GUILayout.Label(m_localization["score_info", m_playerName, "" + m_score]); // Insert values in the string

			//
			// Interactive "value : key"
			//

			GUILayout.BeginHorizontal();
			m_key = GUILayout.TextField(m_key);
			GUILayout.Label(" : " + m_localization[m_key]);
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();
			GUILayout.EndScrollView();
		}

		#endregion

		#region [Private members]

		void SetLanguage()
		{
			m_localization.SetLanguageString(m_xmlString, m_language);
			m_score++;
		}

		#endregion
	}
}
