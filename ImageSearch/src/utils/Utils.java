package utils;

import model.Documents;
import model.SearchResult;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

public class Utils {

    public int setWidthFromComboBoxValue(int comboBoxValue){
        if(comboBoxValue == 30){
            return 100;
        }
        return 120;
    }

    public int setHeightFromComboBoxValue(int comboBoxValue){
        switch (comboBoxValue){
            case 10 :
                return 150;
            case 20:
                return 75;
            default:
                return 70;
        }
    }
}
