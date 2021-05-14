package main;


import javax.swing.*;

import org.json.simple.parser.ParseException;

import data.Constants;
import panel.ChangingJPanel;
import panel.FirstPage;
import panel.SearchPage;
import panel.LogPage;

import java.awt.*;
import java.io.IOException;

public class Frame extends JFrame{
	
	private Constants constant = new Constants();
	
	public Frame() throws ParseException, IOException 
	{
		ChangingJPanel win = new ChangingJPanel();
		
		win.setTitle("이미지 검색");
		
		win.firstPage= new FirstPage(win);
		win.firstPage.setBackground(constant.yellowColor);
			
		
		win.searchPage = new SearchPage(win);
		win.searchPage.setBackground(constant.yellowColor);
		
		win.logPage = new LogPage(win);
		win.logPage.setBackground(constant.yellowColor); 
		
		win.add(win.firstPage);
		
		win.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		win.setSize(400,600);
		win.setVisible(true);
	}
	

}
