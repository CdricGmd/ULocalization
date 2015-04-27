using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ULocalization
{
	[RequireComponent(typeof(Text))]
	public class UIComponentLocalizer : MonoBehaviour {
		
		#region [PUBLIC MEMBER]
		public LocalizationManager m_LocalizationManager;
		public string m_Key;
		#endregion
		
		#region [PRIVATE MEMBER]
		Text text;
		#endregion
		
		#region [UNITY]
		// Use this for initialization
		void OnEnable() 
		{
			text = GetComponent<Text>();
			if(m_LocalizationManager != null)
				m_LocalizationManager.OnLanguageChanged += UpdateText;
				
			UpdateText();
		}
		
		void OnDisable()
		{
			if(m_LocalizationManager != null)
				m_LocalizationManager.OnLanguageChanged -= UpdateText;
		}
		#endregion
		
		#region [PUBLIC METHOD]
		public void UpdateText()
		{
			if(m_LocalizationManager != null)
						text.text = m_LocalizationManager.GetString(m_Key);
//			text.text = localization[key];
		}
		#endregion
	}	
}

