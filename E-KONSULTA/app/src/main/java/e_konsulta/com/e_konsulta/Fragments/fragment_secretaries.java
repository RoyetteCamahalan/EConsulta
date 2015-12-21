package e_konsulta.com.e_konsulta.Fragments;

import android.app.Dialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Typeface;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
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

import e_konsulta.com.e_konsulta.Activities.Add_Secretary;
import e_konsulta.com.e_konsulta.Activities.Login;
import e_konsulta.com.e_konsulta.Activities.Secretary_Profile_Master;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;
import e_konsulta.com.e_konsulta.Tools.Helpers;
import e_konsulta.com.e_konsulta.Tools.URLS;

/**
 * Created by Royette on 11/24/2015.
 */
public class fragment_secretaries extends Fragment implements SwipeRefreshLayout.OnRefreshListener, AdapterView.OnItemClickListener, View.OnClickListener {
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;
    Helpers helper;

    private SwipeRefreshLayout swipeRefreshLayout;
    ListView list_of_secretaries;
    ImageButton img_add_secretary;
    Button btn_save_secretary;
    Dialog dialog_add;

    SharedPreferences shareduserpref;


    ArrayList<HashMap<String,String>> secretary_list;
    Secretaries_Adapter adapter;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView=inflater.inflate(R.layout.secretaries_layout,container,false);
        db_retrieve=new DB_retrieve(getActivity());
        db_insert_update=new DB_insert_update(getActivity());
        helper=new Helpers();
        shareduserpref=getActivity().getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);

        list_of_secretaries = (ListView) rootView.findViewById(R.id.list_of_secretaries);
        swipeRefreshLayout = (SwipeRefreshLayout) rootView.findViewById(R.id.swipe_refresh_layout);
        img_add_secretary= (ImageButton) rootView.findViewById(R.id.add_secretary);

        swipeRefreshLayout.setOnRefreshListener(this);
        list_of_secretaries.setOnItemClickListener(this);
        img_add_secretary.setOnClickListener(this);
        return rootView;
    }

    @Override
    public void onResume() {
        super.onResume();
        secretary_list=db_retrieve.getAllSecretaries();
        adapter=new Secretaries_Adapter(getActivity(),R.layout.secretary_list_item,secretary_list);
        list_of_secretaries.setAdapter(adapter);
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
                        Log.d("secretaries", String.valueOf(jsonObject));
                        int success = 0;
                        try {
                            success = jsonObject.getInt("success");
                            if(success==1){
                                JSONArray secretaries=jsonObject.getJSONArray("secretaries");
                                for (int i = 0; i < secretaries.length() ; i++) {
                                    JSONObject secretary_item = secretaries.getJSONObject(i);
                                    int id=Integer.valueOf(secretary_item.getString("id"));
                                    ContentValues val=new ContentValues();
                                    val.put(DBHelper.FNAME,secretary_item.getString("fname"));
                                    val.put(DBHelper.MNAME,secretary_item.getString("mname"));
                                    val.put(DBHelper.LNAME,secretary_item.getString("lname"));
                                    val.put(DBHelper.MOBILE_NO,secretary_item.getString("cell_no"));
                                    val.put(DBHelper.TEL_NO,secretary_item.getString("tel_no"));
                                    val.put(DBHelper.EMAIL,secretary_item.getString("email"));
                                    val.put(DBHelper.PHOTO,secretary_item.getString("photo"));
                                    val.put(DBHelper.OPTIONAL_ADDRESS,secretary_item.getString("optional_address"));
                                    val.put(DBHelper.BRGY_ID,Integer.valueOf(secretary_item.getString("barangay_id")));
                                    val.put(DBHelper.BARANGAY,secretary_item.getString("barangay_name"));
                                    val.put(DBHelper.MUNICIPALITY,secretary_item.getString("municipality_name"));
                                    val.put(DBHelper.PROVINCE,secretary_item.getString("province_name"));
                                    val.put(DBHelper.REGION,secretary_item.getString("region_name"));
                                    val.put(DBHelper.USERNAME,secretary_item.getString("username"));
                                    val.put(DBHelper.PASSWORD,secretary_item.getString("password"));
                                    val.put(DBHelper.IS_ACTIVE,Integer.valueOf(secretary_item.getString("is_active")));
                                    val.put(DBHelper.CREATED_AT, secretary_item.getString("created_at"));
                                    val.put(DBHelper.UPDATED_AT, secretary_item.getString("updated_at"));
                                    db_insert_update.insertSecretary(val, db_insert_update.check_secretary(id), id);
                                }
                                secretary_list=db_retrieve.getAllSecretaries();
                                adapter=new Secretaries_Adapter(getActivity(),R.layout.secretary_list_item,secretary_list);
                                list_of_secretaries.setAdapter(adapter);
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
        Intent intent=new Intent(getActivity(), Secretary_Profile_Master.class);
        intent.putExtra(DBHelper.SECRETARY_ID,Integer.parseInt(secretary_list.get(position).get(DBHelper.SECRETARY_ID)));
        startActivity(intent);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.add_secretary:
                if(helper.checkInternet(getActivity())){
                    Intent intent=new Intent(getActivity(), Add_Secretary.class);
                    startActivity(intent);
                    break;
                }else{
                    Toast.makeText(getActivity(),"No Internet Connection",Toast.LENGTH_SHORT).show();
                }

        }
    }

    private class Secretaries_Adapter extends ArrayAdapter{
        LayoutInflater inflater;
        TextView txt_secretary_name,txt_status;
        ImageView img_is_active;
        public Secretaries_Adapter(Context context, int resource, ArrayList<HashMap<String, String>> objects) {
            super(context, resource, objects);
            inflater=LayoutInflater.from(context);
        }
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.secretary_list_item,parent, false);
            txt_secretary_name= (TextView) vi.findViewById(R.id.secretary_name);
            img_is_active= (ImageView) vi.findViewById(R.id.img_is_active);
            txt_status= (TextView) vi.findViewById(R.id.txt_is_active);

            txt_secretary_name.setText(secretary_list.get(position).get("FULLNAME"));
            if(secretary_list.get(position).get(DBHelper.IS_ACTIVE).equals("1")){
                img_is_active.setImageResource(R.drawable.ic_check_user_filled);
                txt_status.setText("Active");
            }
            return vi;
        }
    }
}
