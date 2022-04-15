<?php
header('Access-Control-Allow-Origin: *'); // allow all origins
header("Content-Type: application/json; charset=UTF-8");

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

// get the q parameter from URL
$q = isset($_GET['q']) ? $_GET['q'] : '';
// echo "ukucano je: ", $q, "<br>";

// sql query core
$sql = "SELECT first_name, last_name, gender FROM employees WHERE ";

// format each of search keywords into the db query to be run
$keywords = explode(' ', $q);			
foreach ($keywords as $word){
	$sql .= "first_name LIKE '%$word%' OR last_name LIKE '%$word%' OR ";
}
$sql = substr($sql, 0, strlen($sql)-4);

// sql query add limit
$sql .= " LIMIT 10;";

$result = $conn->query($sql);

$outp = $result->fetch_all(MYSQLI_ASSOC);

echo json_encode($outp);

$conn->close();
?>