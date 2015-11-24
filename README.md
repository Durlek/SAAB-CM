Instruktioner för körning
--------------------------------
En .options-fil måste skapas i CBRNSensors-mappen, denna kan användas (CoREdebug.options):

	<?xml version="1.0" encoding="utf-8"?>
	<settings>
		<setting name="BinarySearchPath" value="<er sökväg här>\Output\Win32\VS100\Debug" />
		<setting name="DebugInterfaceActiveStartup" value="True" />
	</settings>

Därefter kanske ni måste ställa in så att visual studio försöker köra rätt projekt. Högerklicka på 'Solution Saab.CBRN' sedan 'Properties'. I dropdown menyn väljer ni 'Saab.CBRNSensors'.

Slutligen måste ni se till att startkommandot som körs använder rätt sökvägar. Högerklicka 'Saab.CBRNSensors' sedan 'Properties' sedan 'Debug'. Ändra sökvägarna i 'Command line arguments' så att de pekar rätt.

Därefter skall det gå att köra allt från Visual Studio i admin-läge :)

Testverktyg
--------------------------------
I ./Tester/ finns ett JavaScript verktyg för att snabbt testa REST-interfacet. För att kunna köra testerna måste nodejs och mocha installeras. För att installera nodejs, följ instruktionerna på hemsidan (nodejs.org). För att installera mocha, öppna en terminal och kör (efter att nodejs installerats) "npm install -g mocha". Efter detta har gjorts kan testerna köra genom att köra run.bat (bara på Windows) eller genom att köra "mocha" i terminal från test-mappen.

Information REST-interface
--------------------------------
#### Starta sensorsimulation
POST /sensors/[sensornamn]  
Request body: sensors JSON-objekt  
Statuskod: 201  
Övrigt: Sensors id ges av locationheader i responsen  

#### Hämta sensordata
GET /sensors/[sensornamn]/[id]  
Respons body: sensors JSON-objekt  
Statuskod: 200, 404 (om sensorn inte finns)  

#### Uppdatera sensordata
PUT /sensors/[sensornamn]/[id]  
Request body: sensors JSON-objekt (endast de som skall uppdateras)  
Statuskod: 200, 404 (om sensorn inte finns)  

#### Avsluta sensorsimulering
DELETE /sensors/[sensornamn]/[id]  
Statuskod: 200, 404 (om sensorn inte finns)  

#### Events
Inte hanterade i nuläget, skall fixas i veckan.

#### Test av uppkoppling
GET /check
Respons body: 123 (lite overkill kanske, men men)

**OBS! Pga WCF krävs att adresserna är *exakta*. Så om man lägger till ett extra '/' på slutet funkar det ej.**