<?php
 
/*
 * Following code will get single product details
 * A product is identified by product id (pid)
 */
 
// array for JSON response
$response = array();
// include db connect class
if(isset($_GET["last_update"]) && isset($_GET["doctor_id"]))
{
    require_once __DIR__ . '/db_connect.php';
     $last_update=$_GET["last_update"];
     $doctor_id=$_GET["clinic_id"];
    // connecting to db
    $db = new DB_CONNECT();
    $response["patient"] = array();
    $response["appointments"] = array();
    $response["last_update"] = array();
    $checker=0;
    $result = mysql_query("SELECT c.`id`, c.`fname`, c.`mname`, c.`lname`,c.`mobile_no`, c.`tel_no`,c.`photo`, c.`occupation`, c.`birthdate`,
                             c.`sex`, c.`civil_status`, c.`height`, c.`weight`,c.`optional_address`,c.`address_barangay_id`,  b.`name`,m.`name`,p.`name`,r.`name`, 
                             c.`created_at`, c.`updated_at`, c.`deleted_at` FROM regions r INNER JOIN provinces p on p.`region_id`=r.`id` 
                             INNER JOIN municipalities m on m.`province_id`=p.`id` INNER JOIN barangays b on b.`municipality_id`=m.`id` 
                             INNER JOIN clinic_patients c on c.`address_barangay_id`=b.`id` 
                             WHERE (c.`created_at`>'$last_update' OR c.`updated_at`>'$last_update')");
     
    if (!empty($result)) {
            // check for empty result
            if (mysql_num_rows($result) > 0) {
                    $checker=1;
                    while ($row= mysql_fetch_array($result)) {
                        $patient= array();
                        $patient["id"]  =$row[0];
                        $patient["fname"]= $row[1];
                        $patient["mname"]= $row[2];
                        $patient["lname"] = $row[3];
                        $patient["mobile_no"]  = $row[4];
                        $patient["tel_no"]  =$row[5];
                        $patient["photo"]= $row[6];
                        $patient["occupation"] = $row[7];
                        $patient["birthdate"]=$row[8];
                        $patient["sex"] = $row[9];
                        $patient["civil_status"]=$row[10];
                        $patient["height"]  = $row[11];
                        $patient["weight"]  = $row[12];
                        $patient["optional_address"] = $row[13];
                        $patient["barangay_id"]=$row[14];
                        $patient["barangay_name"]  = $row[15];
                        $patient["municipality_name"]  = $row[16];
                        $patient["province_name"]  = $row[17];
                        $patient["region_name"]  = $row[18];
                        $patient["created_at"]  = $row[19];
                        $patient["updated_at"]  = $row[20];
                        array_push($response["patient"], $patient);
                    }
     
                // echoing JSON response
                
                    
            } 
        }
    //get last_update
    if($checker==1){
        $response["success"] = 1;
        $result = mysql_query("SELECT CURRENT_TIMESTAMP");
     
        if (!empty($result)) {
                // check for empty result
                if (mysql_num_rows($result) > 0) {
                        
                        while ($row= mysql_fetch_array($result)) {
                            $new_last_update= array();
                            $new_last_update["new_last_update"]  =$row[0];
                            array_push($response["last_update"], $new_last_update);
                        }
                } 
            }
        
    }
    else{
        $response["success"] = 0;
    }
    echo json_encode($response);
}

    
?>