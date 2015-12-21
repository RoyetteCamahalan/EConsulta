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
     $doctor_id=$_GET["doctor_id"];
    // connecting to db
    $db = new DB_CONNECT();
    $response["clinics"] = array();
    $response["appointments"] = array();
    $response["secretaries"] = array();
    $response["last_update"] = array();
    $checker=0;
    $result = mysql_query("SELECT c.`id` , c.`name` , c.`contact_no` ,  '150 5th-A St., Ecoland Ph1, Matina, Davao City' AS  'address', cd.clinic_sched FROM clinics c INNER JOIN clinic_doctor cd ON cd.clinic_id = c.id WHERE cd.doctor_id =$doctor_id");
     
    if (!empty($result)) {
            // check for empty result
            if (mysql_num_rows($result) > 0) {
                    $checker=1;
                    while ($row= mysql_fetch_array($result)) {
                        $clinics= array();
                        $clinics["id"]  =$row[0];
                        $clinics["name"]= $row[1];
                        $clinics["telephone"] = $row[2];
                        $clinics["address"]= $row[3];
                        $clinics["clinic_sched"] = $row[4];
                        array_push($response["clinics"], $clinics);
                    }
     
                // echoing JSON response
                
                    
            } 
        }
    $result = mysql_query("SELECT c.`id` , cpd.`clinic_patients_id`, c.`clinic_id` , c.`date` , c.`time` , c.`is_approved` , c.`comment_doctor` , c.`patient_is_approved` , c.`comment_patient` , c.`created_at` 
                            FROM  `consultations` c
                            INNER JOIN clinic_patient_doctor cpd ON cpd.`patient_id` = c.`patient_id` 
                            WHERE c.`doctor_id` =$doctor_id AND (c.`created_at`>'$last_update' OR c.`updated_at`>'$last_update')");
     
    if (!empty($result)) {
            // check for empty result
            if (mysql_num_rows($result) > 0) {
                    $checker=1;
                    while ($row= mysql_fetch_array($result)) {
                        $appointments= array();
                        $appointments["id"]  =$row[0];
                        $appointments["clinic_patients_id"]= $row[1];
                        $appointments["clinic_id"]= $row[2];
                        $appointments["date"] = $row[3];
                        $appointments["time"]  =$row[4];
                        $appointments["is_approved"]= $row[5];
                        $appointments["comment_doctor"]= $row[6];
                        $appointments["patient_is_approved"] = $row[7];
                        $appointments["comment_patient"] = $row[8];
                        $appointments["created_at"] = $row[9];
                        array_push($response["appointments"], $appointments);
                    }
     
                // echoing JSON response
                
                    
            } 
        }
        $result = mysql_query("SELECT c.`id` , c.`fname` , c.`mname` , c.`lname` , c.`cell_no` , c.`tel_no`, c.`email`, c.`photo` , c.`optional_address` , c.`barangay_id` , b.`name` , m.`name` , p.`name` , r.`name` ,ds.`username`,ds.`password`,ds.`is_active`, c.`created_at` , c.`updated_at` 
                                FROM regions r
                                INNER JOIN provinces p ON p.`region_id` = r.`id` 
                                INNER JOIN municipalities m ON m.`province_id` = p.`id` 
                                INNER JOIN barangays b ON b.`municipality_id` = m.`id` 
                                INNER JOIN secretaries c ON c.`barangay_id` = b.`id` 
                                INNER JOIN doctor_secretary ds ON c.`id` = ds.`secretary_id`
                                WHERE ds.`doctor_id`=$doctor_id AND (c.`created_at`>'$last_update' OR c.`updated_at`>'$last_update')");
         
        if (!empty($result)) {
                // check for empty result
                if (mysql_num_rows($result) > 0) {
                        $checker=1;
                        while ($row= mysql_fetch_array($result)) {
                            $secretaries= array();
                            $secretaries["id"]  =$row[0];
                            $secretaries["fname"]= $row[1];
                            $secretaries["mname"]= $row[2];
                            $secretaries["lname"] = $row[3];
                            $secretaries["cell_no"]  = $row[4];
                            $secretaries["tel_no"]  =$row[5];
                            $secretaries["email"]  =$row[6];
                            $secretaries["photo"]= $row[7];
                            $secretaries["optional_address"] = $row[8];
                            $secretaries["barangay_id"]=$row[9];
                            $secretaries["barangay_name"]  = $row[10];
                            $secretaries["municipality_name"]  = $row[11];
                            $secretaries["province_name"]  = $row[12];
                            $secretaries["region_name"]  = $row[13];
                            $secretaries["username"]  = $row[14];
                            $secretaries["password"]  = $row[15];
                            $secretaries["is_active"]  = $row[16];
                            $secretaries["created_at"]  = $row[17];
                            $secretaries["updated_at"]  = $row[18];
                            array_push($response["secretaries"], $secretaries);
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