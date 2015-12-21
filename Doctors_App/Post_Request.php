<?php

$response = array();
if(isset($_POST["action_type"]))
{
    require_once __DIR__ . '/db_connect.php';
    $db = new DB_CONNECT();
    $action_type=$_POST["action_type"];
    switch ($action_type) {
//add new secretary
        case 1:
            $username=$_POST["username"];
            $password=$_POST["password"];
            //check if username and password already in use
            $result = mysql_query("SELECT `username`, `password` FROM `doctor_secretary` WHERE `username`='$username' AND `password`='$password'");

            //check if result is empty.
            if (empty($result)||mysql_num_rows($result) == 0) {
                //result is not empty
                if($_POST["sub_action"]==0){

                    //insert new secretary
                    $fname=$_POST["fname"];
                    $mname=$_POST["mname"];
                    $lname=$_POST["lname"];
                    $email=$_POST["email"];
                    $doctor_id=$_POST["doctor_id"];
                    $is_allowed=$_POST["is_allowed"];
                    $result = mysql_query("INSERT INTO `secretaries`(`fname`, `mname`, `lname`,`barangay_id`, `email`, `created_at`) 
                        VALUES ('$fname','$mname','$lname',1,'$email',CURRENT_TIMESTAMP)");
                    if ($result) {
                        //if success in inserting
                        $secretary_id=mysql_insert_id();//get id of last inserted
                        //insert to doctor_secretary table
                        $result = mysql_query("INSERT INTO `doctor_secretary`(`doctor_id`, `secretary_id`, `is_active`, `username`, `password`, `created_at`) VALUES ($doctor_id,$secretary_id,$is_allowed,'$username','$password',CURRENT_TIMESTAMP)");
                        //if success in inserting
                        if ($result) {
                            $response["secretary_id"]=$secretary_id;
                            $response["success"] = 1;
                        }else{//if not
                            $response["success"] = 0;
                        }
                    }else{
                        $response["success"] = 0;
                    }
                }else{
                    //insert only in doctor_secretary table
                    $secretary_id=$_POST["secretary_id"];
                    $doctor_id=$_POST["doctor_id"];
                    $is_allowed=$_POST["is_allowed"];
                    $result = mysql_query("INSERT INTO `doctor_secretary`(`doctor_id`, `secretary_id`, `is_active`, `username`, `password`, `created_at`) VALUES ($doctor_id,$secretary_id,$is_allowed,'$username','$password',CURRENT_TIMESTAMP)");
                    if ($result) {
                        $response["success"] = 1;
                    }else{
                        $response["success"] = 0;
                    }
                }

            }else{
                $response["success"] = 2;
            }  
            break;
//Update secretary
        case 2:
            $sub_action=$_POST["sub_action"];
            $secretary_id=$_POST["secretary_id"];
            $doctor_id=$_POST["doctor_id"];
            if($sub_action==0){
                //deactivate secretary
                $is_active=$_POST["is_active"];
                $result = mysql_query("update `doctor_secretary` SET `is_active`=$is_active WHERE `doctor_id`=$doctor_id AND `secretary_id`=$secretary_id");
                if ($result) {
                    $response["success"] = 1;
                }else{
                    $response["success"] = 0;
                }
            }else if($sub_action==1){
                //change secretary password
                $username=$_POST["username"];
                $password=$_POST["password"];

                $result = mysql_query("SELECT `username`, `password` FROM `doctor_secretary` WHERE `username`='$username' AND `password`='$password'");
                //check if result is empty.
                if (empty($result)||mysql_num_rows($result) == 0) {
                    $result = mysql_query("update `doctor_secretary` SET `password`='$password' WHERE `doctor_id`=$doctor_id AND `secretary_id`=$secretary_id");
                        if ($result) {
                            $response["success"] = 1;
                        }else{
                            $response["success"] = 0;
                        }
                }else{
                    $response["success"] = 2;
                }
                
            }else if($sub_action==2){
                //change secretary password
                $username=$_POST["username"];
                $password=$_POST["password"];
                $result = mysql_query("SELECT `username`, `password` FROM `doctor_secretary` WHERE `username`='$username' AND `password`='$password'");
                //check if result is empty.
                if (empty($result)||mysql_num_rows($result) == 0) {
                    $result = mysql_query("update `doctor_secretary` SET `username`='$username' WHERE `doctor_id`=$doctor_id AND `secretary_id`=$secretary_id");
                        if ($result) {
                            $response["success"] = 1;
                        }else{
                            $response["success"] = 0;
                        }
                }else{
                    $response["success"] = 2;
                }
                
                
            }
            break;
        
        case 3:

            break;
        default:
            
            break;
    }
    echo json_encode($response);
}
    
?>