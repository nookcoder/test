package main;

import java.awt.Container;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;


public class KakaoCrawler {

	 public enum HttpMethodType{POST,GET,DELETE}
	 
	 private static final String API_SERVER_HOST = "https://dapi.kakao.com";
	 private static final String IMAGE_PATH = "/v2/search/image.json?query=";
	 
	 // 카카오에서 한줄 정보(?) 받아오기 
	 public String GetJsonFromKakao(String searchText) throws IOException
	 {
		 String str = null;
		 try {
	        	String query = URLEncoder.encode(searchText,"UTF-8 ");
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
	            str = response.toString();
		 } catch (Exception e) {
	            System.out.println(e);
	        }
		 
		 return str;
	 }
	
	 // 한줄 정보(?) 에서 JSONpaerse 하기 
	 public JSONArray GetImageUrlArray(String searchText) throws ParseException, IOException{
		 JSONParser jsonParser = new JSONParser();
		 JSONObject jsonObject = (JSONObject)jsonParser.parse(GetJsonFromKakao(searchText));
		 JSONArray jsonArray = (JSONArray)jsonObject.get("documents");
		 
		 return jsonArray;
	 }
	
	 // 이미지 Url 로 이미지 넣기 
	 public void AddImage(Container c,String SearchText) throws ParseException, IOException
	 {
		 JSONArray imgUrlArray = GetImageUrlArray(SearchText);
		 URL url;
		 JLabel label;
		
		 for(int i =0;i<imgUrlArray.size() ;i++)
		 {
			 JSONObject jsonobj = (JSONObject)imgUrlArray.get(i);
			 String imgUrl = (String)jsonobj.get("image_url");
			 url = new URL(imgUrl);
			 BufferedImage image = ImageIO.read(url);
			 label = new JLabel(new ImageIcon(image));
			 c.add(label);
		 }

	}
	
}
