<?php
	
$response = array();
// include db connect class
if(isset($_GET["doctor_id"]) && isset($_GET["action_type"])){
	require_once __DIR__ . '/db_connect.php';
    $db = new DB_CONNECT();
	$action_type=$_GET["action_type"];
	$doctor_id=$_GET["doctor_id"] ;
	switch ($action_type) {
//login
		case 1:
			$result = mysql_query("SELECT d.`id` , d.`fname` , d.`mname` , d.`lname` , d.`prc_no` , s.`name` FROM  `doctors` d INNER JOIN sub_specialties s ON d.`sub_specialty_id` = s.`id`  where d.username='".$_GET["uname"]."' and d.password='".$_GET["pword"]."'");
			if (!empty($result)) {
            // check for empty result
	            if (mysql_num_rows($result) > 0) {
	                $response["success"] = 1;  
	                $response["doctor_profile"] = array();
	                while ($row= mysql_fetch_array($result)) {
                        $doctor_profile= array();
                        $doctor_profile["id"]  =$row[0];
                        $doctor_profile["fname"]= $row[1];
                        $doctor_profile["mname"]= $row[2];
                        $doctor_profile["lname"] = $row[3];
                        $doctor_profile["prc_no"] = $row[4];
                        $doctor_profile["specialty"] = $row[5];
                        array_push($response["doctor_profile"], $doctor_profile);
                    }         
	            } else{
	            	$response["success"] = 0;
	            }
        	}
        	else {
        		$response["success"] = 0;
        	}
			break;
		
		default:
			# code...
			break;
//getsecretaries
		case 2:
			$result = mysql_query("SELECT c.`id` , c.`fname` , c.`mname` , c.`lname` , c.`cell_no` , c.`tel_no` , c.`email` , c.`photo` , c.`address_house_no` , c.`address_street` , c.`barangay_id` , b.`name` , m.`name` , p.`name` , r.`name`
									FROM regions r
									INNER JOIN provinces p ON p.`region_id` = r.`id` 
									INNER JOIN municipalities m ON m.`province_id` = p.`id` 
									INNER JOIN barangays b ON b.`municipality_id` = m.`id` 
									INNER JOIN secretaries c ON c.`barangay_id` = b.`id` 
									WHERE NOT EXISTS (SELECT d.`secretary_id`
														FROM doctor_secretary d
														WHERE d.`doctor_id` =$doctor_id 
														AND d.`secretary_id` = c.`id`)");
         
        if (!empty($result)) {
                // check for empty result
                if (mysql_num_rows($result) > 0) {
                        $response["secretaries"] = array();
                        $response["success"] = 1;
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
                            if($row[8]!=""){
                            	$secretaries["optional_address"] = $row[8].", ".$row[9];
                            }else{
                            	$secretaries["optional_address"] = $row[8];
                            }
                            
                            $secretaries["barangay_id"]=$row[10];
                            $secretaries["barangay_name"]  = $row[11];
                            $secretaries["municipality_name"]  = $row[12];
                            $secretaries["province_name"]  = $row[13];
                            $secretaries["region_name"]  = $row[14];
                            array_push($response["secretaries"], $secretaries);
                        }
         
                    // echoing JSON response
                    
                        
                } else{
	            	$response["success"] = 0;
	            }
        	}
        	else {
        		$response["success"] = 0;
        	}
			break;
//check username and password
		case 3:
			if($_GET["sub_action"]==0){
				$result = mysql_query("SELECT `username`, `password` FROM `doctor_secretary` WHERE `username`='".$_GET["username"]."' AND `password`='".$_GET["password"]."'");
         		if (!empty($result)) {
                // check for empty result
               	 	if (mysql_num_rows($result) > 0) {
                        $response["success"] = 1;
                    }else{
	            		$response["success"] = 0;
	            	}
        		}
        		else {
        			$response["success"] = 0;
        		}
			}
			break;	

	}
	echo json_encode($response);
}
?>