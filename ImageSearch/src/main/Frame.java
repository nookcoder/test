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
	private Container c;
	private KakaoCrawler kakao;
	
	public Frame() throws ParseException, IOException 
	{
		this.kakao = new KakaoCrawler();
		InitializeFram();
		setVisible(true);
	}
	
	public void InitializeFram()
	{
		setTitle("이미지 검색");
		setLayout(null);
		setSize(800,600);
		SetComponents();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

	}
	
	public void SetComponents()
	{
		JButton btn = new JButton("Click");
		JTextField textfield = new JTextField("");
		
		btn.setBounds(100, 150, 100, 30);
		textfield.setBounds(250, 150, 150, 30);
		
		btn.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				textfield.setText("Button Clicked");
			}
		});
		
		add(btn); add(textfield);
	}
	
	public void setTextField()
	{
		c = getContentPane(); 

		c.setLayout(new FlowLayout());
		c.add(new JLabel("검색 "));
		c.add(new JTextField(20));
		c.add(new JButton("Test"));
		
	}
}
