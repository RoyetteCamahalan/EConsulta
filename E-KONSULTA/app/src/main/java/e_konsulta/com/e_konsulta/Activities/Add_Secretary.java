package e_konsulta.com.e_konsulta.Activities;

import android.app.Activity;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.graphics.Typeface;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Map;

import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.Helpers;
import e_konsulta.com.e_konsulta.Tools.URLS;

/**
 * Created by Royette on 12/9/2015.
 */
public class Add_Secretary extends Activity implements View.OnClickListener, DialogInterface.OnDismissListener {
    SharedPreferences shareduserpref;
    DB_insert_update db_insert_update;
    Helpers helpers;

    EditText txt_mname,txt_username,txt_email,txt_password,dialog_username,dialog_password;
    TextView txt_secretary_name,txt_address,txt_telephone;
    AutoCompleteTextView txt_fname,txt_lname;
    Button dialog_btn_save,btn_save;

    ArrayList<HashMap<String,String>> secretary_list;
    ArrayList<HashMap<String,String>> secretary_list_lname;
    ArrayList<HashMap<String,String>> original_list;
    Map<String,String> secretary_item_selected=new HashMap<>();
    AutoCompleteAdapter_Fname Fname_adapter;
    AutoCompleteAdapter_Lname Lname_adapter;
    Dialog view_secretary;

    private int secretary_id=0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.add_secretary_layout);
        shareduserpref=getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);
        db_insert_update=new DB_insert_update(this);
        helpers=new Helpers();

        secretary_list_lname=new ArrayList<>();
        secretary_list=new ArrayList<>();
        original_list=new ArrayList<>();
        txt_fname= (AutoCompleteTextView) findViewById(R.id.fname);
        txt_mname= (EditText) findViewById(R.id.mname);
        txt_lname= (AutoCompleteTextView) findViewById(R.id.lname);
        txt_email= (EditText) findViewById(R.id.email);
        txt_username= (EditText) findViewById(R.id.txt_username);
        txt_password= (EditText) findViewById(R.id.txt_password);
        btn_save= (Button) findViewById(R.id.btn_save);

        Fname_adapter=new AutoCompleteAdapter_Fname(getApplicationContext(),R.layout.secretary_auto_adapter,secretary_list);
        txt_fname.setAdapter(Fname_adapter);
        Lname_adapter=new AutoCompleteAdapter_Lname(getApplicationContext(),R.layout.secretary_auto_adapter,secretary_list_lname);
        txt_lname.setAdapter(Lname_adapter);
        txt_fname.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                secretary_item_selected.clear();
                secretary_item_selected.putAll(secretary_list.get(position));
                show_view_secretary_dialog();
            }
        });
        txt_lname.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                secretary_item_selected.clear();
                secretary_item_selected.putAll(secretary_list_lname.get(position));
                show_view_secretary_dialog();
            }
        });
        btn_save.setOnClickListener(this);
        getAllSecretaries();


        getActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        this.finish();
        return super.onOptionsItemSelected(item);

    }
    private void show_view_secretary_dialog(){
        view_secretary=new Dialog(this);
        view_secretary.requestWindowFeature(Window.FEATURE_NO_TITLE);
        view_secretary.setContentView(R.layout.dialog_view_secretary);
        view_secretary.show();
        view_secretary.setOnDismissListener(this);

        txt_secretary_name= (TextView) view_secretary.findViewById(R.id.secretary_name);
        txt_address= (TextView) view_secretary.findViewById(R.id.address);
        txt_telephone= (TextView) view_secretary.findViewById(R.id.telephone);
        dialog_username= (EditText) view_secretary.findViewById(R.id.txt_username);
        dialog_password= (EditText) view_secretary.findViewById(R.id.txt_password);
        dialog_btn_save= (Button) view_secretary.findViewById(R.id.dialog_btn_save);

        dialog_btn_save.setOnClickListener(this);
        String fname,mname,lname,address,mobile;

        secretary_id=Integer.parseInt(secretary_item_selected.get(DBHelper.SECRETARY_ID));
        mname = secretary_item_selected.get(DBHelper.MNAME);
        fname=secretary_item_selected.get(DBHelper.FNAME);
        lname=secretary_item_selected.get(DBHelper.LNAME);
        address=secretary_item_selected.get(DBHelper.BARANGAY)+", "+secretary_item_selected.get(DBHelper.MUNICIPALITY)+", "+secretary_item_selected.get(DBHelper.PROVINCE)+", "+secretary_item_selected.get(DBHelper.REGION);
        mobile=secretary_item_selected.get(DBHelper.MOBILE_NO);
        if(mname.length()!=0){
            mname=mname.substring(0,1)+".";
        }
        txt_secretary_name.setText(fname+" "+mname+" "+lname);
        txt_address.setText(address);
        if(mobile.equals("")||mobile.equals(null)){
            mobile="N/A";
            txt_telephone.setTypeface(null, Typeface.BOLD);
        }
        txt_telephone.setText(mobile);
        txt_fname.setText("");
        txt_lname.setText("");
    }

    @Override
    public void onClick(View v) {
        String username,password;
        boolean checker=true;
        switch (v.getId()){
            case R.id.dialog_btn_save:
                username=dialog_username.getText().toString();
                password=dialog_password.getText().toString();
                if(username.equals("")){
                    dialog_username.setError("Required");
                    checker=false;
                }
                if(password.equals("")){
                    dialog_password.setError("Required");
                    checker=false;
                }
                if(checker){
                    save_secretaty(secretary_id,username,helpers.md5(password));
                }
                break;
            case R.id.btn_save:
                String fname=txt_fname.getText().toString(),
                        mname=txt_mname.getText().toString(),
                        lname=txt_lname.getText().toString(),
                        email=txt_email.getText().toString();

                username=txt_username.getText().toString();
                password=txt_password.getText().toString();
                if(username.equals("")){
                    txt_username.setError("Required");
                    checker=false;
                }
                if(password.equals("")){
                    txt_password.setError("Required");
                    checker=false;
                }
                if(checker){
                    save_new_secretary(fname,mname,lname,email,username,helpers.md5(password));
                }
                break;
        }

    }

    @Override
    public void onDismiss(DialogInterface dialog) {
        if(dialog==view_secretary){
            secretary_id=0;
        }
    }

    private void getAllSecretaries(){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        PD.setMessage("Fetching Secretaries.....");
        PD.setCancelable(false);
        PD.show();

        String url = URLS.URL_Helper+String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0)+"&&action_type=2");
        // Volley's json array request object
        JsonObjectRequest req = new JsonObjectRequest(Request.Method.GET,url,null,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject jsonObject) {

                        Log.d("secretaries",String.valueOf(jsonObject));
                        int success = 0;
                        try {
                            success = jsonObject.getInt("success");
                            if(success==1){
                                JSONArray secretaries=jsonObject.getJSONArray("secretaries");
                                for (int i = 0; i < secretaries.length() ; i++) {
                                    JSONObject secretary_item = secretaries.getJSONObject(i);
                                    HashMap<String, String> map = new HashMap();
                                    map.put(DBHelper.SECRETARY_ID,secretary_item.getString("id"));
                                    map.put(DBHelper.FNAME,secretary_item.getString("fname"));
                                    map.put(DBHelper.MNAME,secretary_item.getString("mname"));
                                    map.put(DBHelper.LNAME,secretary_item.getString("lname"));
                                    map.put(DBHelper.MOBILE_NO,secretary_item.getString("cell_no"));
                                    map.put(DBHelper.TEL_NO,secretary_item.getString("tel_no"));
                                    map.put(DBHelper.EMAIL,secretary_item.getString("email"));
                                    map.put(DBHelper.PHOTO,secretary_item.getString("photo"));
                                    map.put(DBHelper.OPTIONAL_ADDRESS,secretary_item.getString("optional_address"));
                                    map.put(DBHelper.BRGY_ID,secretary_item.getString("barangay_id"));
                                    map.put(DBHelper.BARANGAY,secretary_item.getString("barangay_name"));
                                    map.put(DBHelper.MUNICIPALITY,secretary_item.getString("municipality_name"));
                                    map.put(DBHelper.PROVINCE,secretary_item.getString("province_name"));
                                    map.put(DBHelper.REGION,secretary_item.getString("region_name"));
                                    original_list.add(map);
                                    secretary_list.add(map);
                                    secretary_list_lname.add(map);
                                }

                            }
                            else {

                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        Fname_adapter.notifyDataSetChanged();
                        Lname_adapter.notifyDataSetChanged();
                        PD.dismiss();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Toast.makeText(getBaseContext(),"No Internet Connection",Toast.LENGTH_SHORT).show();
                PD.dismiss();
                Add_Secretary.this.finish();
            }
        });
        // Adding request to request queue
        AppController.getInstance().addToRequestQueue(req);
    }
    private void save_new_secretary(final String fname, final String mname, final String lname, final String email, final String username, final String password){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        PD.setMessage("Processing.....");
        PD.setCancelable(false);
        PD.show();

        StringRequest jsonObjReq = new StringRequest(Request.Method.POST,URLS.URL_Post_Request,
                new Response.Listener<String>() {

                    @Override
                    public void onResponse(String output) {
                        Log.d("save_sec", output);
                        try {
                            JSONObject response=new JSONObject(output);
                            int success = 0;

                            success = response.getInt("success");
                            switch (success){
                                case 0:
                                    Toast.makeText(getApplicationContext(),"Something went wrong success=0",Toast.LENGTH_SHORT).toString();
                                    break;
                                case 1:
                                    int id=response.getInt("secretary_id");
                                    ContentValues val=new ContentValues();
                                    val.put(DBHelper.FNAME,fname);
                                    val.put(DBHelper.MNAME,mname);
                                    val.put(DBHelper.LNAME,lname);
                                    val.put(DBHelper.MOBILE_NO,"");
                                    val.put(DBHelper.TEL_NO,"");
                                    val.put(DBHelper.EMAIL,email);
                                    val.put(DBHelper.OPTIONAL_ADDRESS,"");
                                    val.put(DBHelper.BRGY_ID,1);
                                    val.put(DBHelper.BARANGAY,"N/A");
                                    val.put(DBHelper.MUNICIPALITY,"N/A");
                                    val.put(DBHelper.PROVINCE,"N/A");
                                    val.put(DBHelper.REGION,"N/A");
                                    val.put(DBHelper.USERNAME,username);
                                    val.put(DBHelper.PASSWORD,password);
                                    val.put(DBHelper.IS_ACTIVE,1);
                                    Calendar c=Calendar.getInstance();
                                    SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                                    String formattedDate = df.format(c.getTime());
                                    val.put(DBHelper.CREATED_AT, formattedDate);
                                    if(db_insert_update.insertSecretary(val, 0, id)){
                                        Toast.makeText(getApplicationContext(),"Success",Toast.LENGTH_SHORT).toString();
                                        Add_Secretary.this.finish();
                                    }

                                    break;
                                case 2:
                                    Toast.makeText(getApplicationContext(),"Username and Password already in use.",Toast.LENGTH_SHORT).toString();
                                    break;
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        PD.dismiss();
                    }
                }, new Response.ErrorListener() {

            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("save_sec", String.valueOf(error));
                Toast.makeText(getApplicationContext(),"Something went wrong! ",Toast.LENGTH_SHORT).show();
                PD.dismiss();
            }
        }) {
            @Override
            protected Map<String,String> getParams(){
                Map<String, String> params = new HashMap<String, String>();
                params.put("action_type", "1");
                params.put("sub_action", "0");
                params.put("fname", fname);
                params.put("mname", mname);
                params.put("lname", lname);
                params.put("email", email);
                params.put("doctor_id", String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG, 0)));
                params.put("is_allowed", "1");
                params.put("username",username);
                params.put("password", password);
                return params;
            }
        };
        // Adding request to request queue
        AppController.getInstance().addToRequestQueue(jsonObjReq);
    }
    private void save_secretaty(final int secretary_id, final String username, final String password){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        PD.setMessage("Processing.....");
        PD.setCancelable(false);
        PD.show();
        StringRequest request = new StringRequest(Request.Method.POST,URLS.URL_Post_Request,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String Response) {
                        Log.d("save_sec",Response);
                        int success = 0;
                        try {
                            JSONObject jsonObject=new JSONObject(Response);

                            success = jsonObject.getInt("success");
                            switch (success){
                                case 0:
                                    Toast.makeText(getBaseContext(),"Something went wrong success=0",Toast.LENGTH_SHORT).toString();

                                    break;
                                case 1:

                                    ContentValues val=new ContentValues();
                                    val.put(DBHelper.FNAME,secretary_item_selected.get(DBHelper.FNAME));
                                    val.put(DBHelper.MNAME,secretary_item_selected.get(DBHelper.MNAME));
                                    val.put(DBHelper.LNAME,secretary_item_selected.get(DBHelper.LNAME));
                                    val.put(DBHelper.MOBILE_NO,secretary_item_selected.get(DBHelper.MOBILE_NO));
                                    val.put(DBHelper.TEL_NO,secretary_item_selected.get(DBHelper.TEL_NO));
                                    val.put(DBHelper.EMAIL,secretary_item_selected.get(DBHelper.EMAIL));
                                    val.put(DBHelper.PHOTO,secretary_item_selected.get(DBHelper.PHOTO));
                                    val.put(DBHelper.OPTIONAL_ADDRESS,secretary_item_selected.get(DBHelper.OPTIONAL_ADDRESS));
                                    val.put(DBHelper.BRGY_ID,secretary_item_selected.get(DBHelper.BRGY_ID));
                                    val.put(DBHelper.BARANGAY,secretary_item_selected.get(DBHelper.BARANGAY));
                                    val.put(DBHelper.MUNICIPALITY,secretary_item_selected.get(DBHelper.MUNICIPALITY));
                                    val.put(DBHelper.PROVINCE,secretary_item_selected.get(DBHelper.PROVINCE));
                                    val.put(DBHelper.REGION,secretary_item_selected.get(DBHelper.REGION));
                                    val.put(DBHelper.USERNAME,username);
                                    val.put(DBHelper.PASSWORD,password);
                                    val.put(DBHelper.IS_ACTIVE,1);
                                    Calendar c=Calendar.getInstance();
                                    SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                                    String formattedDate = df.format(c.getTime());
                                    val.put(DBHelper.CREATED_AT, formattedDate);
                                    if(db_insert_update.insertSecretary(val, 0, Integer.parseInt(secretary_item_selected.get(DBHelper.SECRETARY_ID)))){
                                        Toast.makeText(getApplicationContext(),"Success",Toast.LENGTH_SHORT).toString();
                                        Add_Secretary.this.finish();
                                    }
                                    Toast.makeText(getBaseContext(),"Success",Toast.LENGTH_SHORT).toString();
                                    break;
                                case 2:
                                    Toast.makeText(getBaseContext(),"Username and Password already in use.",Toast.LENGTH_SHORT).toString();
                                    break;
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        PD.dismiss();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.d("save_sec", String.valueOf(error));
                Toast.makeText(getBaseContext(),"Something went wrong! ",Toast.LENGTH_SHORT).show();
                PD.dismiss();
            }
        }) {
            @Override
            protected Map<String, String> getParams(){
                Map<String, String> params = new HashMap<String, String>();
                params.put("action_type", "1");
                params.put("sub_action", "1");
                params.put("secretary_id", String.valueOf(secretary_id));
                params.put("doctor_id", String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0)));
                params.put("is_allowed", "1");
                params.put("username",username);
                params.put("password", password);
                return params;
            }
        };

        // Adding request to request queue
        AppController.getInstance().addToRequestQueue(request);
    }

    public class AutoCompleteAdapter_Fname extends ArrayAdapter{
        LayoutInflater inflater;
        TextView txt_secretary_name;
        public AutoCompleteAdapter_Fname(Context context,int res, ArrayList<HashMap<String, String>> objects) {
            super(context,res,objects);
            inflater=LayoutInflater.from(context);
        }
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.secretary_auto_adapter,parent, false);
            txt_secretary_name= (TextView) vi.findViewById(R.id.secretary_name);
            String mname = secretary_list.get(position).get(DBHelper.MNAME);
            if(mname.length()!=0){
                mname=mname.substring(0,1)+".";
            }
            txt_secretary_name.setText(secretary_list.get(position).get(DBHelper.FNAME)+" "+mname+" "+secretary_list.get(position).get(DBHelper.LNAME));
            return vi;
        }
        @Override
        public Filter getFilter() {
            Filter myFilter = new Filter() {
                @Override
                protected FilterResults performFiltering(CharSequence constraint) {
                    FilterResults filterResults = new FilterResults();
                    if(constraint != null) {
                        secretary_list.clear();
                        secretary_list.addAll(original_list);
                        for (int i = secretary_list.size()-1; i >= 0; i--) {
                            String item = secretary_list.get(i).get(DBHelper.FNAME);
                            if (item.toLowerCase().contains(constraint)==false) {
                                secretary_list.remove(i);
                            }

                        }

                        // Now assign the values and count to the FilterResults object
                        filterResults.values = secretary_list;
                        filterResults.count = secretary_list.size();
                    }
                    return filterResults;
                }

                @Override
                protected void publishResults(CharSequence contraint, FilterResults results) {
                    if(results != null && results.count > 0) {
                        notifyDataSetChanged();
                    }
                    else {
                        notifyDataSetInvalidated();
                    }
                }
            };
            return myFilter;
        }
    }
    public class AutoCompleteAdapter_Lname extends ArrayAdapter{
        LayoutInflater inflater;
        TextView txt_secretary_name;
        public AutoCompleteAdapter_Lname(Context context,int res, ArrayList<HashMap<String, String>> objects) {
            super(context,res,objects);
            inflater=LayoutInflater.from(context);
        }
        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View vi=inflater.inflate(R.layout.secretary_auto_adapter,parent, false);
            txt_secretary_name= (TextView) vi.findViewById(R.id.secretary_name);
            String mname = secretary_list_lname.get(position).get(DBHelper.MNAME);
            if(mname.length()!=0){
                mname=mname.substring(0,1)+".";
            }
            txt_secretary_name.setText(secretary_list_lname.get(position).get(DBHelper.FNAME)+" "+mname+" "+secretary_list_lname.get(position).get(DBHelper.LNAME));
            return vi;
        }
        @Override
        public Filter getFilter() {
            Filter myFilter = new Filter() {
                @Override
                protected FilterResults performFiltering(CharSequence constraint) {
                    FilterResults filterResults = new FilterResults();
                    if(constraint != null) {
                        secretary_list_lname.clear();
                        secretary_list_lname.addAll(original_list);
                        for (int i = secretary_list_lname.size()-1; i >= 0; i--) {
                            String item = secretary_list_lname.get(i).get(DBHelper.LNAME);
                            if (item.toLowerCase().contains(constraint)==false) {
                                secretary_list_lname.remove(i);
                            }

                        }

                        // Now assign the values and count to the FilterResults object
                        filterResults.values = secretary_list_lname;
                        filterResults.count = secretary_list_lname.size();
                    }
                    return filterResults;
                }

                @Override
                protected void publishResults(CharSequence contraint, FilterResults results) {
                    if(results != null && results.count > 0) {
                        notifyDataSetChanged();
                    }
                    else {
                        notifyDataSetInvalidated();
                    }
                }
            };
            return myFilter;
        }
    }

}
