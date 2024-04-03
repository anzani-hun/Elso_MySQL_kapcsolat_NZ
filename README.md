Főbb elemei:
MySqlConnection: Létrehozza a kapcsolatot egy specifikus adatforráshoz.
MySqlCommand: SQL parancsokat hajt végre az adatforrást használva.
MySqlDataReader: Adatot streamel az adatforrásról.

​
Mire van szükség a kapcsolódáshoz?
Meg kell adni, hogy melyik névteret importáljuk (using).
using MySql.Data.MySqlClient;
​
Létre kell hozni egy connection string-et, ami tartalmazza a szerverhez kapcsolódás adatait.
string connectionString = "server=localhost;port=3306;userid=root;password=alma;database=mo_telepulesek";
​
Létre kell hozunk a MySqlConnection osztály egy példányát.
MySqlConnection dbConnection = new MySqlConnection(connectionString);
​
A MySqlConnection példány segítségével kapcsolódunk a szerverre.
dbConnection.Open();
​
Hogyan tudunk SQL parancsokat futtatni a szerveren?
Egy string típusú változóba meg kell írnunk a parancsot.
string sqlStatement = "SELECT version();";
​
Létre kell hoznunk a MySqlCommand osztály egy példányát. Az objektum szerepe, hogy lekérdezéseket hajtson végre az adatbázison.
A létrehozásakor meg kell adni első argumentumként a futtatandó SQL parancsot, második argumentumnak pedig a kapcsolatot kezelő MySqlConnection objektumot.
MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, dbConnection);
​
Alternatívaként üres argumentumlistával is létrehozhatjuk az objektumot. Ilyenkor utólag a Connection és CommandText osztályváltozók értékének módosításával tudjuk megadni a szükséges adatokat.
MySqlCommand sqlCommand = new MySqlCommand();
sqlCommand.Connection = dbConnection;
sqlCommand.CommandText = sqlStatement;
​
Ezt követően végre kell hajtanunk a lekérdezést. Amennyiben a lekérdezés outputja skalár érték lesz, a MySqlConnection osztály ExecuteScalar() metódusát használjuk.
output = sqlCommand.ExecuteScalar().ToString();
​
Hogyan bontjuk a kapcsolatot az adatbázis szerverrel?
A kapcsolat bontásához a MySqlConnection osztály Close() metódusát használjuk.
dbConnection.Close();
​
Feladat: Első kapcsolat létrehozása (MySql.Data)
A feladat, hogy létrehozzunk egy egyszerű parancssoros programot Elso_MySQL_kapcsolat néven, amely kapcsolódik egy localhost-on futó MySQL adatbázishoz, majd kiírja a verziószámot kétféleképpen is.
Alternatív csomagok MySQL adatbázishoz
A MySqlConnector szép világa
A MySql.Data fejlesztéseire alapozva elkészült egy nyílt közösségi fejlesztés eredményeként a MySqlConnector csomag.
A MySqlConnector használata mindenben megegyezik a MySql.Data használatával.
Miért érdemes használni?
Gyakrabban frissítik.
Stabilabban fut.
Több adatbázis motort is támogat.
Egyedül a névtér használata tér el a MySql.Data-tól:
using MySqlConnector;
​
A MySqlConnector hozzáadása a projekthez
A csomag telepítése majdnem teljesen ugyanaz, mint a MySql.Data esetében.
Itt is a Project menü → Manage NuGet Packages menüpontját választjuk és telepítjük a MySqlConnector package-t.
Alternatívaként a következő paranccsal is hozzáadható a csomag:
dotnet add package MySqlConnector
