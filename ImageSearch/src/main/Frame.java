package main;

import javax.swing.*;
import main.KakaoCrawler;
import java.awt.*;
import java.io.IOException;

public class Frame extends JFrame{
	Container c; 
	
	public Frame() 
	{
		setTitle("이미지 검색");
		setSize(600,400);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setTextField();

	}
	
	public void setTextField()
	{
		KakaoCrawler api = new KakaoCrawler();
		c = getContentPane(); 
		c.setLayout(new FlowLayout());
		c.add(new JLabel("검색 "));
		c.add(new JTextField(20));
		c.add(new JButton("Test"));
	}
}
