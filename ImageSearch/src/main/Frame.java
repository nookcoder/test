package main;


import javax.swing.*;

import org.json.simple.parser.ParseException;

import panel.ChangingJPanel;
import panel.JPanel01;
import panel.JPanel02;
import panel.JPanel03;

import java.awt.*;
import java.io.IOException;

public class Frame extends JFrame{
	private Container c;
	private ImageIcon icon;
	private KakaoCrawler kakao;
	
	public Frame() throws ParseException, IOException 
	{
		ChangingJPanel win = new ChangingJPanel();
		
		win.setTitle("이미지 검색");
		
		win.jpanel01 = new JPanel01(win) {
			public void paintComponent(Graphics g) {
				ImageIcon image = new ImageIcon("images/KakaoTalk_20190518_190420225.jpg");
				g.drawImage(image.getImage(), 0, 0, 800, 600, null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		win.jpanel02 = new JPanel02(win) {
			public void paintComponent(Graphics g) {
				ImageIcon image = new ImageIcon("images/KakaoTalk_20190518_190420225.jpg");
				g.drawImage(image.getImage(), 0, 0, 800, 600, null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		win.jpanel03 = new JPanel03(win) {
			public void paintComponent(Graphics g) {
				ImageIcon image = new ImageIcon("images/KakaoTalk_20190518_190420225.jpg");
				g.drawImage(image.getImage(), 0, 0, 800, 600, null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		
		win.add(win.jpanel01);
		win.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		win.setSize(600,400);
		win.setVisible(true);
	}
	

}
