Scripts

Ett script �r filen som programmeringskoden skrivs i.
Unity anv�nder C# som programmeringsspr�k

programmerinsspr�k anv�nder sig av "nycleord". De �r kodord till kompilatorn som s�ger vad som ska h�nda n�st

i skript anv�nds olika nyckelord s� som "class", "struct", "enum", "int", och "float" �r n�gra f� exempel
"class", "struct", och "enum" �r datatyper som anv�ndaren definierar.

"private" �r ett nyckelord som s�ger att en datatyp ska vara tillg�nglig i skriptet men inte utanf�r
"protected" s�ger att den kan synas �verallt men bara skriptet kan �ndra den
"public" s�ger att den kan �ndras av alla som har tillg�ng till skriptet



public class MyClass 
{
	
	// variablar �r f�rutbest�mda datatyper som anv�nds
	// En variabel s�ger �t kompilatorn att allokera (tilldela) en del av ramminnet f�r den typen av data variabeln h�ller
	// Kompilatorn ignorerar om det finns data d�r innan, d�rf�r kan det vara bra att tilldela en ny variabel ett v�rde f�r att undvika buggar

	//de vanligaste variabeltyperna f�r nummer �r "int" och "float"

	int heltal = 0;				// kan ej inneh�lla decimaler, bara siffrorna innan decimaltecknet l�ses och sparas i variabeln
	
	float flytandeTal = 0;		// decimaltal
	
	// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types exempel p� datatyper som h�ller heltal
	// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types exempel p� datatyper som inneh�ller decimaltal

	bool shouldRun = false; // bool �r en variabel som kan vara sann eller falsk

	
	
	// En funktion anv�nds f�r att bearbeta data och/eller utf�ra ett visst beteende
	// en function definieras av "dataTyp funktionsnamn() { }".  

	public float MyFloatFunction()
	{

	//	"{" talar om f�r kompilatorn att ett kodblock startar.   
	
		// funktioner m�ste retunera datatypen de �r.
	
		return flytandeTal;

	}
	
	//	"}" talar om f�r kompilatorn att ett kodblock avslutas


	// om en funktion inte beh�ver retunera ett v�rde s� anv�nds "void"
	
	public void MyVoidFunction()
	{
		// en funktion kan anv�nda variablar i klassen och kalla p� andra funktioner
		// en funktion kan deklarera en variabel, den variabeln existerar bara innaf�r funktionen

		int functionVariable = 0; 
		
		// n�r en funktion med argument kallas s� m�ste argumenten ges v�rden, h�r variablar
		
		functionVariable = MyFunctionWithArguments(heltal, flytandeTal);

		int myRoundedVariable = 0;

		// argumenten kan vara direkta v�rden utan att vara bundna till variablar
		// nummer utan variablar kallas "magic numbers" och �r vanligtvis d�lig praxis

		myRoundedVariable = MyRoundedArguments(13, 157.33f);

	}


	// funktion med argument
	public int MyFunctionWithArguments(int intArgument, float floatArgument)
	{
		
		// funktionen anv�nder "intArgument" som n�mnare i en division 
		// det g�r inte att dela med "0" s� d�rf�r kollas v�rdet innan
		
		if(intArgument != 0)
		{
			// kompilatorn kommer att anta att svaret �r av datatypen "float". 
			// Genom att skriva "(int)" talar vi om f�r kompilatorn att konvertera nummret till "int"

			// OBS! �ven om svaret �r "15.9999" s� kommer funktionen ge "15"
			// den rundar inte av, s�nt m�ste g�ras manuellt!

			return (int) floatArgument / intArgument; 
		}

		// om "if"-satsen �r falsk
		
		else
		{
			
			return 0;
		}
	}
	
	// argument existerar bara i funktionen som de �r deklarerade i, d�rf�r kan namnen upprepas
	
	public int MyRoundedArguments(int intArgument, float floatArgument)
	{
		if(intArgument != 0)
		{
			// ger nummret en variabel som nu kan anv�ndas
			int roundedNumber = (int) floatArgument / intArgument; 
			
			// h�r kollas numret f�r att se om det ska rundas upp�t eller ned�t
			if((floatArgument - roundedNumber) >= 0.5f)
			{
				return roundedNumber + 1;
			}
			else
			{
				return roundedNumber;
			}

		}
		else
		{
			return 0;
		}
	}
}


"enum" �r en datatyp som h�ller variablar med en v�rdetyp

public enum MyEnum
{
	// v�rden seppareras med kommatecken
	// varje v�rde �r unikt
	// om inget v�rde specificeras kommer kompilatorn att tilldela ett v�rde	
	MyFirstValue,
	MySecondValue,
}

