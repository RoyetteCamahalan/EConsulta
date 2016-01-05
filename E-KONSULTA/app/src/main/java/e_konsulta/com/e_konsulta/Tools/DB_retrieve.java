package e_konsulta.com.e_konsulta.Tools;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by Royette on 12/9/2015.
 */
public class DB_retrieve extends DBHelper {
    public DB_retrieve(Context context) {
        super(context);
    }
    public ArrayList<HashMap<String, String>> getAllPatients() {
        ArrayList<HashMap<String, String>> patients = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql = "select * from " + TBL_PATIENTS;
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(AI_ID, cur.getString(cur.getColumnIndex(AI_ID)));
            map.put(FNAME, cur.getString(cur.getColumnIndex(FNAME)));
            map.put(LNAME, cur.getString(cur.getColumnIndex(LNAME)));
            String mname=cur.getString(cur.getColumnIndex(MNAME));
            if (mname.length()!=0){
                mname=mname.substring(0, 1)+".";
            }
            map.put("fullname",cur.getString(cur.getColumnIndex(FNAME)) + " " + mname + " " + cur.getString(cur.getColumnIndex(LNAME)));
            map.put("details", cur.getString(cur.getColumnIndex(PTNT_BIRTHDATE)) + " " + cur.getString(cur.getColumnIndex(PTNT_SEX)));
            map.put(PATIENT_ID, cur.getString(cur.getColumnIndex(PATIENT_ID)));
            patients.add(map);
        }

        db.close();
        cur.close();

        return patients;
    }

    public ArrayList<HashMap<String, String>> getPatient(int id) {
        ArrayList<HashMap<String, String>> patients = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql = "select * from " + TBL_PATIENTS+" WHERE "+AI_ID+"="+id;
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(AI_ID, cur.getString(cur.getColumnIndex(AI_ID)));
            map.put(PATIENT_ID, cur.getString(cur.getColumnIndex(PATIENT_ID)));
            map.put(FNAME, cur.getString(cur.getColumnIndex(FNAME)));
            map.put(MNAME,cur.getString(cur.getColumnIndex(MNAME)));
            map.put(LNAME, cur.getString(cur.getColumnIndex(LNAME)));
            map.put(BARANGAY, cur.getString(cur.getColumnIndex(BARANGAY)));
            map.put(MUNICIPALITY, cur.getString(cur.getColumnIndex(MUNICIPALITY)));
            map.put(PROVINCE, cur.getString(cur.getColumnIndex(PROVINCE)));
            map.put(REGION, cur.getString(cur.getColumnIndex(REGION)));
            map.put(MOBILE_NO, cur.getString(cur.getColumnIndex(MOBILE_NO)));
            map.put(TEL_NO, cur.getString(cur.getColumnIndex(TEL_NO)));
            map.put(EMAIL, cur.getString(cur.getColumnIndex(EMAIL)));
            patients.add(map);

        }

        db.close();
        cur.close();

        return patients;
    }


    public ArrayList<HashMap<String, String>> getAllAppointments(int which) {
        ArrayList<HashMap<String, String>> appointments = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        if(which==1){
            String sql = String.format("select rq.%s,p.%s,p.%s,p.%s,c.%s,rq.%s from %s c INNER JOIN %s rq ON c.%s=rq.%s INNER JOIN %s p ON p.%s=rq.%s WHERE %s=CURRENT_TIME",
                    AI_ID, FNAME, MNAME, LNAME,NAME,TIME,TBL_CLINICS,TBL_CONSULTATION_RQ,CLINIC_ID,CLINIC_ID,TBL_PATIENTS,PATIENT_ID,PATIENT_ID,DATE);
            Cursor cur = db.rawQuery(sql, null);

            while (cur.moveToNext()) {
                HashMap<String, String> map = new HashMap();
                map.put(AI_ID, cur.getString(cur.getColumnIndex(AI_ID)));
                String mname=cur.getString(cur.getColumnIndex(MNAME));
                if (mname.length()!=0){
                    mname=mname.substring(0, 1)+".";
                }
                map.put("FULLNAME",cur.getString(cur.getColumnIndex(FNAME)) + " " + mname + " " + cur.getString(cur.getColumnIndex(LNAME)));
                map.put(NAME, cur.getString(cur.getColumnIndex(NAME)));
                map.put(TIME, cur.getString(cur.getColumnIndex(TIME)));
                appointments.add(map);
            }
            cur.close();
            return appointments;
        }
        else if(which==2) {
            String sql = String.format("select rq.%s,p.%s,p.%s,p.%s,c.%s,rq.%s,rq.%s,rq.%s,rq.%s,p.%s 'patient_id' from %s c INNER JOIN %s rq ON c.%s=rq.%s INNER JOIN %s p ON p.%s=rq.%s WHERE rq.%s=1",
                    AI_ID, FNAME, MNAME, LNAME,NAME,DATE,TIME,COMMENT_DOCTOR,PATIENT_COMMENT,AI_ID,TBL_CLINICS,TBL_CONSULTATION_RQ,CLINIC_ID,CLINIC_ID,TBL_PATIENTS,PATIENT_ID,PATIENT_ID,IS_APPROVED);
            Cursor cur = db.rawQuery(sql, null);

            while (cur.moveToNext()) {
                HashMap<String, String> map = new HashMap();
                map.put(AI_ID, cur.getString(cur.getColumnIndex(AI_ID)));
                String mname=cur.getString(cur.getColumnIndex(MNAME));
                if (mname.length()!=0){
                    mname=mname.substring(0, 1)+".";
                }
                map.put("FULLNAME",cur.getString(cur.getColumnIndex(FNAME)) + " " + mname + " " + cur.getString(cur.getColumnIndex(LNAME)));
                map.put(NAME, cur.getString(cur.getColumnIndex(NAME)));
                map.put(DATE, cur.getString(cur.getColumnIndex(DATE)));
                map.put(TIME, cur.getString(cur.getColumnIndex(TIME)));
                map.put(COMMENT_DOCTOR, cur.getString(cur.getColumnIndex(COMMENT_DOCTOR)));
                map.put(PATIENT_COMMENT, cur.getString(cur.getColumnIndex(PATIENT_COMMENT)));
                map.put("patient_id", cur.getString(cur.getColumnIndex("patient_id")));
                appointments.add(map);
            }
            cur.close();
            return appointments;
        }
        else if(which==3) {
            String sql = String.format("select rq.%s,p.%s,p.%s,p.%s,c.%s,rq.%s,rq.%s,rq.%s,p.%s 'patient_id' from %s c INNER JOIN %s rq ON c.%s=rq.%s INNER JOIN %s p ON p.%s=rq.%s WHERE rq.%s=0",
                    AI_ID, FNAME, MNAME, LNAME,NAME,DATE,TIME,PATIENT_COMMENT,AI_ID,TBL_CLINICS,TBL_CONSULTATION_RQ,CLINIC_ID,CLINIC_ID,TBL_PATIENTS,PATIENT_ID,PATIENT_ID,IS_APPROVED);
            Cursor cur = db.rawQuery(sql, null);

            while (cur.moveToNext()) {
                HashMap<String, String> map = new HashMap();
                map.put(AI_ID, cur.getString(cur.getColumnIndex(AI_ID)));
                String mname=cur.getString(cur.getColumnIndex(MNAME));
                if (mname.length()!=0){
                    mname=mname.substring(0, 1)+".";
                }
                map.put("FULLNAME",cur.getString(cur.getColumnIndex(FNAME)) + " " + mname + " " + cur.getString(cur.getColumnIndex(LNAME)));
                map.put(NAME, cur.getString(cur.getColumnIndex(NAME)));
                map.put(DATE, cur.getString(cur.getColumnIndex(DATE)));
                map.put(TIME, cur.getString(cur.getColumnIndex(TIME)));
                map.put(PATIENT_COMMENT, cur.getString(cur.getColumnIndex(PATIENT_COMMENT)));
                map.put("patient_id", cur.getString(cur.getColumnIndex("patient_id")));
                appointments.add(map);
            }
            cur.close();
            return appointments;
        }

        db.close();


        return appointments;
    }
    public int getcounter(){
        ArrayList<HashMap<String, String>> Appointments;
        Appointments=getAllAppointments(3);
        return Appointments.size();
    }



    public ArrayList<HashMap<String, String>> getAllClinics() {
        ArrayList<HashMap<String, String>> clinics = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql = "select * from " + TBL_CLINICS;
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(CLINIC_ID, cur.getString(cur.getColumnIndex(CLINIC_ID)));
            map.put(NAME, cur.getString(cur.getColumnIndex(NAME)));
            map.put(ADDRESS, cur.getString(cur.getColumnIndex(ADDRESS)));
            map.put(TEL_NO, cur.getString(cur.getColumnIndex(TEL_NO)));
            map.put(CLINIC_SCHEDULE,cur.getString(cur.getColumnIndex(CLINIC_SCHEDULE)));
            clinics.add(map);
        }
        db.close();
        cur.close();

        return clinics;
    }



    public ArrayList<HashMap<String, String>> getAllSecretaries() {
        ArrayList<HashMap<String, String>> secretary = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql=String.format("SELECT %s,%s,%s,%s,%s FROM %s ORDER BY %s DESC,%s,%s",SECRETARY_ID,FNAME,MNAME,LNAME,IS_ACTIVE,TBL_SECRETARIES,IS_ACTIVE,FNAME,LNAME);
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(SECRETARY_ID, cur.getString(cur.getColumnIndex(SECRETARY_ID)));
            String mname=cur.getString(cur.getColumnIndex(MNAME));
            if (mname.length()!=0){
                mname=mname.substring(0, 1)+".";
            }
            map.put("FULLNAME", cur.getString(cur.getColumnIndex(FNAME))+" "+ mname+" "+cur.getString(cur.getColumnIndex(LNAME)));
            map.put(IS_ACTIVE,cur.getString(cur.getColumnIndex(IS_ACTIVE)));
            secretary.add(map);
        }
        db.close();
        cur.close();

        return secretary;
    }
    public ArrayList<HashMap<String, String>> getSecretary(int id) {
        ArrayList<HashMap<String, String>> secretary = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql = "select * from " + TBL_SECRETARIES +" WHERE "+SECRETARY_ID+"="+id;
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(SECRETARY_ID, cur.getString(cur.getColumnIndex(SECRETARY_ID)));
            String mname=cur.getString(cur.getColumnIndex(MNAME));
            if (mname.length()!=0){
                mname=mname.substring(0, 1)+".";
            }
            map.put("FULLNAME", cur.getString(cur.getColumnIndex(FNAME))+" "+ mname+" "+cur.getString(cur.getColumnIndex(LNAME)));
            map.put(BARANGAY, cur.getString(cur.getColumnIndex(BARANGAY)));
            map.put(MUNICIPALITY, cur.getString(cur.getColumnIndex(MUNICIPALITY)));
            map.put(PROVINCE, cur.getString(cur.getColumnIndex(PROVINCE)));
            map.put(REGION, cur.getString(cur.getColumnIndex(REGION)));
            map.put(TEL_NO, cur.getString(cur.getColumnIndex(TEL_NO)));
            map.put(EMAIL, cur.getString(cur.getColumnIndex(EMAIL)));
            map.put(MOBILE_NO, cur.getString(cur.getColumnIndex(MOBILE_NO)));
            map.put(IS_ACTIVE,cur.getString(cur.getColumnIndex(IS_ACTIVE)));
            map.put(USERNAME, cur.getString(cur.getColumnIndex(USERNAME)));
            map.put(PASSWORD,cur.getString(cur.getColumnIndex(PASSWORD)));
            secretary.add(map);
        }
        db.close();
        cur.close();

        return secretary;
    }
    public ArrayList<HashMap<String, String>> getBlockDates() {
        ArrayList<HashMap<String, String>> block_dates = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql = "select "+DATE+",COUNT(*) AS 'COUNTER' from " + TBL_BLOCK_DATES + " GROUP BY "+DATE;
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(DATE, cur.getString(cur.getColumnIndex(DATE)));
            map.put("COUNTER", cur.getString(cur.getColumnIndex("COUNTER")));
            block_dates.add(map);
        }
        db.close();
        cur.close();

        return block_dates;
    }
    public ArrayList<HashMap<String, String>> getBlockPerDate(String date) {
        ArrayList<HashMap<String, String>> block_dates = new ArrayList();
        SQLiteDatabase db = getWritableDatabase();
        String sql = "select *  from " + TBL_BLOCK_DATES + " WHERE "+DATE+"="+date;
        Cursor cur = db.rawQuery(sql, null);

        while (cur.moveToNext()) {
            HashMap<String, String> map = new HashMap();
            map.put(AI_ID, cur.getString(cur.getColumnIndex(AI_ID)));
            map.put(DATE, cur.getString(cur.getColumnIndex(DATE)));
            map.put(EXPLANATION, cur.getString(cur.getColumnIndex(EXPLANATION)));
            map.put(CREATED_AT, cur.getString(cur.getColumnIndex(DATE)));
            block_dates.add(map);
        }
        db.close();
        cur.close();

        return block_dates;
    }
}
