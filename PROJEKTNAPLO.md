# Projektnapló – Konzolos rajzoló

## Csapat és munkamegosztás

| Név vagy GitHub-felhasználónév | Vállalt feladatok és szerep | Saját menüfunkció |
| --- | --- | --- |
| Erdős Dániel | Szín választás, rajzolás  ,rajz mód menü létrehozása| Radír |
| Bakos Bendegúz | Kezdő menü , fájl beolvasása , segítség menü, karakter választás, nyomdák | fajlba mentes |

## Közös megállapodások

- A rajzlap mérete és helye: A helye jobb oldalon. Mérete 82 x 28 cella
- A két munkarész kapcsolódási pontja: Az elkészült munkarészeket illesztjük be a program.cs-ben.
- A módosítások egyeztetése a main ágon: Egy közös ágon dolgozunk.

## Munkanapló

| Dátum | Ki | Mi készült el vagy miben állapodtunk meg? | Következő lépés vagy commit |
| --- | --- | --- | --- |
| 2026.11.15 | Bakos Bendegúz | Kezdő menü létrehozása | Hibák kijavítása, karakter választás menü létrehozása |
| 2026.11.17 | Bakos Bendeguz | Kezdo menu hibajainak kijavitasa | Karakter valaszto menu letrehozasa |
| 2026.11.20-21 | Bakos Bendeguz | Karakter valaszto menu letrehozasa | rajz mod menujenek letrehozasa |
| 2026.11.22 | Erdős Dániel | Szín választás menü létrehozása | Rajzolás funkció , radír letrehozása |
| 2026.11.22-23 | Erdős Dániel | Rajzolás funkció , radír, rajz mód menu megcsinálása |
| 2026.11.24 | Bakos Bendeguz | segítség menü létrehozása, nyomdak elkeszitese, program kisseb hibajinak kijavitasa,dokumentacio frissitese | beadas |
| 2026.11.24 | Erdős Dániel | Utolsó simitások, ékezetek javitása | Beadás |

## Másik pár tesztje

- Tesztelt commit: …
- Visszajelzés és saját javítás: …
- Újrateszt eredménye: …

## Otthoni AI-használat

Aki használt AI-t, írja le a nevét, miben kért segítséget, és mit tanult meg belőle.

- Név: Bakos Bendeguz
- Miben kértem segítséget: valaszthato karakterek listajanak elkeszitese,Hibak keresese,fajl beolvasasa elmentese 
- Mit tanultam meg: tombok kiirasa nem oylan mint pythonba ,nem lehet oket egybol ki irni (legalabbis char[]-t nem) helyette a string.join()-t kell hazsnalni,fajlol kezelese , openfiledialog hasznalata, enumerate és .select hasznalata

##

- Név: Erdős Dániel
- Miben kértem segítséget: Rajzolás funkció és a radír elkészítése, program összeomlásához megakadályozási módszer, hibák keresése
- Mit tanultam meg: 
- Ref kulcsszó: egy metodus a hivó változóját is megtudja változtatni és nem csak a másolatát (radír)
- Try/catch: meglehet akadalyozni veluk azt hogy egy futas közbeni hiba ne omlassza össze a programot hanem a catch-el lehet kezelni a hibát pl nálunk egy hangjelzéssel     
- A rajzot külön tárolni kell két helyen mert a konzol nem jegyzi meg, az egyik a StringBuilder sb-ben a karaktereket, és a ConsoleColor-ban pedig a cella színét.
