<?php 
include "db.php";

$email= $_POST["email"];
$pwd = $_POST["pwd"];


//ověříme, zda se shoduje e-mail a heslo:
$sql = "SELECT * FROM Users WHERE Email='$email' AND Password='$pwd'"; 

// spustíme SQL dotaz na naší databázi
$result = $conn->query($sql); 

// pokud dotaz nevrátil žádné řádky -> uživatelské jméno a heslo se neshodují
if ($result->num_rows == 0){ 

    //vrátíme se na přihlašování + předáme paramter pwd, že heslo nebylo v pořádku (pwd=false)
    Header("Location:login_page.php?pwd=false"); 
    
}
else // dotaz vrátil nějaký řádek -> shoduje se e-mail a zadané heslo
{
    // rozsekáme řádek po sloupcích do asociativního pole $row
    $row=$result->fetch_assoc(); 

    //pokud ještě není žádná session založena (např. uživatel už není přihlášený)
    if(session_id() == ''){ 
        session_start();

        //poznamenáme si, co se bude hodit vědět o přihlášeném uživateli do $_SESSION (superglobální PHP proměnná stvořena pro tyto účely předávání dat mezi jednotlivými stránkami naší webovky)
        $_SESSION["id"]=$row["UserID"]; 
        $_SESSION["first-name"]=$row["FirstName"];
        $_SESSION["last-name"]=$row["LastName"];
    }
    
    // Přejdeme na hlavní stránku e-shopu
    Header("Location:main_page.php"); 
}
?>