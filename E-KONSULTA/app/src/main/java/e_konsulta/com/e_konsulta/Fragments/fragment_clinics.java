package e_konsulta.com.e_konsulta.Fragments;

import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
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
import e_konsulta.com.e_konsulta.Activities.Clinic_Profile;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Activities.Login;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;

/**
 * Created by Royette on 11/23/2015.
 */
public class fragment_clinics extends Fragment implements SwipeRefreshLayout.OnRefreshListener, AdapterView.OnItemClickListener {
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;
    private SwipeRefreshLayout swipeRefreshLayout;

    ListView list_of_clinics;

    ArrayList<HashMap<String, String>> clinic_list;
    SharedPreferences shareduserpref;
    clinics_adapter adapter;
    View root_view;
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView=inflater.inflate(R.layout.clinic_layout,container,false);
        db_retrieve=new DB_retrieve(getActivity());
        db_insert_update=new DB_insert_update(getActivity());
        shareduserpref=getActivity().getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);

        list_of_clinics = (ListView) rootView.findViewById(R.id.list_of_clinics);
        swipeRefreshLayout = (SwipeRefreshLayout) rootView.findViewById(R.id.swipe_refresh_layout);


        swipeRefreshLayout.setOnRefreshListener(this);
        list_of_clinics.setOnItemClickListener(this);
        return rootView;
    }

    @Override
    public void onResume() {
        super.onResume();
        clinic_list=db_retrieve.getAllClinics();
        adapter=new clinics_adapter(getActivity(),R.layout.clinic_list_items,clinic_list);
        list_of_clinics.setAdapter(adapter);
    }

    @Override
    public void onRefresh() {
        swipeRefreshLayout.setRefreshing(true);

        // appending offset to url
        String url ="http://bsit701.com/E-Konsulta/DataRequest.php?last_update=2015-08-04%2012:00:00&&doctor_id="+String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0));
        // Volley's json array request object
        JsonObjectRequest req = new JsonObjectRequest(Request.Method.GET,url,null,
                new Response.Listener<JSONObject>() {

                    @Override
                    public void onResponse(JSONObject jsonObject) {
                        Log.d("clinics",jsonObject.toString());
                        int success = 0;
                        try {
                            success = jsonObject.getInt("success");
                            if(success==1){
                                JSONArray clinics=jsonObject.getJSONArray("clinics");
                                for (int i = 0; i < clinics.length() ; i++) {
                                    JSONObject patient_items = clinics.getJSONObject(i);
                                    int id=Integer.valueOf(patient_items.getString("id"));
                                    ContentValues val=new ContentValues();
                                    val.put(DBHelper.NAME,patient_items.getString("name"));
                                    val.put(DBHelper.ADDRESS,patient_items.getString("address"));
                                    val.put(DBHelper.TEL_NO,patient_items.getString("telephone"));
                                    val.put(DBHelper.CLINIC_SCHEDULE, patient_items.getString("clinic_sched"));
                                    db_insert_update.insertClinic(val, db_insert_update.check_clinic(id),id);
                                }
                                clinic_list=db_retrieve.getAllClinics();
                                adapter=new clinics_adapter(getActivity(),R.layout.clinic_list_items,clinic_list);
                                list_of_clinics.setAdapter(adapter);
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

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        Intent intent=new Intent(getActivity(), Clinic_Profile.class);
        intent.putExtra("clinic_id",clinic_list.get(position).get(DBHelper.CLINIC_ID));
        intent.putExtra("name", clinic_list.get(position).get(DBHelper.NAME));
        intent.putExtra("address",clinic_list.get(position).get(DBHelper.ADDRESS));
        intent.putExtra("telno",clinic_list.get(position).get(DBHelper.TEL_NO));
        intent.putExtra("schedule",clinic_list.get(position).get(DBHelper.CLINIC_SCHEDULE));
        startActivity(intent);
    }
    private class clinics_adapter extends ArrayAdapter {
        LayoutInflater inflater;
        public clinics_adapter(Context context,int resource, ArrayList<HashMap<String, String>> objects) {
            super(context, resource, objects);
            inflater = LayoutInflater.from(context);
        }
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.clinic_list_items,parent, false);
            TextView title = (TextView) vi.findViewById(R.id.clinic_name);
            TextView address = (TextView) vi.findViewById(R.id.address);
            TextView telephone = (TextView) vi.findViewById(R.id.telephone);

            // Setting all values in listview

            title.setText(clinic_list.get(position).get(DBHelper.NAME));
            address.setText(clinic_list.get(position).get(DBHelper.ADDRESS));
            telephone.setText(clinic_list.get(position).get(DBHelper.TEL_NO));
            return vi;
        }

    }
}
