<div class="container">
	<br>
    <center><h1>EMPLOYEES</h1></center>
	<br>
  <div class="mb-2">
  <a class="btn btn-primary" href="?controller=employees&action=verifyinsert" role="button">Add New</a>
  </div>

  <div class="table-responsive"> 
    <table class="table">
        <tr>
            <th>EMPLOYEE NUMBER Number</th>
            <th>BIRTH DATE</th>
            <th>FIRST NAME</th>
            <th>LAST NAME</th>
            <th>GENDER</th>
            <th>HIRE DATE</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
        <?php foreach ($employees as $row): ?>
        <tr>
            <td><?php echo $row->emp_no ?></td>
            <td><?php echo $row->birth_date ?></td>
            <td><?php echo $row->first_name?></td>
            <td><?php echo $row->last_name?></td>
            <td><?php echo $row->gender ?></td>
            <td><?php echo $row->hire_date ?></td>
            <td><a href="?controller=employees&action=verifyupdate&emp_no=<?php echo $row->emp_no?>" class="btn btn-primary btn-xs"> Edit</a></td>
            <td><a href="?controller=employees&action=verifydelete&oD=<?php echo $row->emp_no?>" class="btn btn-danger btn-xs"> Delete</a></td>

        </tr>
        <?php endforeach ?>
    </table>
	</div>
  </div>