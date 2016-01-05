package e_konsulta.com.e_konsulta.Activities;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

import e_konsulta.com.e_konsulta.R;

/**
 * Created by User PC on 1/4/2016.
 */
public class View_Schedule extends Activity {
    public ArrayList<HashMap<String,String >> Schedules=new ArrayList<>();

    TextView no_sched_found,txt_title;
    String date;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.view_sched_layout);
        Intent intent=getIntent();
        date=intent.getStringExtra("Date");

        no_sched_found= (TextView) findViewById(R.id.noSchedFound);
        txt_title= (TextView) findViewById(R.id.txt_title);

        txt_title.setText("Schedules For "+date);
    }

    @Override
    protected void onResume() {
        super.onResume();
        if(Schedules.size()==0){
            no_sched_found.setVisibility(View.VISIBLE);
        }
    }
}
