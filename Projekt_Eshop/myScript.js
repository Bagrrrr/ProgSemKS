// Darkmode měnění stylu
function darkMode(){
    document.body.classList.toggle("dark-mode");
    document.getElementById("form").classList.toggle("dark-mode");
    const inputElements = document.getElementsByTagName("input");
    for (const input of inputElements) {
        input.classList.toggle("dark-mode");
    }
    document.getElementById("darkmodebtn").classList.toggle("dark-mode");
}

// Ověření stejnosti hesel
function passwordsMatch() {
    const pwd1 = document.getElementById("pwd").value;
    const pwd2 = document.getElementById("pwd-repeat").value;
    
    if (pwd1 !== pwd2){
        document.getElementById("pwd-alert").style.display="block";
        // v takovém případě neodesílat formulář
    }
    else{
        document.getElementById("pwd-alert").style.display="none";
    }
}

// Ukázat text 

// validace správného formátu hesla

// skript až nakonec HTML