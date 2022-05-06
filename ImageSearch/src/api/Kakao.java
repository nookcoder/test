package api;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import utils.Constants;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

public class Kakao {
    private Constants constants;
    private URL url;
    private HttpURLConnection connection;

    public Kakao(){
        constants = new Constants();
    }

    public String getSearchingResponse(String query) throws IOException {
        String responseData = "";
        BufferedReader br = null;
        StringBuffer sb = null;

        String totalUrl = String.format(constants.BASE_URL,query);
        url = new URL(totalUrl);
        connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("GET");
        connection.setRequestProperty("Authorization" , constants.KAKAO_KEY);
        connection.connect();

        br = new BufferedReader(new InputStreamReader(connection.getInputStream(), StandardCharsets.UTF_8));
        sb = new StringBuffer();
        while ((responseData = br.readLine()) != null) {
            sb.append(responseData); //StringBuffer에 응답받은 데이터 순차적으로 저장 실시
        }

        return sb.toString();
    }

    public List<String> getImageUrlList(String returnData) throws ParseException {
        List<String> imageList = new ArrayList<>();
        JSONParser parser = new JSONParser();
        JSONObject object = (JSONObject) parser.parse(returnData);
        JSONArray documents = (JSONArray) object.get("documents");
        for(int index=0;index<documents.size(); index++){
            JSONObject document = (JSONObject) documents.get(index);
            imageList.add((String) document.get("image_url"));
        }

        return imageList;
    }
}
