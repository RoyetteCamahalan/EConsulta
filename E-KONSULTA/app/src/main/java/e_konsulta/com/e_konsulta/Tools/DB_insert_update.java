package e_konsulta.com.e_konsulta.Tools;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

/**
 * Created by Royette on 12/9/2015.
 */
public class DB_insert_update extends DBHelper {
    public DB_insert_update(Context context) {
        super(context);
    }


    public int check_clinic(int id){
        String sql = "SELECT * from "+TBL_CLINICS +" where "+CLINIC_ID+"="+id;
        SQLiteDatabase db = getWritableDatabase();
        int count = 0;
        Cursor cur = db.rawQuery(sql, null);
        count = cur.getCount();
        db.close();
        cur.close();
        return count;
    }

    public boolean insertClinic(ContentValues values,int action,int id){
        SQLiteDatabase db = getWritableDatabase();
        long rowid=0;
        if(action==0){
            values.put(CLINIC_ID,id);
            rowid=db.insert(TBL_CLINICS,null,values);
        }else{
            rowid=db.update(TBL_CLINICS,values,CLINIC_ID+"="+id,null);
        }
        db.close();
        return rowid>0;
    }







    public int check_patient(int id){
        String sql = "SELECT * from "+TBL_PATIENTS +" where "+PATIENT_ID+"="+id;
        SQLiteDatabase db = getWritableDatabase();
        int count = 0;
        Cursor cur = db.rawQuery(sql, null);
        count = cur.getCount();
        db.close();
        cur.close();
        return count;
    }
    public boolean insertPatient(ContentValues values,int action,int id){
        SQLiteDatabase db = getWritableDatabase();
        long rowid=0;
        if(action==0){
            values.put(PATIENT_ID,id);
            rowid=db.insert(TBL_PATIENTS,null,values);
        }else{
            rowid=db.update(TBL_PATIENTS,values,PATIENT_ID+"="+id,null);
        }
        db.close();
        return rowid>0;
    }






    public int check_appointment(int id){
        String sql = "SELECT * from "+TBL_CONSULTATION_RQ +" where "+AI_ID+"="+id;
        SQLiteDatabase db = getWritableDatabase();
        int count = 0;
        Cursor cur = db.rawQuery(sql, null);
        count = cur.getCount();
        db.close();
        cur.close();
        return count;
    }
    public boolean insertAppointment(ContentValues values,int action,int id){
        SQLiteDatabase db = getWritableDatabase();
        long rowid=0;
        if(action==0){
            values.put(AI_ID,id);
            rowid=db.insert(TBL_CONSULTATION_RQ,null,values);
        }else{
            rowid=db.update(TBL_CONSULTATION_RQ,values,AI_ID+"="+id,null);
        }
        db.close();
        return rowid>0;
    }





    public int check_secretary(int id){
        String sql = "SELECT * from "+TBL_SECRETARIES +" where "+SECRETARY_ID+"="+id;
        SQLiteDatabase db = getWritableDatabase();
        int count = 0;
        Cursor cur = db.rawQuery(sql, null);
        count = cur.getCount();
        db.close();
        cur.close();
        return count;
    }

    public boolean insertSecretary(ContentValues values,int action,int id){
        SQLiteDatabase db = getWritableDatabase();
        long rowid=0;
        if(action==0){
            values.put(SECRETARY_ID,id);
            rowid=db.insert(TBL_SECRETARIES,null,values);
        }else{
            rowid=db.update(TBL_SECRETARIES,values,SECRETARY_ID+"="+id,null);
        }
        db.close();
        return rowid>0;
    }
}
