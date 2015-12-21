package e_konsulta.com.e_konsulta.Activities;




import android.app.ActionBar;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.content.res.TypedArray;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.v4.app.ActionBarDrawerToggle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.widget.DrawerLayout;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

import e_konsulta.com.e_konsulta.Fragments.fragment_Home;
import e_konsulta.com.e_konsulta.Fragments.fragment_Patients;
import e_konsulta.com.e_konsulta.Fragments.fragment_appointments;
import e_konsulta.com.e_konsulta.Fragments.fragment_clinics;
import e_konsulta.com.e_konsulta.Fragments.fragment_secretaries;
import e_konsulta.com.e_konsulta.NavDrawerItem;
import e_konsulta.com.e_konsulta.NavDrawerListAdapter;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.DB_retrieve;

public class MainActivity extends FragmentActivity {
    public static final String str_shared_lastupdate="s_last_update";
    public static final String str_key_lastupdate="s_last_update_key";
    private String[] navMenuTitles;
    private TypedArray navMenuIcons;
    public static ArrayList<NavDrawerItem> navDrawerItems;

    public static NavDrawerListAdapter adapter;
    private ActionBarDrawerToggle mDrawerToggle;

    private DrawerLayout mDrawerLayout;
    public static ListView mDrawerList;
    ImageView img_first;
    TextView txt_specialty,fname_lname;

    DB_retrieve db_retrieve;

    SharedPreferences shared_last_update,shareduserpref;
    public static int appointment_selection=1;
    private int from_notif_checker=0;

    MenuItem calendar;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        db_retrieve=new DB_retrieve(this);

        Intent intent=getIntent();
        from_notif_checker=intent.getIntExtra("checker",0);

        shared_last_update=getSharedPreferences(str_shared_lastupdate,MODE_PRIVATE);
        shareduserpref=getSharedPreferences(Login.USERPREFERENCES,MODE_PRIVATE);
        String last_update=shared_last_update.getString(str_key_lastupdate,"");
        if(last_update.equals("")){
            SharedPreferences.Editor editor=shared_last_update.edit();
            editor.putString(str_key_lastupdate,"2012-12-12 12:02:00");
        }
        ActionBar actionbar = getActionBar();
        actionbar.setDisplayHomeAsUpEnabled(true);
        actionbar.setHomeButtonEnabled(true);
        //////////////FOR THE SIDEBAR///////////////////////////////
        //Header of the listview, go to header.xml to customize
        View header = getLayoutInflater().inflate(R.layout.header_sidebar, null);
        img_first = (ImageView) header.findViewById(R.id.img_first);
        fname_lname= (TextView) header.findViewById(R.id.fname_lname);
        txt_specialty = (TextView) header.findViewById(R.id.txt_uname);


        String mname=shareduserpref.getString(Login.CURRENT_MNAME,"");
        if(!mname.equals("")&&!mname.equals("null")){
            mname=mname.substring(0,1)+".";
        }
        fname_lname.setText("Dr. "+shareduserpref.getString(Login.CURRENT_FNAME, "")+" "+mname+" "+shareduserpref.getString(Login.CURRENT_LNAME, ""));
        txt_specialty.setText(shareduserpref.getString(Login.CURRENT_SPECIALTY, ""));
        //Bitmap bm = BitmapFactory.decodeResource(getResources(), R.drawable.temp_user);
        //img_first.setImageBitmap(ImageHelper.getRoundedCornerBitmap(bm, 300));

        navDrawerItems = new ArrayList();

        navMenuTitles = getResources().getStringArray(R.array.nav_drawer_items); // load slide menu items
        navMenuIcons = getResources().obtainTypedArray(R.array.nav_drawer_icons); // nav drawer icons from resources

        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        mDrawerList = (ListView) findViewById(R.id.list_slidermenu);

        navDrawerItems.add(new NavDrawerItem(navMenuTitles[0], navMenuIcons.getResourceId(0, -1)));
        navDrawerItems.add(new NavDrawerItem(navMenuTitles[1], navMenuIcons.getResourceId(1, -1)));
        navDrawerItems.add(new NavDrawerItem(navMenuTitles[2], navMenuIcons.getResourceId(2, -1)));
        navDrawerItems.add(new NavDrawerItem(navMenuTitles[3], navMenuIcons.getResourceId(3, -1),true,String.valueOf(db_retrieve.getcounter())));
        navDrawerItems.add(new NavDrawerItem(navMenuTitles[4], navMenuIcons.getResourceId(4, -1)));
        navDrawerItems.add(new NavDrawerItem(navMenuTitles[5], navMenuIcons.getResourceId(5, -1)));
        navDrawerItems.add(new NavDrawerItem(navMenuTitles[6], navMenuIcons.getResourceId(6, -1)));


        navMenuIcons.recycle(); // Recycle the typed array

        mDrawerList.setOnItemClickListener(new SlideMenuClickListener());

        // setting the nav drawer list adapter
        adapter = new NavDrawerListAdapter(getApplicationContext(), navDrawerItems);
        mDrawerList.addHeaderView(header);
        mDrawerList.setAdapter(adapter);

        mDrawerToggle = new ActionBarDrawerToggle(this, mDrawerLayout,
                R.drawable.ic_navigator, //nav menu toggle icon
                R.string.app_name, // nav drawer open - description for accessibility
                R.string.app_name // nav drawer close - description for accessibility
        ) {
            public void onDrawerClosed(View view) {
                // calling onPrepareOptionsMenu() to show action bar icons
                invalidateOptionsMenu();
            }

            public void onDrawerOpened(View drawerView) {
                // calling onPrepareOptionsMenu() to hide action bar icons

                invalidateOptionsMenu();
            }
        };
        mDrawerLayout.setDrawerListener(mDrawerToggle);

        if (savedInstanceState == null) {
            if(from_notif_checker==1){
                displayView(4);
                appointment_selection=2;
            }else {
                displayView(1); // on first time display view for first nav item
                appointment_selection=0;
            }

        }


    }

    private class SlideMenuClickListener implements ListView.OnItemClickListener {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            displayView(position); // display view for selected nav drawer item
        }
    }

    @Override
    public void onBackPressed() {
        this.finish();
        super.onBackPressed();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return super.onCreateOptionsMenu(menu);
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (mDrawerToggle.onOptionsItemSelected(item))
            return true;
        return super.onOptionsItemSelected(item);
    }

    /***
     * Called when invalidateOptionsMenu() is triggered
     */
    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        // if nav drawer is opened, hide the action items
        boolean drawerOpen = mDrawerLayout.isDrawerOpen(mDrawerList);

        return super.onPrepareOptionsMenu(menu);
    }

    public void displayView(int position) {
        // update the main content by replacing fragments
        Fragment fragment = null;
        switch (position) {
            case 0:
                Intent intent_profile=new Intent(this,User_Profile_Master_Tab.class);
                startActivity(intent_profile);
                break;
            case 1:
                fragment = new fragment_Home();
                break;
            case 2:
                fragment = new fragment_Patients();
                break;
            case 4:
                fragment = new fragment_appointments();
                break;
            case 5:
                fragment = new fragment_secretaries();
                break;
            case 6:
                fragment = new fragment_clinics();
                break;
            case 7:
                Intent intent=new Intent(this,Login_v2.class);
                startActivity(intent);
                SharedPreferences.Editor editor=shareduserpref.edit();
                editor.putInt(Login.USERID_KEY_CURRENT_LOG,0);
                editor.commit();
                this.finish();
                break;
        }
        if (fragment != null) {
            FragmentManager fragmentManager = getSupportFragmentManager();
            fragmentManager.beginTransaction().replace(R.id.frame_container, fragment).commit();

            mDrawerList.setItemChecked(position, true);
            mDrawerList.setSelection(position);
            setTitle(navMenuTitles[position-1]);
            mDrawerLayout.closeDrawer(mDrawerList);
        } else
            Log.e("SidebarAct", "Error in creating fragment");
    }

    @Override
    protected void onPostCreate(Bundle savedInstanceState) {
        super.onPostCreate(savedInstanceState);
        // Sync the toggle state after onRestoreInstanceState has occurred.
        mDrawerToggle.syncState();
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        // Pass any configuration change to the drawer toggls
        mDrawerToggle.onConfigurationChanged(newConfig);
    }
}