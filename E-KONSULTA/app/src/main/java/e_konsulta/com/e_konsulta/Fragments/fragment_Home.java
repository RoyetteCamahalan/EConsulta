package e_konsulta.com.e_konsulta.Fragments;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.ListView;

import e_konsulta.com.e_konsulta.Activities.BMI_Calculator;
import e_konsulta.com.e_konsulta.Activities.MainActivity;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Activities.User_Profile_Master_Tab;

/**
 * Created by Royette on 11/27/2015.
 */
public class fragment_Home extends Fragment implements View.OnClickListener {

    ListView drawer;
    ImageView img_profile,img_patient,img_outpatient,img_appointments,img_secretary,img_clinic,img_bmi;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View vi=inflater.inflate(R.layout.home_layout,container,false);
        img_profile= (ImageView) vi.findViewById(R.id.img_profile);
        img_patient= (ImageView) vi.findViewById(R.id.img_patient);
        img_outpatient= (ImageView) vi.findViewById(R.id.img_outpatients);
        img_appointments= (ImageView) vi.findViewById(R.id.img_appointments);
        img_secretary= (ImageView) vi.findViewById(R.id.img_secretary);
        img_clinic= (ImageView) vi.findViewById(R.id.img_clinic);
        img_bmi= (ImageView) vi.findViewById(R.id.img_calculator);
        img_profile.setOnClickListener(this);
        img_patient.setOnClickListener(this);
        img_outpatient.setOnClickListener(this);
        img_appointments.setOnClickListener(this);
        img_secretary.setOnClickListener(this);
        img_clinic.setOnClickListener(this);
        img_bmi.setOnClickListener(this);
        drawer=MainActivity.mDrawerList;
        return vi;
    }

    @Override
    public void onClick(View v) {
        Fragment fragment=null;
        String title="";
        int position=0;
        switch (v.getId()){
            case R.id.img_profile:
                position=0;
                Intent intent_profile=new Intent(getActivity(),User_Profile_Master_Tab.class);
                startActivity(intent_profile);
                break;
            case R.id.img_patient:
                position=2;
                title="Patients";
                fragment=new fragment_Patients();
                break;
            case R.id.img_outpatients:

                break;
            case R.id.img_appointments:
                position=4;
                title="Appointments";
                fragment=new fragment_appointments();
                break;
            case R.id.img_secretary:
                position=5;
                title="Secretaries";
                fragment=new fragment_secretaries();
                break;
            case R.id.img_clinic:
                position=6;
                title="Clinics";
                fragment=new fragment_clinics();
                break;
            case R.id.img_calculator:
                Intent intent=new Intent(getActivity(), BMI_Calculator.class);
                startActivity(intent);
                break;
        }
        if(fragment!=null){
            drawer.setItemChecked(position, true);
            drawer.setSelection(position);
            getActivity().setTitle(title);
            FragmentManager fragmentManager = getFragmentManager();
            fragmentManager.beginTransaction().replace(R.id.frame_container,fragment).commit();
        }
    }
}
