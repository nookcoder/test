package panel;

import java.awt.Graphics;
import java.awt.event.*;
import java.io.IOException;

import javax.swing.*;

public class JPanel01 extends JPanel{ // 시작 패널 

	private JButton runningSearch;
	private JButton lookingRecord;
	
	
	public JPanel01(ChangingJPanel change) throws IOException {
		setLayout(null);
		
		MakeRuningSearchButton(change);
		MakeLookingRecord(change);
	}
	
	public void MakeRuningSearchButton(ChangingJPanel change) {
		runningSearch = new JButton("검색");
		runningSearch.setSize(300,60);
		runningSearch.setLocation(50,270);
		
		runningSearch.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel02");
			}
		});
		
		add(runningSearch);
	}
	
	public void MakeLookingRecord(ChangingJPanel change) {
		lookingRecord = new JButton(new ImageIcon("ImageSearch/src/images/KakaoTalk_20190518_190420225.jpg"));
		lookingRecord.setSize(300,60);
		lookingRecord.setLocation(50,350);
		
		lookingRecord.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel03");
			}
		});
		
		add(lookingRecord);
	}
	
}


