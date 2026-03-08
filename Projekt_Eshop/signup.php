<?php 
include "db.php";

$email = $_POST["email"];
$pwd = $_POST["pwd"];
$firstName = $_POST["first-name"];
$lastName = $_POST["last-name"];
$newsletter = isset($_POST["remember"]) ? 1 : 0;
// Ověříme, zda uživatel s tímto e-mailem již existuje
$sql = "SELECT * FROM Users WHERE Email='$email'"; 

// Spustíme SQL dotaz na naší databázi
$result = $conn->query($sql); 

// Pokud dotaz vrátil řádky -> uživatel s tímto e-mailem již existuje
if ($result->num_rows > 0){ 
    // Vrátíme se na registraci + předáme parametr, že e-mail je již registrován
    Header("Location:signup_page.html?error=email_exists"); 
}
else // E-mail není v databázi -> můžeme vytvořit nový účet
{

    
    // Vložíme nového uživatele do databáze
    $sql = "INSERT INTO Users (FirstName, LastName, Email, Newsletter, Password) 
            VALUES ('$firstName', '$lastName', '$email', '$newsletter', '$pwd')";
    
    if ($conn->query($sql) === TRUE) {
        // Úspěšná registrace - přejdeme na přihlašovací stránku
        Header("Location:login_page.php?signup=success"); 
    } else {
        // Chyba při registraci
        Header("Location:signup_page.html?error=database_error"); 
    }
}
?>