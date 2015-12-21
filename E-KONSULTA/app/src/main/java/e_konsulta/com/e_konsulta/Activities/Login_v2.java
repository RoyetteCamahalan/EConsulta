package e_konsulta.com.e_konsulta.Activities;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.Helpers;

/**
 * Created by Royette on 11/26/2015.
 */
public class Login_v2 extends Activity implements View.OnClickListener {
    Helpers helper;

    Button btn_login;
    TextView txt_sign_with_different_acc,txt_doctors_name;
    EditText txt_pword;
    SharedPreferences shareduserpref;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.loginv2_layout);
        helper=new Helpers();

        txt_sign_with_different_acc= (TextView) findViewById(R.id.sign_dif_acc);
        txt_sign_with_different_acc.setOnClickListener(this);
        txt_doctors_name= (TextView) findViewById(R.id.doctors_name);
        btn_login= (Button) findViewById(R.id.btn_login);
        txt_pword= (EditText) findViewById(R.id.txt_password);
        shareduserpref=getSharedPreferences(Login.USERPREFERENCES, Context.MODE_PRIVATE);
        if(shareduserpref.getInt(Login.USERID_KEY_LAST_LOG,0)!=0){
            String mname=shareduserpref.getString(Login.CURRENT_MNAME,"");
            if(!mname.equals("")&&!mname.equals("null")){
                mname=mname.substring(0,1)+".";
            }
            txt_doctors_name.setText("Dr. "+shareduserpref.getString(Login.CURRENT_FNAME, "")+" "+mname+" "+shareduserpref.getString(Login.CURRENT_LNAME, ""));
        }
        btn_login.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.sign_dif_acc:
                Intent intent=new Intent(this,Login.class);
                startActivity(intent);
                SharedPreferences.Editor editor=shareduserpref.edit();
                editor.putInt(Login.USERID_KEY_LAST_LOG,0);
                editor.commit();
                this.finish();
                break;
            case R.id.btn_login:
                String pword=txt_pword.getText().toString();
                if(pword.equals("")){
                    txt_pword.setError("Password Required");
                }
                else {
                    if(shareduserpref.getString(Login.CURRENT_PWORD,"").equals(helper.md5(pword))){
                        SharedPreferences.Editor editor2=shareduserpref.edit();
                        editor2.putInt(Login.USERID_KEY_CURRENT_LOG, shareduserpref.getInt(Login.USERID_KEY_LAST_LOG,0));
                        editor2.commit();
                        Intent main=new Intent(this,MainActivity.class);
                        startActivity(main);
                        this.finish();
                    }else{
                        Toast.makeText(this,"Incorrect Password",Toast.LENGTH_SHORT).show();
                        txt_pword.setText("");
                    }
                }
                break;
        }
    }
}
