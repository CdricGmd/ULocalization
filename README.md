# ULocalization

=======

## What is it ?

ULocalization is a simple library to help using localized texts in Unity3D applications. ULocalization is integrated in Unity's Editor to localize UI Text components.

Localized text are stored in XML files with a simple syntax, inspired from Android resources files.

	<?xml version="1.0" encoding="utf-8"?>
	<resources>
	    <en>
	         <string name="app_name">My Game</string>
	         <string name="score_text">Score: </string>
	         <string name="welcome_text">Welcome</string>
	         <string name="player_text">Player</string>
	         <string name="score_info">Player %0% has %1% points !</string>
	    </en>
	    <fr>
	        <string name="app_name">Mon Jeu</string>
	        <string name="score_text">Score: </string>
	        <string name="welcome_text">Bienvenue</string>
	        <string name="player_text">Joueur</string>
	        <string name="score_info">Le joueur %0% a %1% points !</string>
	    </fr>
	    <de>
	        <string name="app_name">Mein Spiel</string>
	        <string name="score_text">Ergebnis: </string>
	        <string name="welcome_text">Willkommen</string>
	        <string name="player_text">Spieler</string>
	        <string name="score_info">Der Spieler %0% %1% Punkte erzielt!</string>
	    </de>
	</resources>

## Documentation

The Demo folder contains usage examples.

### Features

**Localization**: a ScriptableObject loading a resource file. 

	Localization m_Localization;

	// Init.
	m_Localization = ScriptableObject.CreateInstance<Localization>();
	string content = System.IO.File.ReadAllText("Assets/SomePath/strings.xml");
	m_Localization.SetLanguageString(content, "en");

	// Get localized values
	Debug.Log(m_Localization["app_name"]); // "My Game"
	Debug.Log(m_Localization["score_info", "Toto", "12"]); // "Player Toto has 12 points !" (inserted values)

The following components provide convenient Editor integration.

**LocalizationManager** component loads localized text file from `Resources` folder, handles system language choice and raise event on language changed.

**UIComponentLocalizer**: component to localize UI Text Components `UnityEngine.UI.Text`. Attach a UIComponentLocalizer on a UI Text, fill the key field and link to the LocalizationManager.

### NB

- the XML file does not support comments `<!-- some comments -->`

### Roadmap / Todo

- Allow local AND distant resource file
- Add component to localize UI Texts with inserted values from other components
- Better documentation / Wiki :)

## Installation

Copy / Download / Add as Submodule (...) the *ULocalization* folder somewhere in the *Assets* folder of your Unity project.

`Demo` folder is for instructional purpose only and can be removed from your project.

## Licensing

MIT. See LICENSE file.
