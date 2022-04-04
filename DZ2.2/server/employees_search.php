<?php
header('Access-Control-Allow-Origin: *'); // allow all origins

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "employees";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

//get the q parameter from URL
$q=$_GET["q"];
// echo "ukucano je: ", $q, "<br>";

// sql query
$sql = "SELECT first_name, last_name, gender FROM employees WHERE first_name LIKE '%$q%' OR last_name LIKE '%$q%' LIMIT 10;";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo   "<a href='#'>" .  $row["first_name"]. " " . $row["last_name"]. " ". "(" . $row["gender"] . ")" . "<br>". '</a>';
  }
} else {
  echo "Nema rezultata";
}
$conn->close();
?>