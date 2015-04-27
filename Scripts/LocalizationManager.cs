using UnityEngine;
using System.Collections;
using System.IO;

namespace ULocalization
{
	public delegate void EventHandler();
	
	public class LocalizationManager : MonoBehaviour 
	{
		#region [PUBLIC MEMBERS]
		public string Language
		{
			get 
			{
				if(m_Localization == null)
					return null;
				
				return m_Localization.Language;
			}
		}
		
		public string DefaultLanguage
		{
			get
			{
				return m_defaultLanguage;
			}
			set
			{
				m_defaultLanguage = value;
			}
		}
		
		public string LocalizationFile
		{
			get
			{
				return m_localizationFile;
			}
			set
			{
				m_localizationFile = value;
			}
		}
		
		public Localization Localization
		{
			get
			{
				return m_Localization;
			}
			set
			{
				m_Localization = value;
			}
		}
		
		public EventHandler OnLanguageChanged;
		#endregion
		
		#region [PRIVATE MEMBERS]
		
		[SerializeField]
		Localization m_Localization;
		
		[SerializeField]
		string m_defaultLanguage = "en";
		
		[SerializeField]
		string m_localizationFile;
		
		#endregion
		
		#region [UNITY]
		
		void Awake () 
		{
			m_Localization = ScriptableObject.CreateInstance<Localization>();
			LoadLanguage();
		}
		#endregion
		
		#region [PUBLIC METHODS]
		public void LoadLanguage(string aLanguage = null)
		{
			if(aLanguage == null)
			{
				aLanguage = GetSystemLanguageKey();
				Debug.Log("[LOCALIZATION] System language: " + aLanguage);
			}
			
			m_Localization.SetLanguageFile(m_localizationFile, aLanguage);
			if(m_Localization.Language == null)
			{
				Debug.LogWarning("[LOCALIZATION] Language not found, use default: " + DefaultLanguage);
				m_Localization.SetLanguageFile(LocalizationFile, DefaultLanguage);
			}
			
			NotifyLanguageChanged();
		}
		
		public string GetString(string aKey)
		{
			return m_Localization[aKey];
		}
		
		public string GetString(string aKey, params string[] aValueToInsertArray)
		{
			return m_Localization[aKey, aValueToInsertArray];
        }
		#endregion
		
		#region [PRIVATE METHODS]
		string GetSystemLanguageKey()
		{
			switch(Application.systemLanguage)
			{
			case SystemLanguage.English:
			{
				return "en";
			}
				
			case SystemLanguage.French:
			{
				return "fr";
			}
				
			case SystemLanguage.German:
			{
				return "de";
			}
				
			case SystemLanguage.Spanish:
			{
				return "sp";
			}	
			case SystemLanguage.Chinese:
			{
				return "cn";
			}	
			case SystemLanguage.Italian:
			{
				return "it";
			}	
			case SystemLanguage.Russian:
			{
				return "ru";
			}	
			//TODO add other languages
			case SystemLanguage.Unknown:
			default:
			{
				return DefaultLanguage;
			}
			}
		}
		
		void NotifyLanguageChanged()
		{
			if(OnLanguageChanged != null)
				OnLanguageChanged.Invoke();
		}
		#endregion
	}
}

