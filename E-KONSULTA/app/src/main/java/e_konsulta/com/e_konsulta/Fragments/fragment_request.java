package e_konsulta.com.e_konsulta.Fragments;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.TimePickerDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.NotificationCompat;
import android.support.v4.app.TaskStackBuilder;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.TimePicker;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;

import e_konsulta.com.e_konsulta.Activities.Login;
import e_konsulta.com.e_konsulta.Activities.MainActivity;
import e_konsulta.com.e_konsulta.NavDrawerItem;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;
import e_konsulta.com.e_konsulta.Tools.Helpers;
import e_konsulta.com.e_konsulta.Tools.URLS;

/**
 * Created by Royette on 12/2/2015.
 */
public class fragment_request extends Fragment implements SwipeRefreshLayout.OnRefreshListener, TimePickerDialog.OnTimeSetListener {
    ArrayList<HashMap<String, String>> appointment_list;
    TextView noAppointmentFound;
    ListView lst_request;
    private SwipeRefreshLayout swipeRefreshLayout;
    private Appointments_adapter adapter;
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;
    Helpers helper;

    SharedPreferences shareduserpref;

    Dialog set_time_comment;
    EditText ET_time,ET_comment;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v=inflater.inflate(R.layout.today_layout,container,false);
        db_insert_update=new DB_insert_update(getActivity());
        db_retrieve=new DB_retrieve(getActivity());
        helper=new Helpers();
        lst_request = (ListView) v.findViewById(R.id.list_of_appointments);
        noAppointmentFound = (TextView) v.findViewById(R.id.noUserFound);
        swipeRefreshLayout = (SwipeRefreshLayout) v.findViewById(R.id.swipe_refresh_layout);
        swipeRefreshLayout.setOnRefreshListener(this);
        shareduserpref=getActivity().getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        appointment_list=db_retrieve.getAllAppointments(3);
        Log.d("appointments", String.valueOf(appointment_list.size()));
        adapter=new Appointments_adapter(getActivity(),R.layout.today_list_items,appointment_list);
        lst_request.setAdapter(adapter);
    }

    @Override
    public void onRefresh() {
        swipeRefreshLayout.setRefreshing(true);

        // appending offset to url
        String url = URLS.URL_Request+String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0)+"&&last_update=2015-08-04%2012:00:00");
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
                                int counter=0;
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
                                    val.put(DBHelper.PATIENT_COMMENT, patient_items.getString("comment_patient"));
                                    val.put(DBHelper.CREATED_AT, patient_items.getString("created_at"));
                                    int checker=db_insert_update.check_appointment(id);
                                    if(checker==0){
                                        counter++;
                                    }
                                    Log.d("patients", String.valueOf(db_insert_update.insertAppointment(val, checker, id)));
                                }
                                if(counter>0){
                                    NotificationCompat.Builder mBuilder=new NotificationCompat.Builder(getActivity())
                                            .setSmallIcon(R.drawable.ic_appointments)
                                            .setContentTitle("EConsulta")
                                            .setContentText("You have "+counter+" appointment request");
                                    Intent intent1=new Intent(getActivity(),MainActivity.class);
                                    intent1.putExtra("checker", 1);
                                    TaskStackBuilder stackbuilder=TaskStackBuilder.create(getActivity());
                                    stackbuilder.addParentStack(MainActivity.class);
                                    stackbuilder.addNextIntent(intent1);
                                    PendingIntent resultpendingintent=stackbuilder.getPendingIntent(0, PendingIntent.FLAG_UPDATE_CURRENT);
                                    mBuilder.setContentIntent(resultpendingintent);
                                    mBuilder.setAutoCancel(true);
                                    NotificationManager mNotificationManager =
                                            (NotificationManager) getActivity().getSystemService(Context.NOTIFICATION_SERVICE);
                                    mNotificationManager.notify(10001, mBuilder.build());
                                }

                                appointment_list=db_retrieve.getAllAppointments(3);
                                adapter=new Appointments_adapter(getActivity(),R.layout.today_list_items,appointment_list);
                                lst_request.setAdapter(adapter);
                                adapter.notifyDataSetChanged();
                                helper.refresh_drawer_counter(db_retrieve.getcounter(),getActivity());
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

                Toast.makeText(getActivity(), error.getMessage(), Toast.LENGTH_LONG).show();

                // stopping swipe refresh
                swipeRefreshLayout.setRefreshing(false);
            }
        });

        // Adding request to request queue
        AppController.getInstance().addToRequestQueue(req);
    }
    @Override
    public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
        String strTime = "";

        if (hourOfDay > 12) {
            strTime = strTime + String.format("%02d", (hourOfDay - 12)) + ":" + String.format("%02d", minute) + " PM";
        } else if (hourOfDay == 12 && minute > 0) {
            strTime = strTime + String.format("%02d", hourOfDay) + ":" + String.format("%02d", minute) + " PM";
        } else if (hourOfDay == 0) {
            strTime = strTime + String.format("%02d", (hourOfDay + 12)) + ":" + String.format("%02d", minute) + " AM";
        } else {
            strTime = strTime + String.format("%02d", hourOfDay) + ":" + String.format("%02d", minute) + " AM";
        }

        ET_time.setText(strTime);
    }


    private class Appointments_adapter extends ArrayAdapter {

        Button save;
        LayoutInflater inflater;
        public Appointments_adapter(Context context,int resource, ArrayList<HashMap<String, String>> objects) {
            super(context, resource, objects);
            inflater = LayoutInflater.from(context);
        }
        @Override
        public View getView(final int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.appointment_request_item,parent, false);
            TextView title = (TextView) vi.findViewById(R.id.patient_name); // title
            TextView details = (TextView) vi.findViewById(R.id.details); // artist name
            TextView details_time = (TextView) vi.findViewById(R.id.details_time);
            TextView txt_confirm= (TextView) vi.findViewById(R.id.txt_confirm);
            TextView txt_decline= (TextView) vi.findViewById(R.id.txt_decline);
            // Setting all values in listview

            title.setText(appointment_list.get(position).get("FULLNAME"));
            details.setText(appointment_list.get(position).get(DBHelper.NAME));
            details_time.setText(appointment_list.get(position).get(DBHelper.TIME));
            txt_confirm.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    set_time_comment = new Dialog(getActivity());
                    set_time_comment.setTitle("Confirming Appointment");
                    set_time_comment.setContentView(R.layout.dialog_confirm_appointment);
                    set_time_comment.show();
                    ET_time = (EditText) set_time_comment.findViewById(R.id.txt_time);
                    ET_comment = (EditText) set_time_comment.findViewById(R.id.Doctors_Comment);
                    save = (Button) set_time_comment.findViewById(R.id.btn_save);
                    ET_time.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            Calendar cal = Calendar.getInstance();

                            TimePickerDialog timePicker = new TimePickerDialog(getActivity(), fragment_request.this, cal.get(Calendar.HOUR_OF_DAY), cal.get(Calendar.MINUTE), false);
                            timePicker.show();
                        }


                    });
                    save.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            if (ET_time.getText().toString().equals("") || ET_time.getText() == null) {
                                ET_time.setError("Time Required");
                            } else {
                                ContentValues val = new ContentValues();
                                val.put(DBHelper.TIME, ET_time.getText().toString());
                                val.put(DBHelper.COMMENT_DOCTOR, ET_comment.getText().toString());
                                val.put(DBHelper.IS_APPROVED, "1");
                                if (db_insert_update.insertAppointment(val, 1, Integer.parseInt(appointment_list.get(position).get(DBHelper.AI_ID)))) {
                                    Toast.makeText(getActivity(), "Saved", Toast.LENGTH_SHORT).show();
                                    appointment_list.remove(position);
                                    helper.refresh_drawer_counter(db_retrieve.getcounter(),getActivity());
                                    notifyDataSetChanged();
                                    set_time_comment.dismiss();

                                } else {
                                    Toast.makeText(getActivity(), "Saving Failed", Toast.LENGTH_SHORT).show();
                                }
                            }

                        }
                    });
                }
            });
            txt_decline.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(getActivity());
                    dialogBuilder.setTitle("Decline Request");
                    dialogBuilder.setMessage("Are you sure you want to decline this request?");
                    dialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {

                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            ContentValues val=new ContentValues();
                            val.put(DBHelper.IS_APPROVED,"2");
                            if(db_insert_update.insertAppointment(val,1,Integer.parseInt(appointment_list.get(position).get(DBHelper.AI_ID)))){
                                Toast.makeText(getActivity(), "Saved", Toast.LENGTH_SHORT).show();
                                appointment_list.remove(position);
                                adapter.notifyDataSetChanged();
                                helper.refresh_drawer_counter(db_retrieve.getcounter(),getActivity());
                            }else {
                                Toast.makeText(getActivity(), "Saving Failed", Toast.LENGTH_SHORT).show();
                            }
                        }
                    });
                    dialogBuilder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                        }
                    });

                    dialogBuilder.create().show();
                }
            });
            return vi;
        }

    }
}
