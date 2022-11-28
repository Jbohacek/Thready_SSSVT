# Thready / Jak udělat aby auto jelo

Začal jsem s tim že jsem si definoval nějakou hlavní třídu `Vehicle.cs` a cestu `Road.cs` dále jsem postupoval tak, že jsem nadefinoval atributy `Road.cs`

------------
##### Road.cs


```csharp
		public int Lenght;
		public int MaxSpeed;
		public double CurrentProgess = 0;
		public bool CestaDokonce = false;

        public Road(int lenght, int maxSpeed)
        {
            Lenght = lenght;
            MaxSpeed = maxSpeed;
        }
```
Pokračoval jsem na `Vehicle.cs`
Nic extra. Dále jsem si představil jak by se takové vozidlo mělo pohybovat, což by mělo každou vteřinu přičíst jeho rychlost k aktualní pozici
`Rychlost + aktualní pozice na cestě`
S tímto pokud by se opakovalo tak bych dokazal "Simulovat" cestu, ale můj cyklus není celý, jelikož se nema kdy zastavit
`Pokud(Delka cesty > aktualni pozice na cestě) tak Rychlost + Aktualni pozice`
```csharp
While(cesta.lenght > cesta.CurrentProgess)
{
	cesta.CurrentProgess += CurrentSpeed;
}
```
S tímhle bychom měli hotový začátek, ale chybí nám Omezení rychlosti musíme přidat něco co bude zpoždovat náš kod, tudiž..
```csharp
Thread.Sleep([Int kolik milisetin musi uplynout])
```
Dále jsem jen přidal na výpis na konzoli.
```csharp
public void Move(ref Road Cesta)
{
	While(cesta.lenght > cesta.CurrentProgess)
	{
		Thread.Sleep(1);
		cesta.CurrentProgess += Math.Min(cesta.MaxSpeed,CurrentSpeed);

		Console.WriteLine(Math.Round((double)cesta.CurrentProgess / (double)cesta.lenght, 2) + "%");
	}
	cesta.CestaDokonce = true;
}
```

------------


Zhledem k tomu že tohle vše budeme chtít spustit jako separátní thread od našeho programu tak musime udělat ještě jednu Metodu. Předem si, ale řekneme o threadech.
### Thready
Program když se spustí tak se spustí takzvané vlákno, nebo-li thread, který běží řadek po řádku a vykonává příkazy, tak jak je napíšeme. Ale co když, chceme, aby běželi 2 na ráz? 
Jeden například dělal něco ve WhileLoopu a druhý zas něco Vypisoval?
Tady přichází na nástup thready, který nam toho umožní.

Na spuštění Threadu je potřeba vytvořit nějakou metodu, kterou thread udělá napřiklad:
```csharp
public void LetLetadlo()
{
	int Poloha = 0;
	while(true)
	{
		Poloha++;
		Console.WriteLine($"Poloha Letadla je: {Poloha}")
		Thread.Sleep(1);
	}
}
```
Normálně by program vyuzlil v opakování sama sebe a program by nic jineho krom tohodle nudělal, ovšem pokud-li udělame ještě jedno metodu, která tuhle metodu vola pomocí nového vlákna tak tenhle process bude běžet zvlášť.
```csharp
private void LetLetadlo()
{
	int Poloha = 0;
	while(true)
	{
		Poloha++;
		Console.WriteLine($"Poloha Letadla je: {Poloha}")
		Thread.Sleep(1);
	}
}

public void VypustLetadlo()
{
	Task.Run(LetLetadlo);
}
```

Pokud ted v program mainu zavoláme 5x `VypustLetadlo` tak se vypustí 5x a nás hlavní thread kodu nebude nijak ovlivněn a všech 5 letadel bude běžet "synchonizovaně" s kódem.
Co když chceme předat nějaký parametr? Uplně jednoduše:

```csharp
private void LetLetadlo(string Name)
{
	int Poloha = 0;
	while(true)
	{
		Poloha++;
		Console.WriteLine($"Poloha Letadla {Name} je: {Poloha}")
		Thread.Sleep(1);
	}
}

public void VypustLetadlo()
{
	Task.Run(() => LetLetadlo("Airbus"));
}
```

------------


#### Zpět k autíčkům

Tudiž jsem si vytvořil motodu která vystartuje autíčko jako jsem udělal v příkladě s letadlem. Všimněte si, že jsem změnil atribut public na private u Move a to z toho důvodu že nechceme, aby byla tahle metoda zavolaná jinak.

```csharp
private void Move(ref Road Cesta)
{
	While(cesta.lenght > cesta.CurrentProgess)
	{
		Thread.Sleep(1);
		cesta.CurrentProgess += Math.Min(cesta.MaxSpeed,CurrentSpeed);

		Console.WriteLine(Math.Round((double)cesta.CurrentProgess / (double)cesta.lenght, 2) + "%");
	}
	cesta.CestaDokonce = true;
}

public void StartMoving(Road Cesta)
{
	if (Cesta.CestaDokonce == false)
	{
		Task.Run(() => Move(ref Cesta));
	}
}
```

Nyní nám stačí vytvořit potřebný další atributy jako current speed, který může být konstatní číslo, nebo ho udělat relativní na akceleraci. To už je na vás, ale vaše auto rozjede tak, že...

```csharp
Vehicle Auto = new Auto(150) ;
// 150 jako jeho rychlost

Road cesta = new Cesta(50_000,120) ;
// 50_000 jako delka cesty, 120 jako maximalní rychlost

Auto.StartMoving(cesta);
Console.ReadLine(); 
//Abychom zastavili program a videli, že i přes zastavení běží, protože se to odehrava v jinem threadu.


```
#### Co znamenaji _ v 50_000?
To je jen na oddělený čísel, abychom to lépe přečetli s kódem to nema nic co dělat. (tuhle funkci má i Python)

## Co dál?
Zkuste si zkopírovat můj kod a připrogramovat tam motorku, nebo náklaďák.

Pokud jsou nějaké otázky, ptejte se.