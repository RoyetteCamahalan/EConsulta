package e_konsulta.com.e_konsulta.Activities;


import android.app.ActionBar;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.view.ViewPager;
import android.view.MenuItem;
import android.widget.ImageView;
import android.widget.Toast;

import e_konsulta.com.e_konsulta.Fragments.fragment_Patient_Profile;
import e_konsulta.com.e_konsulta.Fragments.fragment_patient_diagnosis;
import e_konsulta.com.e_konsulta.Fragments.fragment_patient_history;
import e_konsulta.com.e_konsulta.Fragments.fragment_patient_test_result;
import e_konsulta.com.e_konsulta.R;

/**
 * Created by Royette on 11/21/2015.
 */
public class Patient_Master extends FragmentActivity implements ActionBar.TabListener {

    public static int patient_id=0;
    private Patient_Tab_Adapter mAdapter;
    private String[] tabs = {"Patient Profile", "History", "Diagnosis", "Test Result"};
    private ViewPager viewPager;
    private ActionBar actionBar;

    ImageView swipeLeftRight;

    Intent intent;
    int unselected = 0;
    int pos = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.patient_tab_layout);

        viewPager = (ViewPager) findViewById(R.id.pager);
        mAdapter = new Patient_Tab_Adapter(getSupportFragmentManager());

        actionBar = getActionBar();
        actionBar.setDisplayHomeAsUpEnabled(true);

        viewPager.setAdapter(mAdapter);
        actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

        for (String tab_name : tabs) {
            actionBar.addTab(actionBar.newTab().setText(tab_name)
                    .setTabListener(this));
        }

        intent = getIntent();
        patient_id=intent.getIntExtra("patient_id", 0);
        actionBar.setSelectedNavigationItem(0);

        viewPager.setOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageSelected(int position) {
                actionBar.setSelectedNavigationItem(position);
            }

            @Override
            public void onPageScrolled(int arg0, float arg1, int arg2) {
            }

            @Override
            public void onPageScrollStateChanged(int arg0) {
            }
        });

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        this.finish();
        return super.onOptionsItemSelected(item);
    }



    @Override
    public void onTabSelected(ActionBar.Tab tab, android.app.FragmentTransaction ft) {
        mAdapter.notifyDataSetChanged();
        viewPager.setCurrentItem(tab.getPosition());
    }

    @Override
    public void onTabUnselected(ActionBar.Tab tab, android.app.FragmentTransaction ft) {
        unselected = tab.getPosition();
    }

    @Override
    public void onTabReselected(ActionBar.Tab tab, android.app.FragmentTransaction ft) {

    }

    private class Patient_Tab_Adapter extends FragmentStatePagerAdapter{


        public Patient_Tab_Adapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            switch (position) {
                case 0:
                    return new fragment_Patient_Profile();
                case 1:
                    return new fragment_patient_history();
                case 2:
                    return new fragment_patient_diagnosis();
                case 3:
                    return new fragment_patient_test_result();
            }
            return null;
        }
        @Override
        public int getCount() {
            return 4;
        }
    }

}

