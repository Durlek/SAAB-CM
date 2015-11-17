Instruktioner för körning:
En .options-fil måste skapas i CBRNSensors-mappen, denna kan användas (CoREdebug.options):

<?xml version="1.0" encoding="utf-8"?>
<settings>
	<setting name="BinarySearchPath" value="<er sökväg här>\Output\Win32\VS100\Debug" />
	<setting name="DebugInterfaceActiveStartup" value="True" />
</settings>

Därefter kanske ni måste ställa in så att visual studio försöker köra rätt projekt. Högerklicka på 'Solution Saab.CBRN' sedan 'Properties'. I dropdown menyn väljer ni 'Saab.CBRNSensors'.

Slutligen måste ni se till att startkommandot som körs använder rätt sökvägar. Högerklicka 'Saab.CBRNSensors' sedan 'Properties' sedan 'Debug'. Ändra sökvägarna i 'Command line arguments' så att de pekar rätt.

Därefter skall det gå att köra allt från Visual Studio i admin-läge :)