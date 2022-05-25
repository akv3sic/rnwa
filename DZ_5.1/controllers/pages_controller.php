<?php
  class PagesController {
    public function home() {
      $first_name = 'James';
      $last_name  = 'Harden';
      require_once('views/pages/home.php');
    }

    public function error() {
      require_once('views/pages/error.php');
    }
  }
?>