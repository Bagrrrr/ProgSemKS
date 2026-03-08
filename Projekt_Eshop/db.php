<?php
$server = "localhost";
$database = "8msejhar_eshop";   // název databáze, kterou máme vytvořenou v DBeaver
$username = "root";     // výchozí uživatel v XAMPP (je potřeba v XAMPP spustit MySQL)
$password = "";         // v XAMPP root standardně nemá heslo

// Create connection
$conn = new mysqli($server, $username, $password, $database);

// Check connection
if ($conn->connect_error) {
    die("Chyba připojení: " . $conn->connect_error);
}
?>