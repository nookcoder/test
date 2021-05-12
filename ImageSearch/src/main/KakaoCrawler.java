package main;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.net.http.HttpClient;
import java.util.jar.JarException;

import org.json.simple.JSONObject;

public class KakaoCrawler {

	 public enum HttpMethodType{POST,GET,DELETE}
	 
	 private static final String API_SERVER_HOST = "https://dapi.kakao.com";
	 private static final String IMAGE_PATH = "/v2/search/image.json?query=";
	 
	 public void Get() throws IOException
	 {
		 byte[] image; 

		 try {
	        	String query = URLEncoder.encode("고양이","UTF-8");
	            String apiURL = API_SERVER_HOST + IMAGE_PATH + query;
	            URL url = new URL(apiURL);
	            HttpURLConnection con = (HttpURLConnection)url.openConnection();
	            con.setRequestMethod("GET");
	            con.setRequestProperty("Authorization", "KakaoAK c12b5f6d787822dff8b7bc693fd50e9c");
	            int responseCode = con.getResponseCode();
	            BufferedReader br;
	            if(responseCode==200) { // 정상 호출
	                br = new BufferedReader(new InputStreamReader(con.getInputStream()));
	            } else {  // 에러 발생
	                br = new BufferedReader(new InputStreamReader(con.getErrorStream()));
	            }
	            String inputLine;
	            StringBuffer response = new StringBuffer();
	            while ((inputLine = br.readLine()) != null) {
	                response.append(inputLine);
	            }
	            
	            br.close();
	            System.out.println(response.toString());
	        } catch (Exception e) {
	            System.out.println(e);
	        }
	 }
}
