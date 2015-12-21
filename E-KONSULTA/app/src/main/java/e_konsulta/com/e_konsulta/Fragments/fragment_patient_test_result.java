package e_konsulta.com.e_konsulta.Fragments;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import e_konsulta.com.e_konsulta.R;
/**
 * Created by Royette on 11/21/2015.
 */
public class fragment_patient_test_result extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v=inflater.inflate(R.layout.patient_test_result,container,false);
        return v;
    }
}
