Prefabs

I hierarkin i Unity så finns "GameObject". 
Ett "GameObject" är ett objekt specifikt för Unity motorn.
Ett "GameObject" kan göras till en "prefab". Det görs genom att dra "Root object" in i en mapp i inspektorn
"Root object" är det objektet som alla andra objekt sitter fast på.
"Player" är "root object" i herarkin för spelaren.
I en prefab kan värden sättas utanför spel. Skript kan då använda den prefaben som referens för att skapa "GameObject". 
Ett "GameObject" som skapas baserat på en "prefab" kommer att få värderna som är satta i den "prefab" den är baserad på.