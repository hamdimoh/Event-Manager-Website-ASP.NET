# Event-Manager

Der Event-Manager ist eine Webanwendung, die Ihnen dabei hilft, Veranstaltungen wie Konferenzen, Workshops und Seminare zu organisieren und durchzuführen. Das Tool ermöglicht die automatisierte Planung und Verwaltung von Veranstaltungen sowie die Verwaltung von Teilnehmerdaten, Ressourcen, Budgets und Aufgaben.


# Funktionen

- Registrierung und Verwaltung von Teilnehmerdaten
- Verwaltung von Veranstaltungsterminen
- Budgetverwaltung für Veranstaltungen
- Zuweisung und Verfolgung von Aufgaben
- Benutzerrollen zur differenzierten Zugriffskontrolle
- Kommunikation und Benachrichtigungen über E-Mail, Kalenderintegration und automatische Erinnerungen
 


## Systemanforderungen

Um den Event-Manager auf Ihrem lokalen Entwicklungssystem auszuführen, müssen Sie folgende Software installieren:

- Visual Studio (empfohlen: Visual Studio 2022 Preview)
- SQL Server Management Studio(Server = localhost)
-Google Chrome(empfohlen)






# Installation

Hinweis: Stellen Sie sicher, dass Sie über eine Verbindung zum Internet verfügen, um gegebenenfalls benötigte Pakete herunterladen zu können.

1. Klonen Sie das Repository auf Ihr lokales Entwicklungssystem (löschen Sie bitte die vorherige Datei, die im ersten Sprint vorhanden war und Klonen Sie bitte erneut).
2. Öffnen Sie das Projekt in Visual Studio.
3. Öffnen Sie die Paket-Manager-Konsole und geben Sie den Befehl "Update-Database" ein, um die Datenbankverbindung herzustellen und die Datenbank zu aktualisieren.
4. Starten Sie die Anwendung.


# Verwendung 

	Der Admin hat die folgenden Zugriffe auf das Tool: 
Admin:
	Registrieren 
	Einloggen 
	Rollen zuweisen 
	Benutzerkonten verwalten 
	Events erstellen / bearbeiten / löschen
	Budget verwalten
	Aufgaben zuweisen 
	Einladungen versenden 












	Der Organisator hat die folgenden Zugriffe auf das Tool: 
Organisator:
	Registrieren
	Einloggen
	Events erstellen / bearbeiten / löschen
	Budget verwalten
	Aufgaben zuweisen 
	Einladungen versenden 

	 Der Mitwirkende hat die folgenden Zugriffe auf das Tool: 
Mitwirkende:
	Aufgabenliste erstellen 
	Aufgaben annehmen oder ablehnen 
	Sich ausloggen
 
	Der Teilnehmer hat die folgenden Zugriffe auf das Tool: 
Teilnehmer:
	Veranstaltungen suchen 
	Veranstaltungsdaten auswählen
	Persönliche Daten eintragen 
	Buchung bestätigen 

# Lizenz

Dieses Projekt steht unter der MIT-Lizenz.

