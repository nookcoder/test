package main;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

public class ImageSearchMain {

	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		new Frame();
		KakaoCrawler kakao = new KakaoCrawler();
		kakao.Get();
	}

}
