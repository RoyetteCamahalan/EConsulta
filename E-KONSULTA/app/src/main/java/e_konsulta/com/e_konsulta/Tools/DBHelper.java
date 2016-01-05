package e_konsulta.com.e_konsulta.Tools;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by Royette on 11/20/2015.
 */

public class DBHelper extends SQLiteOpenHelper {
    public static final String DB_NAME = "PatientCare";
    public static final int DB_VERSION = 1;

    public static final String TBL_PATIENTS = "patients",
            FNAME = "fname",
            MNAME = "mname",
            LNAME = "lname",
            PTNT_OCCUPATION = "occupation",
            PTNT_BIRTHDATE = "birthdate",
            PTNT_SEX = "sex",
            PTNT_CIVIL_STATUS = "civil_status",
            PTNT_HEIGHT = "height",
            PTNT_WEIGHT = "weight",
            OPTIONAL_ADDRESS = "optional_address",
            BRGY_ID = "address_barangay_id",
            BARANGAY = "address_barangay",
            MUNICIPALITY = "address_city_municipality",
            PROVINCE = "address_province",
            REGION = "address_region",
            TEL_NO = "tel_no",
            MOBILE_NO = "mobile_no",
            EMAIL = "email_address",
            PHOTO = "photo",
            PTNT_REFERRED_BY = "referral_by";

    public static final String TBL_CONSULTATION_RQ = "consultation_request",
            CLINIC_ID = "clinic_id",
            DATE = "date",
            TIME = "time",
            IS_APPROVED = "is_approved",
            COMMENT_DOCTOR = "comment_doctor",
            PATIENT_IS_APPROVED = "patient_is_approved",
            PATIENT_COMMENT = "patient_comment";
    public static final String TBL_CLINICS = "clinic",
            NAME = "name",ADDRESS="address",CLINIC_SCHEDULE="clinic_schedule";

    public static final String CREATED_AT = "created_at", DELETED_AT = "deleted_at", UPDATED_AT = "updated_at", AI_ID = "id",
            PATIENT_ID = "patient_id", IS_READ = "isRead";

    public static final String TBL_SECRETARIES="secretaries",SECRETARY_ID="secretary_id",IS_ACTIVE="is_active",
            USERNAME="username",PASSWORD="password";
    public static final String TBL_BLOCK_DATES="block_dates",EXPLANATION="explanation",SERVER_ID="server_id";

    public DBHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        String sql_create_tbl_patients = String.format("CREATE TABLE %s ( %s INTEGER PRIMARY KEY AUTOINCREMENT, %s INTEGER, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT, %s TEXT)",
                TBL_PATIENTS, AI_ID, PATIENT_ID, FNAME, MNAME, LNAME, PTNT_OCCUPATION, PTNT_BIRTHDATE, PTNT_SEX, PTNT_CIVIL_STATUS, PTNT_HEIGHT, PTNT_WEIGHT, OPTIONAL_ADDRESS, BRGY_ID, BARANGAY, MUNICIPALITY, PROVINCE, REGION, TEL_NO, MOBILE_NO, EMAIL, PHOTO, PTNT_REFERRED_BY, CREATED_AT, UPDATED_AT, DELETED_AT);
        String sql_create_tbl_consultation_request = String.format("CREATE TABLE %s ( %s INTEGER PRIMARY KEY,%s INTEGER, %s INTEGER, %s TEXT, %s TEXT, %s INTEGER, %s TEXT, %s INTEGER, %s TEXT, %s TEXT)",
                TBL_CONSULTATION_RQ, AI_ID, PATIENT_ID, CLINIC_ID, DATE, TIME, IS_APPROVED, COMMENT_DOCTOR, PATIENT_IS_APPROVED, PATIENT_COMMENT,CREATED_AT, UPDATED_AT);
        String sql_create_tbl_clinics = String.format("CREATE TABLE %s (%s INTEGER PRIMARY KEY, %s TEXT, %s TEXT, %s TEXT,%s TEXT)",
                TBL_CLINICS, CLINIC_ID, NAME,TEL_NO,ADDRESS,CLINIC_SCHEDULE);
        String sql_create_tbl_secretaries = String.format("CREATE TABLE %s (%s INTEGER PRIMARY KEY, %s TEXT, %s TEXT, %s TEXT,%s TEXT,%s TEXT,%s TEXT,%s TEXT,%s TEXT,%s INTEGER,%s TEXT,%s TEXT,%s TEXT,%s TEXT,%s TEXT,%s TEXT,%s INTEGER,%s TEXT,%s TEXT)",
                TBL_SECRETARIES, SECRETARY_ID, FNAME,MNAME,LNAME,MOBILE_NO,TEL_NO,EMAIL,PHOTO,OPTIONAL_ADDRESS,BRGY_ID, BARANGAY, MUNICIPALITY, PROVINCE, REGION,USERNAME,PASSWORD,IS_ACTIVE, CREATED_AT, UPDATED_AT);
        String sql_create_tbl_block_dates = String.format("CREATE TABLE %s (%s INTEGER PRIMARY KEY AUTOINCREMENT, %s TEXT, %s TEXT, %s TEXT,%s TEXT,%s INTEGER)",
                TBL_BLOCK_DATES, AI_ID, DATE,EXPLANATION,CREATED_AT,UPDATED_AT,SERVER_ID);
        db.execSQL(sql_create_tbl_patients);
        db.execSQL(sql_create_tbl_consultation_request);
        db.execSQL(sql_create_tbl_clinics);
        db.execSQL(sql_create_tbl_secretaries);
        db.execSQL(sql_create_tbl_block_dates);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }
    public void Clear_DB(){
        SQLiteDatabase db = getWritableDatabase();
        db.execSQL("delete from " + TBL_CLINICS);
        db.execSQL("delete from " + TBL_PATIENTS);
        db.execSQL("delete from " + TBL_CONSULTATION_RQ);
        db.execSQL("delete from " + TBL_SECRETARIES);
        db.execSQL("delete from " + TBL_BLOCK_DATES);
        db.close();
    }
}
