<!DOCTYPE html>
<html>
<body>

<?php
$txt = "PHP";
echo "I love $txt!";
?>

<h1>Základní pravidla psaní v PHP</h1>
<ul> <!--ul je odrážkový seznam (unordered list) -->
	<li>Píšeme mezi tagy <b>&lt;?php</b> a <b>?&gt;</b></li>
    <li>Na konci řádku je vždy <b>středník</b></li>
    <li>Proměnné začínají <b>dolarem</b>. Nepíšeme explicitně datový typ proměnné.</li>
    <li>Výpis provedeme příkazem <b>echo</b>.</li>
</ul>

<p style="color:brown">Jednotlivé úkoly plňte vždy přímo pod zadání. Úkoly řešte pomocí PHP.</p>

<h2>1. úkol: Vypište "Ahoj světe!" (2b)</h2>
<?php
$txt = "Ahoj světe!";
echo "$txt";
?>
<h2>2. úkol: Součet dvou č1ísel (3b)</h2>
<p>Uložte do proměnné x číslo 3 a do proměnné y číslo 5. Vypište součet těchto dvou proměnných (nevypisujte však explicitně "echo 8", nýbrž pomocí těch dvou proměnných).</p>

<?php
$txt2 = 3;
?>
<?php
$txt3 = 5;
echo "Součet čísel $txt2 a $txt3 je " . ($txt2 + $txt3) . ".";
?>
<h2>3. úkol: Jméno v nadpisu (3b)</h2>
<p>Uložte do proměnné vaše jméno. Tuto proměnnou pak vypište v nadpisu největší velikosti (<b>tag h1</b>)</p>

<?php
$txt4 = "vaše jméno";
echo "<h1>$txt4</h1>";
?>

<h2>4. úkol: Podmínka (5b)</h2>
Uložte do proměnné x celé číslo. 
<ul>
    <li>Pokud je číslo kladné, vypište <b>paragraf</b> (tag <b>p</b>) s textem "X je kladné.", kde X je obsah proměnné x.</li>
    <li>Pokud je číslo záporné, vypište paragraf s textem "X je záporné."</li>
    <li>Pokud je číslo rovné nule, vypište paragraf s textem "X je rovno 0".</li>
</ul>

<?php
$x = 0;

if ($x > 0) {
    echo "<p>$x je kladné.</p>";
} elseif ($x < 0) {
    echo "<p>$x je záporné.</p>";
} else {
    echo "<p>$x je rovno 0.</p>";
}
?>

<p>Jak psát podmínky v PHP najdete <a href="https://www.w3schools.com/php/php_if_else.asp">zde</a> (otevřete v novém okně).</p>

<h2>5. úkol: While cyklus (5b)</h2>
<p>Vypište pod sebe čísla 1-10 (každé číslo na jeden řádek) pomocí while cyklu.</p>
<p>Jak psát while cyklus v PHP najdete <a href="https://www.w3schools.com/php/php_looping_while.asp">zde</a> (otevřete v novém okně).</p>

<?php
$i = 1;
while ($i <= 10) {
    echo "<p>$i</p>";
    $i++;
}
?>

<h2>6. úkol: For cyklus a pole (10b)</h2>
<p>Mějme nějaké pole čísel (viz kód stránky):</p>

<?php 
    $cisla = array(1,2,4,5,6,9,11,12,13);
    $delka_pole = count($cisla);
?>

<p>Vypište z něj všechna čísla, která jsou sudá.</p>
<p>Jak psát for cyklus v PHP najdete <a href="https://www.w3schools.com/php/php_looping_for.asp">zde</a> (otevřete v novém okně).</p>
<p>Jak pracovat s poli najdete <a href="https://www.w3schools.com/php/php_arrays.asp">zde</a> (otevřete v novém okně).</p>
<p>Kód v PHP pište až pod tento paragraf. <span style="color:brown">Všimněte si, že bloky PHP sice mohou být odděleny nějakým HTML kódem, ale platnost proměnných zůstává. Tedy můžeme dále pracovat s proměnnou <b>cisla</b>, ve které máme pole čísel uložené.</span></p>
<?php

foreach ($cisla as $cislo) {
        if ($cislo % 2 == 0) {
            echo "<p>$cislo</p>";
        }
    }

?>
<h2>7. úkol: Vygenerujte trojúhleník z hvězdiček (15b)</h2>
<p>Vygenerujte trojúhelník, který má 7 řad. V první řadě má 1 hvězdičku, v druhé dvě, ve třetí tři, atd.</p>

<?php
for ($i = 1; $i <= 7; $i++) {
    for ($j = 1; $j <= $i; $j++) {
        echo "*";
    }
    echo "<br>";
}


<h2>8. úkol: Vygenerujte položky e-shopu (15b)</h2>
<p>Vygenerujte 4 položky e-shopu ve tvaru:</p>
<?php 
    $nazvy = array("Mleko", "Zmrzlina", "Ruze", "Jablko");
    $ceny = array(12, 24, 59, 7);
    $kusy = array(50, 12, 40, 56);
?>
<div class="item" style="background:cornflowerblue">
    <p class="item-name">Název položky</p>
    <p class="item-price">Cena: 40,-</p>
    <p class="item-state-ok">Zbývá 20 kusů</p>
</div>
<p>Údaje čerpejte z polí <b>nazvy</b>, <b>ceny</b> a <b>kusy</b>.</p>
<p>Využijte toho, že PHP blok můžete v libovolném místě přerušit a v dalším bloku na něj zase navázat (klidně i uvnitř závorek) jako je vidět na následujícím příkladu:</p>

<?php
for ($i = 0; $i < count($nazvy); $i++) {
?>
    <div class="item" style="background:cornflowerblue">
        <p class="item-name"><?php echo $nazvy[$i]; ?></p>
        <p class="item-price">Cena: <?php echo $ceny[$i]; ?>,-</p>
        <p class="item-state-ok">Zbývá <?php echo $kusy[$i]; ?> kusů</p>
    </div>
}
?>
<?php 
$vek = 20;
if($vek>18)
{
?>
<p><?php echo "Je starší 18 let"; ?><p>
<?php 
}
?> 

</body>
</html>
