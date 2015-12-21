package e_konsulta.com.e_konsulta.Fragments;

import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.provider.SyncStateContract;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SwipeRefreshLayout;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Activities.MainActivity;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Activities.Patient_Master;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;

/**
 * Created by Royette on 11/20/2015.
 */
public class fragment_Patients extends Fragment implements AdapterView.OnItemClickListener, TextWatcher, SwipeRefreshLayout.OnRefreshListener {
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;
    private SwipeRefreshLayout swipeRefreshLayout;

    ListView list_of_patients;
    EditText search_patient;
    TextView noUserFound;

    ArrayList<HashMap<String, String>> searchPatients;
    ArrayList<HashMap<String, String>> patient_items_orig;

    String s_patient;
    patients_adapter adapter;
    SyncStateContract.Helpers helpers;
    SharedPreferences shared_last_update;
    View root_view;
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView=inflater.inflate(R.layout.patient_layout,container,false);
        root_view = rootView;
        shared_last_update=getActivity().getSharedPreferences(MainActivity.str_shared_lastupdate,Context.MODE_PRIVATE);
        db_retrieve=new DB_retrieve(getActivity());
        db_insert_update=new DB_insert_update(getActivity());

        patient_items_orig=new ArrayList<>();
        searchPatients=new ArrayList<>();

        search_patient = (EditText) rootView.findViewById(R.id.search_patient);
        noUserFound = (TextView) rootView.findViewById(R.id.noUserFound);
        list_of_patients = (ListView) rootView.findViewById(R.id.list_of_patients);
        swipeRefreshLayout = (SwipeRefreshLayout) rootView.findViewById(R.id.swipe_refresh_layout);

        patient_items_orig= db_retrieve.getAllPatients();
        searchPatients.addAll(patient_items_orig);
        populateDoctorListView(rootView);
        swipeRefreshLayout.setOnRefreshListener(this);
        list_of_patients.setOnItemClickListener(this);
        search_patient.addTextChangedListener(this);
        return rootView;
    }

    public void populateDoctorListView(View rootView) {
        Log.d("patients", String.valueOf(searchPatients.size()));
        adapter = new patients_adapter(getActivity(),R.layout.list_patient_items, searchPatients);

        list_of_patients.setAdapter(adapter);



    }

    @Override

    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        Intent intent=new Intent(getActivity(),Patient_Master.class);

        intent.putExtra("patient_id",Integer.valueOf(searchPatients.get(position).get(DBHelper.AI_ID)));
        startActivity(intent);
    }

    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {

    }

    @Override
    public void onTextChanged(CharSequence s, int start, int before, int count) {

    }

    @Override
    public void afterTextChanged(Editable s) {
        searchPatients.clear();
        searchPatients.addAll(patient_items_orig);

        if (!s_patient.equals("")) {
            for (int i = searchPatients.size()-1; i >= 0; i--) {
                String playerName=searchPatients.get(i).get("fullname").toString();

                if(s_patient.length()<=playerName.length()){
                    //compare the String in EditText with Names in the ArrayList

                    if(!playerName.toLowerCase().contains(s_patient.toLowerCase())){
                        searchPatients.remove(i);
                    }

                }
            }

            if (searchPatients.size() == 0) {
                noUserFound.setVisibility(View.VISIBLE);
                list_of_patients.setVisibility(View.GONE);
            }else {
                noUserFound.setVisibility(View.GONE);
                list_of_patients.setVisibility(View.VISIBLE);
                populateDoctorListView(root_view);
                adapter.notifyDataSetChanged();
            }

        } else {
            noUserFound.setVisibility(View.GONE);
            list_of_patients.setVisibility(View.VISIBLE);
            populateDoctorListView(root_view);
            adapter.notifyDataSetChanged();
        }
    }

    @Override
    public void onRefresh() {
        fetchpatients();
    }
    private void fetchpatients() {

        // showing refresh animation before making http call
        swipeRefreshLayout.setRefreshing(true);

        // appending offset to url
        String url ="http://bsit701.com/E-Konsulta/sample.php?last_update=2015-08-04%2012:00:00&&doctor_id=1";
        // Volley's json array request object
        JsonObjectRequest req = new JsonObjectRequest(Request.Method.GET,url,null,
                new Response.Listener<JSONObject>() {

                    @Override
                    public void onResponse(JSONObject jsonObject) {
                        Log.d("patients", jsonObject.toString());

                        int success = 0;
                        try {
                            success = jsonObject.getInt("success");
                            if(success==1){
                                JSONArray patients=jsonObject.getJSONArray("patient");
                                for (int i = 0; i < patients.length() ; i++) {
                                    JSONObject patient_items = patients.getJSONObject(i);
                                    int id=Integer.valueOf(patient_items.getString("id"));
                                    ContentValues val=new ContentValues();
                                    val.put(DBHelper.FNAME,patient_items.getString("fname"));
                                    val.put(DBHelper.MNAME,patient_items.getString("mname"));
                                    val.put(DBHelper.LNAME,patient_items.getString("lname"));
                                    val.put(DBHelper.MOBILE_NO,patient_items.getString("mobile_no"));
                                    val.put(DBHelper.TEL_NO,patient_items.getString("tel_no"));
                                    val.put(DBHelper.PHOTO,patient_items.getString("photo"));
                                    val.put(DBHelper.PTNT_OCCUPATION,patient_items.getString("occupation"));
                                    val.put(DBHelper.PTNT_BIRTHDATE,patient_items.getString("birthdate"));
                                    val.put(DBHelper.PTNT_SEX,patient_items.getString("sex"));
                                    val.put(DBHelper.PTNT_CIVIL_STATUS,patient_items.getString("civil_status"));
                                    val.put(DBHelper.PTNT_HEIGHT,patient_items.getString("height"));
                                    val.put(DBHelper.PTNT_WEIGHT,patient_items.getString("weight"));
                                    val.put(DBHelper.OPTIONAL_ADDRESS,patient_items.getString("optional_address"));
                                    val.put(DBHelper.BRGY_ID,Integer.valueOf(patient_items.getString("barangay_id")));
                                    val.put(DBHelper.EMAIL,"");
                                    val.put(DBHelper.BARANGAY,patient_items.getString("barangay_name"));
                                    val.put(DBHelper.MUNICIPALITY,patient_items.getString("municipality_name"));
                                    val.put(DBHelper.PROVINCE,patient_items.getString("province_name"));
                                    val.put(DBHelper.REGION,patient_items.getString("region_name"));
                                    val.put(DBHelper.CREATED_AT, patient_items.getString("created_at"));
                                    val.put(DBHelper.UPDATED_AT, patient_items.getString("updated_at"));
                                    Log.d("patients", String.valueOf(db_insert_update.insertPatient(val, db_insert_update.check_patient(id), id)));
                                }
                                patient_items_orig.clear();
                                patient_items_orig = db_retrieve.getAllPatients();
                                searchPatients.clear();
                                searchPatients.addAll(patient_items_orig);
                                populateDoctorListView(root_view);
                                adapter.notifyDataSetChanged();
                            }
                            else {

                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        // stopping swipe refresh
                        swipeRefreshLayout.setRefreshing(false);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("patients", "Server Error: " + error.getMessage());

                Toast.makeText(getActivity(), error.getMessage(), Toast.LENGTH_LONG).show();

                // stopping swipe refresh
                swipeRefreshLayout.setRefreshing(false);
            }
        });

        // Adding request to request queue
        AppController.getInstance().addToRequestQueue(req);
    }
    private class patients_adapter extends ArrayAdapter{

        LayoutInflater inflater;
        public patients_adapter(Context context,int resource, ArrayList<HashMap<String, String>> objects) {
            super(context, resource, objects);
            inflater = LayoutInflater.from(context);
        }
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.list_patient_items,parent, false);
            TextView title = (TextView) vi.findViewById(R.id.title); // title
            TextView details = (TextView) vi.findViewById(R.id.details); // artist name

            // Setting all values in listview

            title.setText(searchPatients.get(position).get("fullname"));
            details.setText(searchPatients.get(position).get("details"));
            return vi;
        }

    }



}
