package test;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Frame extends JFrame{

	public Frame() {
		// 처음 실행시켰을 때 창 모양 설정
		setSize(600,400);
		setResizable(false);
		setLocationRelativeTo(null);
		setLayout(null);
		setVisible(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
}
