package e_konsulta.com.e_konsulta.Activities;


import android.app.Dialog;
import android.content.ContentValues;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.CameraPosition;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

import e_konsulta.com.e_konsulta.Tools.DBHelper;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.DB_insert_update;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;

/**
 * Created by Royette on 11/24/2015.
 */
public class Clinic_Profile extends FragmentActivity implements View.OnClickListener {
    DB_insert_update db_insert_update;
    DB_retrieve db_retrieve;

    private GoogleMap googleMap;
    int clinic_id;
    String name,address,telno,schedule;
    TextView Tname,Taddress,Ttelno,Tsched;
    EditText ETname,ETaddress,ETtelno,ETsched;
    Button btn_save;
    Dialog edit_dialog;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.clinic_profile);
        Tname= (TextView) findViewById(R.id.txt_clinic_name);
        Taddress= (TextView) findViewById(R.id.address);
        Ttelno= (TextView) findViewById(R.id.telephone);
        Tsched= (TextView) findViewById(R.id.txt_schedule);

        db_retrieve=new DB_retrieve(this);
        db_insert_update=new DB_insert_update(this);

        Intent intent=getIntent();
        clinic_id=Integer.valueOf(intent.getStringExtra("clinic_id"));
        name=intent.getStringExtra("name");
        address=intent.getStringExtra("address");
        telno=intent.getStringExtra("telno");
        schedule=intent.getStringExtra("schedule");
        Tname.setText(name);
        Taddress.setText(address);
        Ttelno.setText(telno);
        Tsched.setText(schedule);
        if (googleMap == null) {
            googleMap = ((MapFragment) getFragmentManager().findFragmentById(
                    R.id.map)).getMap();

            // check if map is created successfully or not
            if (googleMap == null) {
                Toast.makeText(getApplicationContext(),
                        "Sorry! unable to create maps", Toast.LENGTH_SHORT)
                        .show();
            }
            else {
                double latitude = 7.1019254;
                double longitude = 125.5945598;

                MarkerOptions marker = new MarkerOptions().position(new LatLng(latitude, longitude)).title("Your Clinic");
                marker.icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_GREEN));
                googleMap.addMarker(marker);
                CameraPosition cameraPosition = new CameraPosition.Builder().target(
                        new LatLng(latitude, longitude)).zoom(16).build();

                googleMap.animateCamera(CameraUpdateFactory.newCameraPosition(cameraPosition));
                googleMap.setMyLocationEnabled(true);
            }
        }
        getActionBar().setDisplayHomeAsUpEnabled(true);
        getActionBar().setHomeButtonEnabled(true);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.edit,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if(item.getItemId()==android.R.id.home){
            this.finish();
        }
        else if(item.getItemId()==R.id.menu_edit){
            edit_dialog=new Dialog(this);
            edit_dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
            edit_dialog.setContentView(R.layout.edit_clinic_layout);
            edit_dialog.show();
            ETname= (EditText) edit_dialog.findViewById(R.id.ET_clinic_name);
            ETaddress= (EditText) edit_dialog.findViewById(R.id.ET_address);
            ETtelno= (EditText) edit_dialog.findViewById(R.id.ET_telephone);
            ETsched= (EditText) edit_dialog.findViewById(R.id.ET_schedule);
            btn_save= (Button) edit_dialog.findViewById(R.id.btn_save);
            ETname.setText(name);
            ETaddress.setText(address);
            ETtelno.setText(telno);
            ETsched.setText(schedule);
            btn_save= (Button) edit_dialog.findViewById(R.id.btn_save);
            btn_save.setOnClickListener(this);
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onClick(View v) {
        if(v.getId()==R.id.btn_save){
            boolean checker=true;
            String N_name=ETname.getText().toString(),
                    N_address=ETaddress.getText().toString(),
                    N_telno=ETtelno.getText().toString(),
                    N_sched=ETsched.getText().toString();
            if(N_name.equals("")){
                checker=false;
                ETname.setError("Required");
            }
            if(N_address.equals("")){
                checker=false;
                ETaddress.setError("Required");
            }
            if(N_sched.equals("")){
                checker=false;
                ETsched.setError("Required");
            }
            if(checker){
                ContentValues val=new ContentValues();
                val.put(DBHelper.NAME,N_name);
                val.put(DBHelper.ADDRESS,N_address);
                val.put(DBHelper.TEL_NO,N_telno);
                val.put(DBHelper.CLINIC_SCHEDULE, N_sched);
                if(db_insert_update.insertClinic(val, 1, clinic_id)){
                    Toast.makeText(this,"Saved",Toast.LENGTH_SHORT).show();
                }else {
                    Toast.makeText(this,"Saving Failed",Toast.LENGTH_SHORT).show();
                }
                Tname.setText(N_name);
                Taddress.setText(N_address);
                Ttelno.setText(N_telno);
                Tsched.setText(N_sched);
                edit_dialog.dismiss();
            }
        }
    }
    /*
    LatLngBounds bounds = builder.build();
                    int padding = 100; // offset from edges of the map in pixels

                    CameraUpdate cu1 = CameraUpdateFactory.newLatLngBounds(bounds, padding);
                    map.moveCamera(cu1);
                    map.animateCamera(cu1);
    */

}
