<!DOCTYPE html> 
<html>
    <head>
        <title>Log In Form</title>
        <link rel="stylesheet" href="styles_js.css"> <!-- Zde propojíme s CSS souborem. -->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css ">
    </head>
    <body>
        <button id="darkmodebtn" onclick="darkMode()"><i class="bi bi-moon-fill"></i></button>
        <form id="form" action="login.php" method="post">   
            <!-- action: kam se půjde po sumbit -->
            <!-- method: jakou metodou se budou posílat data ("GET" - veřejně v URL x "POST" - skrytě v HTTP requestu ) -->         
            <h1>Log In</h1>
            <p>Please fill in this form to log in.</p>
            <hr>

            <label for="email"><b>Email</b></label>
            <input type="email" placeholder="Enter Email" name="email" required>
            <!-- atribut 'name' se použije v metodě POST -->

            <label for="pwd"><b>Password</b></label>
            <input type="password" id="pwd" placeholder="Enter Password" name="pwd" required>

            <div class="button-container">
                <button type="submit" class="signupbtn">Log In</button>
                <!-- Nutné zde dát type="sumbit" jako signál pro vyhodnocení formuláře (pomocí action a method)-->
            </div>
        </form> 
        <?php
            if(isset($_GET["pwd"])) // uživatel zadal špatné heslo, jinak parametr pwd v URL není nastaven
            {
                echo "<p style='color:red; text-align:center;'>Zadáno špatné heslo.</p>";
            }
        ?>
        <p style="text-align:center;">If you don't have an account, please <a href="signup_page.html">sign up</a>.</p>
        <script src="myScript.js"></script>
    </body>
</html>