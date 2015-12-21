package e_konsulta.com.e_konsulta.Activities;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Typeface;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;


import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;

import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;
import e_konsulta.com.e_konsulta.Tools.Helpers;
import e_konsulta.com.e_konsulta.Tools.URLS;

/**
 * Created by Royette on 12/17/2015.
 */
public class Secretary_Profile_Master extends Activity implements View.OnClickListener {
    Helpers helper;
    SharedPreferences shareduserpref;
    DB_retrieve db_retrieve;
    DB_insert_update db_insert_update;

    ImageButton img_edit_uname;
    ImageView img_deacticate_activate;
    EditText txt_username;
    LinearLayout layout_change_pword,layout_deactivate_activate;
    TextView txt_secretary_name,txt_Address,txt_mobile,txt_tel,txt_email,txt_deactivate_activate;

    Button dialog_save;
    EditText dialog_user_pword,dialog_new_pword;

    Dialog change_password;

    public static int secretary_id;
    String mobile,email,tel;
    ArrayList<HashMap<String, String>> secretary_details;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.secretary_profile);
        this.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);

        helper=new Helpers();
        db_retrieve=new DB_retrieve(this);
        db_insert_update=new DB_insert_update(this);
        shareduserpref=getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);

        Intent intent=getIntent();
        secretary_id=intent.getIntExtra(DBHelper.SECRETARY_ID,0);

        secretary_details=db_retrieve.getSecretary(secretary_id);

        txt_secretary_name= (TextView) findViewById(R.id.secretary_name);
        txt_Address= (TextView) findViewById(R.id.address);
        txt_mobile= (TextView) findViewById(R.id.mobile);
        txt_email= (TextView) findViewById(R.id.email);
        txt_tel= (TextView) findViewById(R.id.telephone);
        txt_username= (EditText) findViewById(R.id.txt_username);
        img_edit_uname= (ImageButton) findViewById(R.id.img_edit);
        layout_change_pword= (LinearLayout) findViewById(R.id.change_password);
        layout_deactivate_activate= (LinearLayout) findViewById(R.id.activate_deactivate_user);
        img_deacticate_activate= (ImageView) findViewById(R.id.img_activate_deactivate);
        txt_deactivate_activate= (TextView) findViewById(R.id.txt_activate_deactivate);

        txt_secretary_name.setText(secretary_details.get(0).get("FULLNAME"));
        txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
        txt_Address.setText(secretary_details.get(0).get(DBHelper.BARANGAY)+", "+secretary_details.get(0).get(DBHelper.MUNICIPALITY)+", "+secretary_details.get(0).get(DBHelper.PROVINCE));
        mobile=secretary_details.get(0).get(DBHelper.MOBILE_NO);
        tel=secretary_details.get(0).get(DBHelper.TEL_NO);
        email=secretary_details.get(0).get(DBHelper.EMAIL);
        if(mobile.equals("")||mobile.equals(null)||mobile.equals("null")){
            mobile="N/A";
            txt_mobile.setTypeface(null, Typeface.BOLD);
        }
        if(tel.equals("")||tel.equals("null")||tel.equals("null")){
            tel="N/A";
            txt_tel.setTypeface(null,Typeface.BOLD);
        }
        if(email.equals("")||email.equals(null)||email.equals("null")){
            email="N/A";
            txt_email.setTypeface(null,Typeface.BOLD);
        }
        txt_mobile.setText(mobile);
        txt_tel.setText(tel);
        txt_email.setText(email);

        if(secretary_details.get(0).get(DBHelper.IS_ACTIVE).equals("0")){
            img_deacticate_activate.setImageResource(R.drawable.ic_check_user_filled);
            txt_deactivate_activate.setText("Activate Account");
        }

        img_edit_uname.setTag("edit");
        img_edit_uname.setOnClickListener(this);
        layout_change_pword.setOnClickListener(this);
        layout_deactivate_activate.setOnClickListener(this);
        getActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if(item.getItemId()==android.R.id.home){
            this.finish();
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.img_edit:
                if(img_edit_uname.getTag().equals("edit")){
                    txt_username.setEnabled(true);
                    img_edit_uname.setTag("save");
                    img_edit_uname.setImageResource(R.drawable.ic_check_filled);
                }else if(img_edit_uname.getTag().equals("save")){
                    String username=txt_username.getText().toString();
                    boolean checker=true;
                    if(username.length()<4){
                        checker=false;
                        txt_username.setError("Too Short");
                    }
                    if(username.length()>30){
                        checker=false;
                        txt_username.setError("Too Long");
                    }
                    if(checker){
                        txt_username.setEnabled(false);
                        img_edit_uname.setTag("edit");
                        img_edit_uname.setImageResource(R.drawable.ic_edit_filled);
                        if(secretary_details.get(0).get(DBHelper.USERNAME).equals(username)){
                            Toast.makeText(this,"No Changes Saved",Toast.LENGTH_SHORT).show();
                        }else{
                            save_new_username(username);
                        }
                    }

                }

                break;
            case R.id.change_password:
                change_password=new Dialog(this);
                change_password.setTitle("Change Password");
                change_password.setContentView(R.layout.dialog_change_secretary_pword);
                change_password.show();
                dialog_user_pword= (EditText) change_password.findViewById(R.id.txt_password);
                dialog_new_pword= (EditText) change_password.findViewById(R.id.txt_confirm_password);
                dialog_save= (Button) change_password.findViewById(R.id.btn_save);
                dialog_save.setOnClickListener(this);
                break;
            case R.id.btn_save:
                String user_password=dialog_user_pword.getText().toString();
                String new_password=dialog_new_pword.getText().toString();
                boolean checker=true;
                if(user_password.equals("")){
                    dialog_user_pword.setError("Required");
                    checker=false;
                }else if(!helper.md5(user_password).equals(shareduserpref.getString(Login.CURRENT_PWORD,""))){
                    dialog_user_pword.setError("Password Does Not Match");
                    checker=false;

                }

                if(new_password.equals("")){
                    dialog_new_pword.setError("Required");
                    checker=false;
                }else if(new_password.length()<4){
                    dialog_new_pword.setError("Too Short");
                    checker=false;
                }else if(new_password.length()>30){
                    dialog_new_pword.setError("Too Long");
                    checker=false;
                }
                if(checker){
                    new_password=helper.md5(new_password);
                    if(secretary_details.get(0).get(DBHelper.PASSWORD).equals(new_password)){
                        Toast.makeText(this,"No Changes Saved",Toast.LENGTH_SHORT).show();
                    }else{
                        save_new_password(new_password);
                    }

                }
                break;
            case R.id.activate_deactivate_user:
                if(secretary_details.get(0).get(DBHelper.IS_ACTIVE).equals("1")){
                    AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
                    dialogBuilder.setTitle("Deactivating Account");
                    dialogBuilder.setMessage("Are you sure to Deactivate this Account?");
                    dialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {

                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            deactivate_activate(0);
                        }
                    });
                    dialogBuilder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                        }
                    });
                    dialogBuilder.create().show();
                }else {
                    AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
                    dialogBuilder.setTitle("Activating Account");
                    dialogBuilder.setMessage("Are you sure to Activate this Account?");
                    dialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {

                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            deactivate_activate(1);
                        }
                    });
                    dialogBuilder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                        }
                    });
                    dialogBuilder.create().show();
                }
                break;
        }
    }
    private void save_new_password(final String password){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        PD.setMessage("Updating Password.....");
        PD.show();
        StringRequest request=new StringRequest(Request.Method.POST, URLS.URL_Post_Request,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject=new JSONObject(response);
                            int success=0;
                            success=jsonObject.getInt("success");
                            if(success==1){
                                ContentValues val=new ContentValues();
                                val.put(DBHelper.PASSWORD,password);
                                if(db_insert_update.insertSecretary(val,1,secretary_id)){
                                    Toast.makeText(getApplicationContext(),"Saved",Toast.LENGTH_SHORT).show();
                                }else{
                                    Toast.makeText(getApplicationContext(),"Saving in Local Database Failed",Toast.LENGTH_SHORT).show();
                                }
                                change_password.dismiss();
                            }else if(success==2){
                                Toast.makeText(getApplicationContext(),"Password Already Exist",Toast.LENGTH_SHORT).show();
                            }else {
                                change_password.dismiss();
                                Toast.makeText(getApplicationContext(),"Saving Failed",Toast.LENGTH_SHORT).show();
                            }
                        } catch (JSONException e) {
                            change_password.dismiss();
                            e.printStackTrace();
                        }
                        PD.dismiss();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                Toast.makeText(getApplicationContext(),"Saving Failed",Toast.LENGTH_SHORT).show();
                PD.dismiss();
                change_password.dismiss();
            }
        }){
            @Override
            protected Map<String, String> getParams() {
                Map<String,String> params=new HashMap<>();
                params.put("action_type","2");
                params.put("sub_action","1");
                params.put("secretary_id",String.valueOf(secretary_id));
                params.put("doctor_id",String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0)));
                params.put("password",password);
                params.put("username",secretary_details.get(0).get(DBHelper.USERNAME));
                return params;
            }
        };
        AppController.getInstance().addToRequestQueue(request);
    }

    private void save_new_username(final String username){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        PD.setMessage("Updating Username.....");
        PD.show();
        StringRequest request=new StringRequest(Request.Method.POST, URLS.URL_Post_Request,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject=new JSONObject(response);
                            int success=0;
                            success=jsonObject.getInt("success");
                            if(success==1){
                                ContentValues val=new ContentValues();
                                val.put(DBHelper.USERNAME,username);
                                if(db_insert_update.insertSecretary(val,1,secretary_id)){
                                    Toast.makeText(getApplicationContext(),"Saved",Toast.LENGTH_SHORT).show();
                                }else{
                                    Toast.makeText(getApplicationContext(),"Saving in Local Database Failed",Toast.LENGTH_SHORT).show();
                                    txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                                }
                            }else if(success==2){
                                Toast.makeText(getApplicationContext(),"Username Already Exist",Toast.LENGTH_SHORT).show();
                            }else{
                                Toast.makeText(getApplicationContext(),"Saving Failed",Toast.LENGTH_SHORT).show();
                                txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                            txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                        }
                        PD.dismiss();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                Toast.makeText(getApplicationContext(),"Saving Failed",Toast.LENGTH_SHORT).show();
                txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                PD.dismiss();
            }
        }){
            @Override
            protected Map<String, String> getParams() {
                Map<String,String> params=new HashMap<>();
                params.put("action_type","2");
                params.put("sub_action","2");
                params.put("secretary_id",String.valueOf(secretary_id));
                params.put("doctor_id",String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0)));
                params.put("username",username);
                params.put("password",secretary_details.get(0).get(DBHelper.PASSWORD));
                return params;
            }
        };
        AppController.getInstance().addToRequestQueue(request);
    }

    private void deactivate_activate(final int is_active){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        if(is_active==1){
            PD.setMessage("Activating Account.....");
        }else{
            PD.setMessage("Deactivitating Account.....");
        }

        PD.show();
        StringRequest request=new StringRequest(Request.Method.POST, URLS.URL_Post_Request,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject=new JSONObject(response);
                            int success=0;
                            success=jsonObject.getInt("success");
                            if(success==1){
                                ContentValues val=new ContentValues();
                                val.put(DBHelper.IS_ACTIVE,String.valueOf(is_active));
                                if(db_insert_update.insertSecretary(val,1,secretary_id)){
                                    secretary_details.clear();
                                    secretary_details=db_retrieve.getSecretary(secretary_id);
                                    if(is_active==1){
                                        img_deacticate_activate.setImageResource(R.drawable.ic_remove_user_red);
                                        txt_deactivate_activate.setText("Deactivate Account");
                                    }else {
                                        img_deacticate_activate.setImageResource(R.drawable.ic_check_user_filled);
                                        txt_deactivate_activate.setText("Activate Account");
                                    }
                                    Toast.makeText(getApplicationContext(),"Saved",Toast.LENGTH_SHORT).show();
                                }else{
                                    Toast.makeText(getApplicationContext(),"Saving in Local Database Failed",Toast.LENGTH_SHORT).show();
                                    txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                                }
                            }else{
                                Toast.makeText(getApplicationContext(),"Saving Failed",Toast.LENGTH_SHORT).show();
                                txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                            txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                        }
                        PD.dismiss();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                Toast.makeText(getApplicationContext(),"Saving Failed",Toast.LENGTH_SHORT).show();
                txt_username.setText(secretary_details.get(0).get(DBHelper.USERNAME));
                PD.dismiss();
            }
        }){
            @Override
            protected Map<String, String> getParams() {
                Map<String,String> params=new HashMap<>();
                params.put("action_type","2");
                params.put("sub_action","0");
                params.put("secretary_id",String.valueOf(secretary_id));
                params.put("doctor_id",String.valueOf(shareduserpref.getInt(Login.USERID_KEY_CURRENT_LOG,0)));
                params.put("is_active",String.valueOf(is_active));
                return params;
            }
        };
        AppController.getInstance().addToRequestQueue(request);
    }
}
