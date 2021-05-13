package panel;

import java.awt.Graphics;
import java.awt.event.*;
import javax.swing.*;

public class JPanel03 extends JPanel { // 활동내역조회 패널
	
	private JButton runningSearch;
	private JButton lookingRecord;
	private ChangingJPanel change;
	private JButton backButton;
	
	public JPanel03(ChangingJPanel change) {
		this.change = change;
		setLayout(null);
		
		backButton = new JButton("홈으로");
		backButton.setSize(100,60);
		backButton.setLocation(600,90);
	
		backButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel01");;
			}
		});
		
		add(backButton);
	}
}
