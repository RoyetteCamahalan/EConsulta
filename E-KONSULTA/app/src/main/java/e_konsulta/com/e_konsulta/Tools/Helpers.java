package e_konsulta.com.e_konsulta.Tools;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.widget.Toast;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import e_konsulta.com.e_konsulta.Activities.MainActivity;
import e_konsulta.com.e_konsulta.NavDrawerItem;
import e_konsulta.com.e_konsulta.R;

/**
 * Created by Royette on 11/25/2015.
 */
public class Helpers {
    public boolean checkInternet(Context context)
    {
        ConnectivityManager connectivityManager= (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();
    }
    public String md5(final String s) {
        final String MD5 = "MD5";
        try {
            // Create MD5 Hash
            MessageDigest digest = java.security.MessageDigest.getInstance(MD5);
            digest.update(s.getBytes());
            byte messageDigest[] = digest.digest();

            // Create Hex String
            StringBuilder hexString = new StringBuilder();
            for (byte aMessageDigest : messageDigest) {
                String h = Integer.toHexString(0xFF & aMessageDigest);
                while (h.length() < 2)
                    h = "0" + h;
                hexString.append(h);
            }
            return hexString.toString();

        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
        return "";
    }
    public void refresh_drawer_counter(int counter,Context context){
        MainActivity.navDrawerItems.set(3, new NavDrawerItem("Appointments", R.drawable.ic_appointments, true, String.valueOf(counter)));
        MainActivity.adapter.notifyDataSetChanged();
    }
}
