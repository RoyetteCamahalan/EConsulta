package e_konsulta.com.e_konsulta.Tools;

import java.util.ArrayList;

/**
 * Created by User PC on 21/12/2015.
 */

public class CalendarCollection {
    public String date="";
    public String event_message="";

    public static ArrayList<CalendarCollection> date_collection_arr=new ArrayList<>();
    public CalendarCollection(String date,String event_message){

        this.date=date;
        this.event_message=event_message;

    }

}