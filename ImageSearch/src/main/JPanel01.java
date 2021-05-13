package main;

import java.awt.event.*;
import javax.swing.*;
import javax.swing.border.Border;

public class JPanel01 extends JPanel{ // 1번째 패널 

	private JButton jButton1;
	private JScrollPane jscrolPane1;
	private JTextField jTextField;
	private ChangingJPanel change;
	
	public JPanel01(ChangingJPanel change) {
		this.change = change;
		setLayout(null);
	
		jButton1 = new JButton("검색");
		jButton1.setSize(100,60);
		jButton1.setLocation(600,250);
		
		jButton1.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel02");
			}
		});
		
		add(jButton1);
		
		jTextField = new JTextField("") {
			@Override
			public void setBorder(Border border)
			{
				
			}
		};
		
		jTextField.setSize(500,60);
		jTextField.setLocation(100,250);
		
		add(jTextField); 
		
		jTextField.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				jTextField.setText("");
			}
		});
		
		
	}
	
	
}
