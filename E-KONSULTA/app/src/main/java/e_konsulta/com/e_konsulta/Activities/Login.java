package e_konsulta.com.e_konsulta.Activities;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import e_konsulta.com.e_konsulta.Tools.AppController;
import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.Tools.Helpers;
import e_konsulta.com.e_konsulta.R;

/**
 * Created by Royette on 11/25/2015.
 */
public class Login extends Activity implements View.OnClickListener {
    public static final String USERID_KEY_LAST_LOG ="user_id_key_last_log";
    public static final String USERID_KEY_LAST_LOG2 ="user_id_key_last_log2";
    public static final String USERID_KEY_CURRENT_LOG ="user_id_key_current_log";
    public static final String USERPREFERENCES="user_preferences";

    public static final String CURRENT_USER_ID="user_id",CURRENT_UNAME="username",CURRENT_PWORD="password",
            CURRENT_FNAME="fname",CURRENT_MNAME="mname",CURRENT_LNAME="lname",CURRENT_PRC_NO="prc_no",CURRENT_SPECIALTY="specialty";


    DBHelper dbHelper;
    SharedPreferences shareduserpref;
    EditText txt_uname,txt_pword;
    Button btn_login;
    Helpers helpers;
    Activity act_login;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_layout);
        shareduserpref=getSharedPreferences(USERPREFERENCES, Context.MODE_PRIVATE);
        btn_login= (Button) findViewById(R.id.btn_login);
        txt_uname= (EditText) findViewById(R.id.txt_username);
        txt_pword= (EditText) findViewById(R.id.txt_password);
        btn_login.setOnClickListener(this);
        helpers=new Helpers();
        dbHelper=new DBHelper(this);
        act_login=this;
    }

    @Override
    protected void onResume() {
        super.onResume();
        int current_user_id=shareduserpref.getInt(USERID_KEY_CURRENT_LOG,0);
        if(current_user_id!=0){
            Intent intent=new Intent(this,MainActivity.class);
            startActivity(intent);
            this.finish();
        }else {
            int userid=shareduserpref.getInt(USERID_KEY_LAST_LOG,0);
            if(userid!=0){
                Intent intent=new Intent(this,Login_v2.class);
                startActivity(intent);
                this.finish();
            }
        }

    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.btn_login:
                boolean checker=true;
                if(txt_uname.getText().toString().equals("")){
                    checker=false;
                    txt_uname.setError("Username Required");
                }
                if(txt_pword.getText().toString().equals("")) {
                    checker=false;
                    txt_pword.setError("Password Required");
                }
                if(checker){
                    if(helpers.checkInternet(this)){
                        getCredentials(txt_uname.getText().toString(),helpers.md5(txt_pword.getText().toString()));
                    }else {
                        if(txt_uname.getText().toString().equals(shareduserpref.getString(CURRENT_UNAME,""))&&helpers.md5(txt_pword.getText().toString()).equals(shareduserpref.getString(CURRENT_PWORD, ""))&&shareduserpref.getInt(USERID_KEY_LAST_LOG2,0)!=0){
                            SharedPreferences.Editor editor=shareduserpref.edit();
                            editor.putInt(USERID_KEY_LAST_LOG, shareduserpref.getInt(USERID_KEY_LAST_LOG2,0));
                            editor.putInt(USERID_KEY_CURRENT_LOG, shareduserpref.getInt(USERID_KEY_LAST_LOG2, 0));
                            editor.commit();
                            dbHelper.Clear_DB();
                            Intent intent=new Intent(getApplicationContext(),MainActivity.class);
                            startActivity(intent);
                            act_login.finish();
                        }else {
                            AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
                            dialogBuilder.setTitle("Unable to Login");
                            dialogBuilder.setMessage("Please Check Your Internet Connection and Try Again.");
                            dialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {

                                @Override
                                public void onClick(DialogInterface dialog, int which) {
                                }
                            });

                            dialogBuilder.create().show();
                        }

                    }
                }
                txt_pword.setText("");
                txt_uname.setText("");
                break;
        }
    }
    private void getCredentials(final String uname, final String pword){
        final ProgressDialog PD;
        PD = new ProgressDialog(this);
        PD.setMessage("Logging in.....");
        PD.setCancelable(false);
        PD.show();
        String url =String.format("http://bsit701.com/E-Konsulta/Helpers.php/?doctor_id=1&&action_type=1&&uname=%s&&pword=%s",uname,pword);
        Log.d("loginsssss", url);
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
                                JSONArray doctor=jsonObject.getJSONArray("doctor_profile");
                                for (int i = 0; i < doctor.length() ; i++) {
                                    final JSONObject doctor_items = doctor.getJSONObject(i);
                                    if(shareduserpref.getInt(USERID_KEY_LAST_LOG2,0)!=Integer.valueOf(doctor_items.getString("id"))&& shareduserpref.getInt(USERID_KEY_LAST_LOG2,0)!=0){
                                        AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(act_login);
                                        dialogBuilder.setTitle("User Identity Changed Detected");
                                        dialogBuilder.setMessage("Previous Data will be altered. Continue?");
                                        dialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {

                                            @Override
                                            public void onClick(DialogInterface dialog, int which) {
                                                try {
                                                    SharedPreferences.Editor editor=shareduserpref.edit();
                                                    editor.putInt(USERID_KEY_LAST_LOG, Integer.valueOf(doctor_items.getString("id")));
                                                    editor.putInt(USERID_KEY_LAST_LOG2, Integer.valueOf(doctor_items.getString("id")));
                                                    editor.putInt(USERID_KEY_CURRENT_LOG, Integer.valueOf(doctor_items.getString("id")));
                                                    editor.putString(CURRENT_FNAME, doctor_items.getString("fname"));
                                                    editor.putString(CURRENT_MNAME, doctor_items.getString("mname"));
                                                    editor.putString(CURRENT_LNAME, doctor_items.getString("lname"));
                                                    editor.putString(CURRENT_PRC_NO, doctor_items.getString("prc_no"));
                                                    editor.putString(CURRENT_SPECIALTY, doctor_items.getString("specialty"));
                                                    editor.putString(CURRENT_UNAME, uname);
                                                    editor.putString(CURRENT_PWORD, pword);
                                                    editor.commit();
                                                    Intent intent=new Intent(getApplicationContext(),MainActivity.class);
                                                    startActivity(intent);
                                                    act_login.finish();
                                                } catch (JSONException e) {
                                                    e.printStackTrace();
                                                }



                                            }
                                        });
                                        dialogBuilder.setNegativeButton("No",new DialogInterface.OnClickListener(){
                                            @Override
                                            public void onClick(DialogInterface dialog, int which) {
                                            }
                                        });

                                        dialogBuilder.create().show();
                                        dbHelper.Clear_DB();
                                    }else {
                                        SharedPreferences.Editor editor=shareduserpref.edit();
                                        editor.putInt(USERID_KEY_LAST_LOG, Integer.valueOf(doctor_items.getString("id")));
                                        editor.putInt(USERID_KEY_LAST_LOG2, Integer.valueOf(doctor_items.getString("id")));
                                        editor.putInt(USERID_KEY_CURRENT_LOG, Integer.valueOf(doctor_items.getString("id")));
                                        editor.putString(CURRENT_FNAME, doctor_items.getString("fname"));
                                        editor.putString(CURRENT_MNAME, doctor_items.getString("mname"));
                                        editor.putString(CURRENT_LNAME, doctor_items.getString("lname"));
                                        editor.putString(CURRENT_PRC_NO, doctor_items.getString("prc_no"));
                                        editor.putString(CURRENT_SPECIALTY, doctor_items.getString("specialty"));
                                        editor.commit();
                                        Intent intent=new Intent(getApplicationContext(),MainActivity.class);
                                        startActivity(intent);
                                        act_login.finish();
                                    }



                                }

                            }
                            else {
                                Toast.makeText(getApplicationContext(),"Invalid Username/Password",Toast.LENGTH_SHORT).show();
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        PD.dismiss();

                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                PD.dismiss();
            }
        });

        // Adding request to request queue
        AppController.getInstance().addToRequestQueue(req);
    }
}
