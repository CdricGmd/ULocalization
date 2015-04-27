using UnityEngine;
using System;
using System.Collections;

namespace ULocalization
{
	/// <summary>
	/// This is a simple demo script of a Localized GUI.
	/// It is only meant to be run from the Editor.
	/// Inspired by http://forum.unity3d.com/threads/add-multiple-language-support-to-your-unity-projects.206271/
	/// </summary>
	public class LocalizedGUI : MonoBehaviour {
		
		#region [PUBLIC MEMBERS]
		[ContextMenuItem("Set language", "SetLanguage")]
		public string m_Language = "en";
		public string m_FilePath = "Assets/Localization/demo/strings.xml";
		public string m_XmlString = "";
		public string m_Key = "app_name";
		
		public int m_Score = 0; 
		public string m_PlayerName = "Toto";
		
		public Localization m_Localization;
		#endregion
		
		#region [Unity]
		void Awake () 
		{
			#if ! UNITY_EDITOR
			Debug.LogError("This script should only be run in Unity Editor, because of unsafe/direct file access");
			#endif
		
			m_Localization = ScriptableObject.CreateInstance<Localization>();
			m_XmlString = System.IO.File.OpenText(m_FilePath).ReadToEnd(); // Load file in a string
			SetLanguage() ;// init
		}
		
		void OnGUI()
		{
			GUILayout.BeginVertical();
			
			GUILayout.Label("<b>--- Edit ---</b>");
				
			GUILayout.BeginHorizontal();
			GUILayout.Label("Language: ");
			m_Language = GUILayout.TextField(m_Language); // Edit this field to change the language
			GUILayout.EndHorizontal();
			
			GUILayout.Label("Language file: ");
			m_XmlString = GUILayout.TextField(m_XmlString); // Edit this field to change the values (equivalent to live-editing xml file)
			
			if(GUILayout.Button("Apply language")) // Apply and see the result
			{
				SetLanguage();
			}
			
			GUILayout.Space(20);
			GUILayout.Label("<b>--- Game ---</b>");
			
			// NB: Calling every frame mLocalization["key"] is not optimal but is more readable for a simple demo script;
			GUILayout.Label("<b>" + m_Localization["app_name"] + "</b>");
			GUILayout.Label("<i>" + m_Localization["welcome_text"] + "</i>");
			GUILayout.Label(m_Localization["score_text"] + m_Score);
			
			GUILayout.BeginHorizontal();
			GUILayout.Label(m_Localization["player_text"]);
			m_PlayerName = GUILayout.TextField(m_PlayerName);
			GUILayout.EndHorizontal();
			
			GUILayout.Label(m_Localization["score_info", m_PlayerName, "" + m_Score]); // Insert values in the string
			
			// Interactuve "value : key"
			GUILayout.BeginHorizontal();
			m_Key = GUILayout.TextField(m_Key);
			GUILayout.Label(" : " + m_Localization[m_Key]);
			GUILayout.EndHorizontal();
			
			
			GUILayout.EndVertical();
		}
		#endregion
		
		#region [PRIVATE MEMBERS]
		void SetLanguage()
		{
			m_Localization.SetLanguageString(m_XmlString, m_Language);	
			m_Score++;
		}
		#endregion
	}
}