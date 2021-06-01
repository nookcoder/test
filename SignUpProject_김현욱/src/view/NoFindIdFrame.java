package view;

import java.awt.BorderLayout;

import javax.swing.*;


public class NoFindIdFrame extends JFrame{

	public NoFindIdFrame() {
		JLabel message = new JLabel("아이디 또는 비밀번호가 일치하지 않습니다.");
		setLayout(new BorderLayout());
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		add(message,BorderLayout.CENTER);
		setSize(300,400);
		setVisible(true);
	}
}
