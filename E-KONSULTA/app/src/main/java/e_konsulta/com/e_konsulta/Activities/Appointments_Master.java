package e_konsulta.com.e_konsulta.Activities;

import android.app.ActionBar;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageView;

import e_konsulta.com.e_konsulta.Activities.MainActivity;
import e_konsulta.com.e_konsulta.Fragments.fragment_patient_diagnosis;
import e_konsulta.com.e_konsulta.Fragments.fragment_request;
import e_konsulta.com.e_konsulta.Fragments.fragment_today;
import e_konsulta.com.e_konsulta.R;

/**
 * Created by Royette on 11/23/2015.
 */
public class Appointments_Master extends FragmentActivity {

    private String[] tabs = {"Today", "Incoming","Request"};
    private Appointments_Tab_Adapter mAdapter;
    private ViewPager viewPager;
    private ActionBar actionBar;
    ImageView swipeLeftRight;

    Intent intent;
    int unselected = 0;
    int pos = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.appointments_tab_layout);
        viewPager = (ViewPager) findViewById(R.id.pager);
        mAdapter = new Appointments_Tab_Adapter(getSupportFragmentManager());

        actionBar =this.getActionBar();
        actionBar.setDisplayHomeAsUpEnabled(true);
        viewPager.setAdapter(mAdapter);
        actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);
        for (String tab_name : tabs) {
            actionBar.addTab(actionBar.newTab().setText(tab_name)
                    .setTabListener(new ActionBar.TabListener() {


                        @Override
                        public void onTabSelected(ActionBar.Tab tab, FragmentTransaction ft) {
                            mAdapter.notifyDataSetChanged();
                            viewPager.setCurrentItem(tab.getPosition());
                        }

                        @Override
                        public void onTabUnselected(ActionBar.Tab tab, FragmentTransaction ft) {
                            unselected = tab.getPosition();
                        }

                        @Override
                        public void onTabReselected(ActionBar.Tab tab, FragmentTransaction ft) {

                        }
                    }));
        }

        actionBar.setSelectedNavigationItem(MainActivity.appointment_selection);
        viewPager.setCurrentItem(MainActivity.appointment_selection);

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
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.appointment_calendar:
                startActivity(new Intent(this,Schedule_Calendar.class));
                break;
            case android.R.id.home:
                this.finish();
                break;
        }
        return super.onOptionsItemSelected(item);
    }

    private class Appointments_Tab_Adapter extends FragmentStatePagerAdapter {


        public Appointments_Tab_Adapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            switch (position) {
                case 0:
                    return new fragment_today();
                case 1:
                    return new fragment_patient_diagnosis();
                case 2:
                    return new fragment_request();
            }
            return null;
        }
        @Override
        public int getCount() {
            return 3;
        }
    }
}
