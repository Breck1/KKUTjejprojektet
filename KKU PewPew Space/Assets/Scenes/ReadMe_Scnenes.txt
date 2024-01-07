Unity använder sig av "scenes". För mindre spel används en scen i taget i hierarkin i Unity (med undantag för "DontDestroyOnLoad"). Större spel kan behöva
flera scener samtidigt för att hantera mer data. Det kan också göra att sammarbete mellan olika avdelingar blir lättare. 

"Scene" kan ses som världen. Allt som existerar i spelvärlden existerar i en "scene". Om en "scene" förstörs och en annan laddas förstörs allt som fanns i 
den "scene". I hierarkin i Unity är "scene" högst upp i hierarkin, allt annat är "child object" till scene.
Om en spelare klarar av en "scene" (level) och nästa "scene" ska laddas förstörs föregående "scene". Alla "child object" förstörs med "parent object".

När det finns värden som ska sparas mellan "scenes" så går det att använda: "Object.DontDestroyOnLoad". Det skapar en till "scene" som inte förstörs när nästa
mellan nivåerna.

Som programmerare kan det vara bra att skapa en scen där eventuella buggar och nya features.
Namnet på scenen bör vara unikt och det ska vara klart för alla i projektet att det är din scen


Källor:

- Scene: 
https://docs.unity3d.com/Manual/CreatingScenes.html

- Object.DontDestroyOnLoad:
https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html