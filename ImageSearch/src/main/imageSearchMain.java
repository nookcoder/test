package main;

import java.io.IOException;

import javax.swing.JFrame;

import org.json.simple.parser.ParseException;

public class ImageSearchMain {

	public static void main(String[] args) throws IOException, ParseException{
		// TODO Auto-generated method stub
//		new Frame();

		ChangingJPanel win = new ChangingJPanel();
		
		win.setTitle("이미지 검색");
		win.jpanel01 = new JPanel01(win);
		win.jpanel02 = new JPanel02(win);
		
		win.add(win.jpanel01);
		win.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		win.setSize(800,600);
		win.setVisible(true);
	}

}
