Testverktyg
--------------------------------
I ./Tester/ finns ett JavaScript verktyg för att kunna testa REST-interfacet. För att köra testerna måste nodejs och mocha installeras. För att installera nodejs, följ instruktionerna på hemsidan (nodejs.org). För att installera mocha, öppna en terminal och kör (efter att nodejs installerats) "npm install -g mocha". Efter detta har gjorts kan testerna köra genom att köra run.bat (bara på Windows) eller genom att köra "mocha" i en terminal från test-mappen.

Information REST-interface
--------------------------------
#### Starta sensorsimulation
POST /sensors/[sensornamn]  
Request body: sensors JSON-objekt  
Statuskod: 201  
  
Sensors id ges av locationheader i responsen  

#### Hämta sensordata
GET /sensors/[sensornamn]/[id]  
Respons body: sensors JSON-objekt  
Statuskod: 200, 404 (om sensorn inte finns)  

#### Uppdatera sensordata
PUT /sensors/[sensornamn]/[id]  
Request body: sensors JSON-objekt (endast de attribut som skall uppdateras)  
Statuskod: 200, 404 (om sensorn inte finns)  
  
För LCD finns ett attribut som heter DetectionMode. Detta värde kan EJ utelämnas från request body, för då kommer det värdet på servern ändras till 0. Istället för att utelämna attributet skall värdet sättas till 3 för att indikera att DetectionMode inte skall uppdateras.

#### Avsluta sensorsimulering
DELETE /sensors/[sensornamn]/[id]  
Statuskod: 200, 404 (om sensorn inte finns)  

#### Events
POST /sensors/event  
Request body: eventdata i JSON  
Statuskod: 200, 501 (om en sensortyp eller kommando inte stöds), 404 (om sensorn inte finns)  

JSON-datan är formaterad enligt följande:
	
	{
		Command: kommando  // se nedan
	,	Sensor: sensornamn // t ex lcd, ap2ce etc (OBS! lowercase)
	,	Id: sensorid       // samma id som används i alla andra metoders URL
	}
  
Följande events stöds (dessa strängar anges i `Command` ovan):  

**LCD**  

- silent current alarm
- audible alarm toggle
- reset sieve pack timer
- nvg toggle
- restart

**RAID**  

- toggle lib
- stop/start
- cleaning on
- cleaning off

**I28**

- reset accumulated dose rate
- reset peak dose rate

**I27**

- reset accumulated dose rate

#### Test av uppkoppling
GET /check  
Respons body: 123

**OBS! Pga WCF krävs att adresserna är *exakta*. Så om man lägger till ett extra '/' på slutet funkar det ej.**