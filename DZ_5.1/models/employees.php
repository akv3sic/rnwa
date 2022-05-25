<?php
  class Employees  {
    // we define 3 attributes
    // they are public so that we can access them using $post->author directly
    public $emp_no;
    public $birth_date;
    public $first_name;
    public $last_name;
    public $gender;
    public $hire_date;



    public function __construct($emp_no,$birth_date, $first_name,$last_name, $gender,$hire_date) {
      $this->emp_no     = $emp_no;
      $this->birth_date      = $birth_date;
      $this->first_name      = $first_name;
      $this->last_name     = $last_name;
      $this->gender      = $gender;
      $this->hire_date  = $hire_date;
    }

    public static function all() {
      $list = [];
      $db = Db::getInstance();
      $req = $db->query('SELECT * FROM employees');
      // we create a list of Post objects from the database results
      foreach($req->fetchAll() as $oD) {
        $list[] = new Employees($oD['emp_no'], $oD['birth_date'], $oD['first_name'], $oD['last_name'], $oD['gender'],$oD['hire_date']);
      }

      return $list;
    }

    public static function find($oD) {
      $db = Db::getInstance();
      $oD = intval($oD);
      $req = $db->prepare('SELECT * FROM employees WHERE emp_no = :oD');
      $req->execute(array('oD' => $oD));
      $employees = $req->fetch();

      return new Employees($employees['emp_no'], $employees['birth_date'], $employees['first_name'], $employees['last_name'], $employees['gender'],$employees['hire_date']);
    }

    public static function insertemployees($emp_no,$birth_date, $first_name,$last_name, $gender,$hire_date) {
      $db = Db::getInstance();
      $emp_no = intval($emp_no);
      $sql="INSERT INTO employees (emp_no,birth_date ,first_name, last_name, gender, hire_date )
      VALUES ('$emp_no','$birth_date', '$first_name','$last_name', '$gender','$hire_date')";
      $db->query($sql);
    }

    public static function updateemployees($emp_no,$birth_date, $first_name,$last_name, $gender,$hire_date) {
      $db = Db::getInstance();
      $emp_no = intval($emp_no);
      $sql="UPDATE employees SET birth_date = '$birth_date', first_name='$first_name', last_name = '$last_name', gender='$gender', hire_date='$hire_date'
       WHERE emp_no = '$emp_no' ";
      $db->query($sql);
    }

  	public static function deleteemployees($oD) {
      $db = Db::getInstance();
      $sql="DELETE FROM employees WHERE emp_no = '$oD'";
	    $db->query($sql);
		}
  }
?>