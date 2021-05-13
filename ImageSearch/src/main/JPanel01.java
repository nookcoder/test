package main;

import java.awt.Graphics;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.border.Border;

public class JPanel01 extends JPanel{ // 시작 패널 

	private JButton runningSearch;
	private JButton lookingRecord;
	private ChangingJPanel change;
	private JPanel02 jpanel02;
	private JPanel03 jpanel03;
	
	public JPanel01(ChangingJPanel change) {
		this.change = change;
		setLayout(null);
	
		runningSearch = new JButton("검색");
		runningSearch.setSize(100,60);
		runningSearch.setLocation(100,250);
		
		runningSearch.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel02");
			}
		});
		
		lookingRecord = new JButton("활동내역");
		lookingRecord.setSize(100,60);
		lookingRecord.setLocation(500,100);
		
		lookingRecord.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel03");
			}
		});
		
		add(runningSearch); add(lookingRecord);
		
		
	}
	
	
}
