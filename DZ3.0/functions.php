<?php

function get_employees($id=0)
{
	global $connection;
	$query="SELECT * FROM employees";
	if($id != 0)
	{
		$query.=" WHERE emp_no=".$id." LIMIT 100";
	}
	$employees=array();
	$result=mysqli_query($connection, $query);
		while($row=mysqli_fetch_array($result,MYSQLI_BOTH))
		{
			$employees[]=$row;
		}
		header("HTTP/1.0 200 OK");
		header('Content-Type: application/json');
		$response=array("status"=>200, "employees"=> $employees,);

		echo json_encode($response);
	


}

function insert_employee()
	{
		global $connection;

		$data = json_decode(file_get_contents('php://input'), true);

		if (! array_key_exists("birth_date", $data) || ! array_key_exists("first_name", $data) || ! array_key_exists("last_name", $data) || ! array_key_exists("gender", $data) || ! array_key_exists("hire_date", $data)
			|| empty($data["birth_date"]) || empty($data["first_name"]) || empty($data["last_name"]) || empty($data["gender"]) || empty($data["hire_date"]) ) {
				
				header("HTTP/1.0 400 Bad Request");
				header('Content-Type: application/json');
				$response = array(
					'status' => 400,
					'message' => 'SVA POLJA SU OBAVEZNA!'
					);
		echo(json_encode($response));
		exit();
	}

		$employee_bdate		=$data["birth_date"];
		$employee_fname		=$data["first_name"];
		$employee_lname		=$data["last_name"];
		$employee_gender		=$data["gender"];
		$query="INSERT INTO employees VALUES (NULL,'".$employee_bdate."','".$employee_fname."','".$employee_lname."','".$employee_gender."',DATE(NOW()))";
		
		
		if(mysqli_query($connection, $query))
		{
			$broj_redaka = mysqli_affected_rows($connection);
			
			if ($broj_redaka > 0){
				$response=array(
				'status' => 201,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Employee Added Successfully.'
				);
				header("HTTP/1.0 201 Created");
				
			}
			else {
				$response=array(
				'status' => 500,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Employee Insert Error.'
				);
				header("HTTP/1.0 500 Internal Server Error");
				
			}
			
		}
		else
		{

			$response=array(
				'status' => 500,
				'query' => $query,
				'status_message' =>'Employee Addition Error.',
				'sql_error' => mysqli_error($connection)
				
			);
			header("HTTP/1.0 500 Internal Server Error");
		}

		header('Content-Type: application/json');
		echo json_encode($response);
	}
function update_employee($id)
	{
		global $connection;
		$post_vars = json_decode(file_get_contents("php://input"),true);

		if (! array_key_exists("birth_date", $post_vars) || ! array_key_exists("first_name", $post_vars) || ! array_key_exists("last_name", $post_vars) || ! array_key_exists("gender", $post_vars) || ! array_key_exists("hire_date", $post_vars)
			|| empty($post_vars["birth_date"]) || empty($post_vars["first_name"]) || empty($post_vars["last_name"]) || empty($post_vars["gender"]) || empty($post_vars["hire_date"]) ) {
			header("HTTP/1.0 400 Bad Request");
			header('Content-Type: application/json');
			$response = array(
				'status' => 400,
				'message' => 'SVA POLJA SU OBAVEZNA!'
				);
			echo(json_encode($response));
			exit();
		}

		$employee_fname		=$post_vars["first_name"];
		$employee_lname		=$post_vars["last_name"];
		$employee_gender	=$post_vars["gender"];
		$employee_bdate		=$post_vars["birth_date"];
		$employee_hdate		=$post_vars["hire_date"];
		//$employee_age=$post_vars["employee_age"];

		$query = "SELECT * FROM employees WHERE emp_no=" . $id;
		$result = mysqli_query($connection, $query);
		if($result->num_rows == 0) {
			$response = array(
				'status' => 404,
				'message' => 'Zaposlenik s tim ID-em ne postoji!'
			);
			header("HTTP/1.0 404 Not Found");
			echo(json_encode($response));
			exit();
		}
		
		$query="UPDATE employees SET first_name='".$employee_fname."', last_name='".$employee_lname."', gender='".$employee_gender."', birth_date='".$employee_bdate."', hire_date='".$employee_hdate."' WHERE emp_no=".$id;
		
		$result=mysqli_query($connection, $query);
		$broj_redaka = mysqli_affected_rows($connection);
		
		if($result)
		{
			$response=array(
				'status' => 200,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Employee Updated Successfully.'
			);
			header("HTTP/1.0 200 OK");
		}
		else
		{
			$response=array(
				'status' => 500,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Employee Updation Failed.'
			);
			header("HTTP/1.0 500 Internal Server Error");
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}

function delete_employee($id)
{
	global $connection;
	$query="DELETE FROM employees WHERE emp_no=".$id;
	if($result = mysqli_query($connection, $query))
	{
		$broj_redaka = mysqli_affected_rows($connection);
		//echo $broj_redaka;
		if ($broj_redaka === 1) {
			$response=array(
			'status' => 200,
			'broj_redaka' => $broj_redaka,
			'status_message' =>'Employee Deleted Successfully.'
		);
		header("HTTP/1.0 200 OK");
		}
		else {
			$response=array(
			'status' => 500, //some internal error status
			'broj_redaka' => $broj_redaka,
			'status_message' =>'Employee Deletion Error'
		);
		header("HTTP/1.0 500 Internal Server Error");
			
		}

	}
	else
	{
		$response=array(
			'status' => 500,
			'status_message' =>'Employee Deletion Failed.'
		);
		header("HTTP/1.0 500 Internal Server Error");
	}
	header('Content-Type: application/json');
	echo json_encode($response);
}


?>
