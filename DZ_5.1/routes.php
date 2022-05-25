<?php
  function call($controller, $action) {
    require_once('controllers/' . $controller . '_controller.php');
    switch($controller) {
      case 'pages':
        $controller = new PagesController();
      break;
	    case 'employees':
        require_once('models/employees.php');
		    $controller = new EmployeesController();
      break;
      case 'departments':
        require_once('models/departments.php');
		    $controller = new DepartmentsController();
      break;
      case 'dept_emp':
        require_once('models/dept_emp.php');
		    $controller = new DeptEmpController();
      break;
    }

    $controller->{ $action }();
  }

  // we're adding an entry for the new controller and its actions
  $controllers = array('pages' 		=> ['home', 'error'],
                       'employees' 	=> ['index','verifyinsert','insertemployees','verifyupdate','updateemployees','delete','verifydelete'],
                       'departments' 	=> ['index','verifyinsert','insertdepartments','verifyupdate','updatedepartments','delete','verifydelete'],
                        'dept_emp'  => ['index','verifyinsert','insertdept_emp','verifyupdate','updatedept_emp','delete','verifydelete']
                    );

  if (array_key_exists($controller, $controllers)) {
    if (in_array($action, $controllers[$controller])) {
      call($controller, $action);
    } else {
      call('pages', 'error');
    }
  } else {
    call('pages', 'error');
  }
?>