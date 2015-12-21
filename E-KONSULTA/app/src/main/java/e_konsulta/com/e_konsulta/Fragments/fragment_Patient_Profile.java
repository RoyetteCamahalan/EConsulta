package e_konsulta.com.e_konsulta.Fragments;


import android.graphics.Typeface;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;

import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Activities.Patient_Master;
/**
 * Created by Royette on 11/21/2015.
 */
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;

public class fragment_Patient_Profile extends Fragment {
    String fname,mname,lname,mobile,email,tel;
    TextView PatientName,Address,Mobile,Email,Telephone;
    private int patient_id;
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;
    ArrayList<HashMap<String, String>> patient_details;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v=inflater.inflate(R.layout.patient_profile,container,false);
        patient_id=Patient_Master.patient_id;
        Toast.makeText(getActivity(),String.valueOf(patient_id),Toast.LENGTH_SHORT).show();
        db_insert_update=new DB_insert_update(getActivity());
        db_retrieve=new DB_retrieve(getActivity());
        patient_details=db_retrieve.getPatient(patient_id);
        fname=patient_details.get(0).get(DBHelper.FNAME);
        mname=patient_details.get(0).get(DBHelper.MNAME);
        lname=patient_details.get(0).get(DBHelper.LNAME);
        if(mname.length()!=0){
            mname=mname.substring(0,1)+".";
        }
        PatientName= (TextView) v.findViewById(R.id.patient_name);
        Address=(TextView) v.findViewById(R.id.address);
        Mobile= (TextView) v.findViewById(R.id.mobile);
        Email= (TextView) v.findViewById(R.id.email);
        Telephone= (TextView) v.findViewById(R.id.telephone);
        PatientName.setText(fname+" "+mname+" "+lname);
        Address.setText(patient_details.get(0).get(DBHelper.BARANGAY)+", "+patient_details.get(0).get(DBHelper.MUNICIPALITY)+", "+patient_details.get(0).get(DBHelper.PROVINCE)+", "+patient_details.get(0).get(DBHelper.REGION));
        mobile=patient_details.get(0).get(DBHelper.MOBILE_NO);
        tel=patient_details.get(0).get(DBHelper.TEL_NO);
        email=patient_details.get(0).get(DBHelper.EMAIL);
        if(mobile.equals("")||mobile.equals(null)||mobile.equals("null")){
            mobile="N/A";
            Mobile.setTypeface(null,Typeface.BOLD);
        }
        if(tel.equals("")||tel.equals("null")||tel.equals("null")){
            tel="N/A";
            Telephone.setTypeface(null,Typeface.BOLD);
        }
        if(email.equals("")||email.equals(null)||email.equals("null")){
            email="N/A";
            Email.setTypeface(null,Typeface.BOLD);
        }
        Mobile.setText(mobile);
        Telephone.setText(tel);
        Email.setText(email);


        return v;
    }
}
