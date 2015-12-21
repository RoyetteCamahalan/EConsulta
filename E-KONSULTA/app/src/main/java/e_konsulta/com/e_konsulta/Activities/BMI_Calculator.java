package e_konsulta.com.e_konsulta.Activities;

import android.app.Activity;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import e_konsulta.com.e_konsulta.R;

/**
 * Created by Royette on 11/27/2015.
 */
public class BMI_Calculator extends Activity implements View.OnClickListener {

    TextView result;
    Button btn_calculate;
    EditText ETweight,ETheight;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.bmi_layout);
        ETweight= (EditText) findViewById(R.id.txt_weight);
        ETheight= (EditText) findViewById(R.id.txt_height);
        btn_calculate= (Button) findViewById(R.id.btn_calculate);
        result= (TextView) findViewById(R.id.txt_result);
        btn_calculate.setOnClickListener(this);
        getActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        this.finish();
        return super.onOptionsItemSelected(item);

    }

    @Override
    public void onClick(View v) {
        if(v.getId()==R.id.btn_calculate){
            String str1 = ETweight.getText().toString();
            String str2 = ETheight.getText().toString();

            if(TextUtils.isEmpty(str1)){
                ETweight.setError("Please enter your weight");
                ETweight.requestFocus();
                return;
            }

            if(TextUtils.isEmpty(str2)){
                ETheight.setError("Please enter your height");
                ETheight.requestFocus();
                return;
            }

//Get the user values from the widget reference
            float weight = Float.parseFloat(str1);
            float height = Float.parseFloat(str2)/100;

//Calculate BMI value
            float bmiValue = calculateBMI(weight, height);

//Define the meaning of the bmi value
            String bmiInterpretation = interpretBMI(bmiValue);

            result.setText(String.valueOf(bmiValue + "-" + bmiInterpretation));

        }
    }
    private float calculateBMI (float weight, float height) {
        return (float) (weight / (height * height));
    }

    // Interpret what BMI means
    private String interpretBMI(float bmiValue) {

        if (bmiValue < 16) {
            return "Severely underweight";
        } else if (bmiValue < 18.5) {

            return "Underweight";
        } else if (bmiValue < 25) {

            return "Normal";
        } else if (bmiValue < 30) {

            return "Overweight";
        } else {
            return "Obese";
        }
    }
}
