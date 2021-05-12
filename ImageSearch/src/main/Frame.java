package main;

import javax.imageio.ImageIO;
import javax.swing.*;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.ParseException;
import java.awt.*;
import java.io.IOException;
import java.net.URL;
import java.awt.event.*;
import java.awt.image.BufferedImage;

public class Frame extends JFrame{
	Container c; 
	URL url;
	JLabel label;
	public Frame() throws ParseException, IOException 
	{
		setTitle("이미지 검색");
		setSize(600,400);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setTextField();
		setVisible(true);
	}
	
	public void setTextField() throws ParseException, IOException
	{
		KakaoCrawler api = new KakaoCrawler();
		JSONArray imgUrlArray = api.ImageParse();
		c = getContentPane(); 
		for(int i =0;i<imgUrlArray.size() ;i++)
		{
			JSONObject jsonobj = (JSONObject)imgUrlArray.get(i);
			String imgUrl = (String)jsonobj.get("image_url");
			url = new URL(imgUrl);
			BufferedImage image = ImageIO.read(url);
			label = new JLabel(new ImageIcon(image));
			c.add(label);
		}

		c.setLayout(new FlowLayout());
		c.add(new JLabel("검색 "));
		c.add(new JTextField(20));
		c.add(new JButton("Test"));
	}
}
