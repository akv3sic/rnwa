<?php

if(!extension_loaded("soap")){
    dl("php_soap.dll");
}

ini_set("soap.wsdl_chache_enabled", "0");

$server = new SoapServer("specifikacija.wsdl");

function converter($cur,  $val){
        
        if($cur == "bameur"){
            return $val * 0.51 . " EUR";

        }
        if($cur=="bamchf"){
            return $val * 0.53 . " CHF";

        }

        if($cur == "eurbam"){
            return $val * 1.95 . " BAM";

        }
        if($cur=="eurchf"){
            return $val * 1.03 . " CHF";

        }
        if($cur == "chfbam"){
            return $val * 1.90 . " BAM";

        }
        if($cur=="chfeur"){
            return $val * 0.97 . " EUR";

        }

}
    



$server->AddFunction("converter");
$server->handle();





?>