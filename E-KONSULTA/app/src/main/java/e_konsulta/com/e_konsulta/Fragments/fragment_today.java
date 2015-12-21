package e_konsulta.com.e_konsulta.Fragments;

import android.content.ContentValues;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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

import e_konsulta.com.e_konsulta.Activities.Login;
import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;

/**
 * Created by Royette on 11/23/2015.
 */
public class fragment_today extends Fragment implements SwipeRefreshLayout.OnRefreshListener {

    ArrayList<HashMap<String, String>> appointment_list;
    TextView noAppointmentFound;
    ListView lst_today;
    private SwipeRefreshLayout swipeRefreshLayout;
    private Appointments_adapter adapter;
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;

    SharedPreferences shareduserpref;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v=inflater.inflate(R.layout.today_layout,container,false);
        db_retrieve=new DB_retrieve(getActivity());
        db_insert_update=new DB_insert_update(getActivity());
        lst_today= (ListView) v.findViewById(R.id.list_of_appointments);
        noAppointmentFound = (TextView) v.findViewById(R.id.noUserFound);
        swipeRefreshLayout = (SwipeRefreshLayout) v.findViewById(R.id.swipe_refresh_layout);
        swipeRefreshLayout.setOnRefreshListener(this);
        shareduserpref=getActivity().getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        appointment_list=db_retrieve.getAllAppointments(1);
        Log.d("appointments", String.valueOf(appointment_list.size()));
        adapter=new Appointments_adapter(getActivity(),R.layout.today_list_items,appointment_list);
        lst_today.setAdapter(adapter);
    }

    @Override
    public void onRefresh() {
        swipeRefreshLayout.setRefreshing(true);

        // appending offset to url
        String url ="http://bsit701.com/E-Konsulta/DataRequest.php?last_update=2015-08-04%2012:00:00&&doctor_id="+Integer.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0));
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
                                JSONArray patients=jsonObject.getJSONArray("appointments");
                                for (int i = 0; i < patients.length() ; i++) {
                                    JSONObject patient_items = patients.getJSONObject(i);
                                    int id=Integer.valueOf(patient_items.getString("id"));
                                    ContentValues val=new ContentValues();
                                    val.put(DBHelper.PATIENT_ID,Integer.valueOf(patient_items.getString("clinic_patients_id")));
                                    val.put(DBHelper.CLINIC_ID,Integer.valueOf(patient_items.getString("clinic_id")));
                                    val.put(DBHelper.DATE,patient_items.getString("date"));
                                    val.put(DBHelper.TIME,patient_items.getString("time"));
                                    val.put(DBHelper.IS_APPROVED,Integer.valueOf(patient_items.getString("is_approved")));
                                    val.put(DBHelper.COMMENT_DOCTOR,patient_items.getString("comment_doctor"));
                                    val.put(DBHelper.PATIENT_IS_APPROVED,Integer.valueOf(patient_items.getString("patient_is_approved")));
                                    val.put(DBHelper.PATIENT_COMMENT,patient_items.getString("comment_patient"));
                                    val.put(DBHelper.CREATED_AT,patient_items.getString("created_at"));
                                    Log.d("patients", String.valueOf(db_insert_update.insertAppointment(val, db_insert_update.check_appointment(id), id)));
                                }
                                appointment_list=db_retrieve.getAllAppointments(1);
                                adapter=new Appointments_adapter(getActivity(),R.layout.today_list_items,appointment_list);
                                lst_today.setAdapter(adapter);
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

    private class Appointments_adapter extends ArrayAdapter {

        LayoutInflater inflater;
        public Appointments_adapter(Context context,int resource, ArrayList<HashMap<String, String>> objects) {
            super(context, resource, objects);
            inflater = LayoutInflater.from(context);
        }
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.today_list_items,parent, false);
            TextView title = (TextView) vi.findViewById(R.id.patient_name); // title
            TextView details = (TextView) vi.findViewById(R.id.details); // artist name
            TextView details_time = (TextView) vi.findViewById(R.id.details_time);
            // Setting all values in listview

            title.setText(appointment_list.get(position).get("FULLNAME"));
            details.setText(appointment_list.get(position).get(DBHelper.NAME));
            details_time.setText(appointment_list.get(position).get(DBHelper.TIME));
            return vi;
        }

    }
}
