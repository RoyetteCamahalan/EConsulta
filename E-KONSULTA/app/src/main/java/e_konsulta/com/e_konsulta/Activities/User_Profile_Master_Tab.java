package e_konsulta.com.e_konsulta.Activities;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Switch;
import android.widget.TabHost;
import android.widget.Toast;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;

import e_konsulta.com.e_konsulta.Fragments.fragment_Patient_Profile;
import e_konsulta.com.e_konsulta.Fragments.fragment_patient_diagnosis;
import e_konsulta.com.e_konsulta.Fragments.fragment_patient_history;
import e_konsulta.com.e_konsulta.R;
import e_konsulta.com.e_konsulta.Tools.ImageHelper;

/**
 * Created by Royette on 11/28/2015.
 */
public class User_Profile_Master_Tab extends FragmentActivity implements TabHost.OnTabChangeListener, ViewPager.OnPageChangeListener, View.OnClickListener {
    private ViewPager viewPager;
    private User_Tab_Adapter mAdapter;
    private TabHost mTabHost;



    Dialog select_source;
    LinearLayout choose_camera,choose_gallery;
    String imageFileUri;
    ImageView img_profile_pic;
    Bitmap profile_img_circle;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.user_profile_layout);
        getActionBar().setDisplayHomeAsUpEnabled(true);
        img_profile_pic= (ImageView) findViewById(R.id.img_profile_pic);
        mTabHost = (TabHost) findViewById(android.R.id.tabhost);
        mTabHost.setup();
        viewPager = (ViewPager) mTabHost.findViewById(R.id.viewpager);
        mAdapter = new User_Tab_Adapter(getSupportFragmentManager());
        viewPager.setAdapter(mAdapter);

        mTabHost.addTab(mTabHost.newTabSpec("Profile").setIndicator("Profile").setContent(R.id.viewpager));
        mTabHost.addTab(mTabHost.newTabSpec("Account").setIndicator("Account").setContent(R.id.viewpager));

        viewPager.setOnPageChangeListener(this);
        mTabHost.setOnTabChangedListener(this);
        mTabHost.setCurrentTab(1);
        mTabHost.setCurrentTab(0);
        viewPager.setCurrentItem(0);
        if(profile_img_circle!=null){
            img_profile_pic.setImageBitmap(profile_img_circle);
        }
        getActionBar().setDisplayHomeAsUpEnabled(true);
    }
    @Override
    public void onTabChanged(String tabId) {

        switch (tabId){
            case "Profile":
                viewPager.setCurrentItem(0);
                break;
            case "Account":
                viewPager.setCurrentItem(1);
                break;
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.user_profile_menu,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if(item.getItemId()==android.R.id.home){
            this.finish();
        }else if (item.getItemId()==R.id.action_change_pic){
            select_source=new Dialog(this);
            select_source.requestWindowFeature(Window.FEATURE_NO_TITLE);
            select_source.setContentView(R.layout.dialog_select_img_src);
            select_source.show();
            choose_camera= (LinearLayout) select_source.findViewById(R.id.linear_choose_camera);
            choose_gallery= (LinearLayout) select_source.findViewById(R.id.linear_choose_gallery);
            choose_camera.setOnClickListener(this);
            choose_gallery.setOnClickListener(this);
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

    }

    @Override
    public void onPageSelected(int position) {
        mTabHost.setCurrentTab(position);
    }

    @Override
    public void onPageScrollStateChanged(int state) {

    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.linear_choose_camera:
                Intent intent_camera = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                intent_camera.putExtra(MediaStore.EXTRA_OUTPUT, Uri.fromFile(getTempFile(this)));
                startActivityForResult(intent_camera, 1337);

                select_source.dismiss();
                break;
            case R.id.linear_choose_gallery:
                Intent intent_gallery = new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                intent_gallery.putExtra(android.provider.MediaStore.EXTRA_OUTPUT, imageFileUri);
                startActivityForResult(intent_gallery, 111);

                select_source.dismiss();
                break;
        }
    }

    private File getTempFile(Context context) {
        final File path = new File(Environment.getExternalStorageDirectory(), context.getPackageName());
        if (!path.exists()) {
            path.mkdir();
        }
        return new File(path, "image.tmp");
    }
    public boolean hasImageCaptureBug() {

        // list of known devices that have the bug
        ArrayList<String> devices = new ArrayList<String>();
        devices.add("android-devphone1/dream_devphone/dream");
        devices.add("generic/sdk/generic");
        devices.add("vodafone/vfpioneer/sapphire");
        devices.add("tmobile/kila/dream");
        devices.add("verizon/voles/sholes");
        devices.add("google_ion/google_ion/sapphire");

        return devices.contains(android.os.Build.BRAND + "/" + android.os.Build.PRODUCT + "/"
                + android.os.Build.DEVICE);

    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == 111 && resultCode == this.RESULT_OK) { //GALLERY
            Toast.makeText(this,"gallery",Toast.LENGTH_SHORT).show();
            if (data.getData() != null && !data.getData().equals(Uri.EMPTY)) {

                Uri uri = data.getData();
                try {
                    profile_img_circle= ImageHelper.getCroppedBitmap(BitmapFactory.decodeStream(getContentResolver().openInputStream(uri)));
                    img_profile_pic.setImageBitmap(profile_img_circle);
                } catch (FileNotFoundException e) {
                    e.printStackTrace();
                }

            }/*
            String[] projection = {MediaStore.Images.Media.DATA};

                Cursor cursor = getActivity().getContentResolver().query(uri, projection, null, null, null);
                cursor.moveToFirst();

                int columnIndex = cursor.getColumnIndex(projection[0]);
                String path = cursor.getString(columnIndex);

                filePath = path;
                showProgressbar();
                new UploadFileToServer().execute();

                cursor.close();*/
        } else if (requestCode == 1337 && resultCode == this.RESULT_OK) { //CAMERA
            Toast.makeText(this,"camera",Toast.LENGTH_SHORT).show();
            final File file = getTempFile(this);
            try {

                profile_img_circle= ImageHelper.getCroppedBitmap(MediaStore.Images.Media.getBitmap(this.getContentResolver(), Uri.fromFile(file)));
                if(profile_img_circle!=null){
                    img_profile_pic.setImageBitmap(profile_img_circle);
                }

            } catch (IOException e) {
                e.printStackTrace();
            }
/*
            Uri tempUri = getImageUri(getActivity(), captureBmp);
                File finalFile = new File(getRealPathFromURI(tempUri));
                String path = String.valueOf(finalFile);

                filePath = path;
                showProgressbar();

                new UploadFileToServer().execute();
            */
        }

    }

    private class User_Tab_Adapter extends FragmentStatePagerAdapter {


        public User_Tab_Adapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            switch (position) {
                case 0:
                    return new fragment_patient_diagnosis();
                case 1:
                    return new fragment_patient_history();
            }
            return new fragment_patient_diagnosis();
        }

        @Override
        public int getCount() {
            return 2;
        }
    }
}
