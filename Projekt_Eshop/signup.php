<?php 
include "db.php";

$email = $_POST["email"];
$pwd = $_POST["pwd"];
$firstName = $_POST["first-name"];
$lastName = $_POST["last-name"];
$newsletter = isset($_POST["remember"]) ? 1 : 0;

$sql = "SELECT * FROM Users WHERE Email='$email'"; 


$result = $conn->query($sql); 


if ($result->num_rows > 0){ 

    Header("Location:signup_page.html?error=email_exists"); 
}
else
{

    $hashedPwd = password_hash($pwd, PASSWORD_DEFAULT);
    

    $sql = "INSERT INTO Users (FirstName, LastName, Email, Newsletter, Password) 
        VALUES ('$firstName', '$lastName', '$email', '$newsletter', '$hashedPwd')";
    
    if ($conn->query($sql) === TRUE) {

        Header("Location:login_page.php?signup=success"); 
    } else {

        Header("Location:signup_page.html?error=database_error"); 
    }
}
?>