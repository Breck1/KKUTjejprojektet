Scripts

Ett script är filen som programmeringskoden skrivs i.
Unity använder C# som programmeringsspråk

programmerinsspråk använder sig av "nycleord". De är kodord till kompilatorn som säger vad som ska hända näst

i skript används olika nyckelord så som "class", "struct", "enum", "int", och "float" är några få exempel
"class", "struct", och "enum" är datatyper som användaren definierar.

"private" är ett nyckelord som säger att en datatyp ska vara tillgänglig i skriptet men inte utanför
"protected" säger att den kan synas överallt men bara skriptet kan ändra den
"public" säger att den kan ändras av alla som har tillgång till skriptet



public class MyClass 
{
	
	// variablar är förutbestämda datatyper som används
	// En variabel säger åt kompilatorn att allokera (tilldela) en del av ramminnet för den typen av data variabeln håller
	// Kompilatorn ignorerar om det finns data där innan, därför kan det vara bra att tilldela en ny variabel ett värde för att undvika buggar

	//de vanligaste variabeltyperna för nummer är "int" och "float"

	int heltal = 0;				// kan ej innehålla decimaler, bara siffrorna innan decimaltecknet läses och sparas i variabeln
	
	float flytandeTal = 0;		// decimaltal
	
	// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types exempel på datatyper som håller heltal
	// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types exempel på datatyper som innehåller decimaltal

	bool shouldRun = false; // bool är en variabel som kan vara sann eller falsk

	
	
	// En funktion används för att bearbeta data och/eller utföra ett visst beteende
	// en function definieras av "dataTyp funktionsnamn() { }".  

	public float MyFloatFunction()
	{

	//	"{" talar om för kompilatorn att ett kodblock startar.   
	
		// funktioner måste retunera datatypen de är.
	
		return flytandeTal;

	}
	
	//	"}" talar om för kompilatorn att ett kodblock avslutas


	// om en funktion inte behöver retunera ett värde så används "void"
	
	public void MyVoidFunction()
	{
		// en funktion kan använda variablar i klassen och kalla på andra funktioner
		// en funktion kan deklarera en variabel, den variabeln existerar bara innaför funktionen

		int functionVariable = 0; 
		
		// när en funktion med argument kallas så måste argumenten ges värden, här variablar
		
		functionVariable = MyFunctionWithArguments(heltal, flytandeTal);

		int myRoundedVariable = 0;

		// argumenten kan vara direkta värden utan att vara bundna till variablar
		// nummer utan variablar kallas "magic numbers" och är vanligtvis dålig praxis

		myRoundedVariable = MyRoundedArguments(13, 157.33f);

	}


	// funktion med argument
	public int MyFunctionWithArguments(int intArgument, float floatArgument)
	{
		
		// funktionen använder "intArgument" som nämnare i en division 
		// det går inte att dela med "0" så därför kollas värdet innan
		
		if(intArgument != 0)
		{
			// kompilatorn kommer att anta att svaret är av datatypen "float". 
			// Genom att skriva "(int)" talar vi om för kompilatorn att konvertera nummret till "int"

			// OBS! även om svaret är "15.9999" så kommer funktionen ge "15"
			// den rundar inte av, sånt måste göras manuellt!

			return (int) floatArgument / intArgument; 
		}

		// om "if"-satsen är falsk
		
		else
		{
			
			return 0;
		}
	}
	
	// argument existerar bara i funktionen som de är deklarerade i, därför kan namnen upprepas
	
	public int MyRoundedArguments(int intArgument, float floatArgument)
	{
		if(intArgument != 0)
		{
			// ger nummret en variabel som nu kan användas
			int roundedNumber = (int) floatArgument / intArgument; 
			
			// här kollas numret för att se om det ska rundas uppåt eller nedåt
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


"enum" är en datatyp som håller variablar med en värdetyp

public enum MyEnum
{
	// värden seppareras med kommatecken
	// varje värde är unikt
	// om inget värde specificeras kommer kompilatorn att tilldela ett värde	
	MyFirstValue,
	MySecondValue,
}

