<?php session_start(); 
/*
		Funkce session_start() udělá v podstatě toto:
			1. Zkontroluje klienta: Podívá se, jestli prohlížeč v souborech Cookie poslal speciální ID (obvykle se jmenuje PHPSESSID).
			2. Otevře skříňku: Na straně serveru najde soubor (skříňku), který patří k tomuto ID.
			3. Zpřístupní data: Naplní superglobální pole $_SESSION daty, která jste do něj uložili při přihlášení (jméno, příjmení, ID uživatele).
		
		Co se stane, když tam ten řádek nedáte?
		Pokud session_start() vynecháte:
			• Proměnná $_SESSION bude prázdná.
			• PHP vypíše chybu (nebo varování), že proměnná $_SESSION["first-name"] neexistuje.

            Uživatel uvidí jen prázdné místo místo svého jména, protože server sice data má uložená na disku, ale vy jste mu "neřekli", aby tu skříňku otevřel.

    Dává se hned na první řádek HTML dokumentu.
    
    */

    // Pokud v session není ID uživatele, pošli ho zpět na login
    if (!isset($_SESSION["id"])) {
        header("Location: login.php");
        exit();
    }
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="main_page.css">
    <title>Document</title>
</head>
<body>
    <h1 class="welcome">Welcome 
    <?php 
        echo $_SESSION["first-name"] . " " . $_SESSION["last-name"];
    ?></h1>
    <!-- tohle je jen pro ohňostrojový efekt.. -->
    <div class="firework-container">
        <div class="firework"></div>
        <div class="firework"></div>
        <div class="firework"></div>
    </div>
</body>
</html>