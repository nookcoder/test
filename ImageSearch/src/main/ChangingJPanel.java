package main;

import java.awt.event.*;
import javax.swing.*;


public class ChangingJPanel extends JFrame{
	
	public JPanel01 jpanel01 = null; 
	public JPanel02 jpanel02 = null; 
	public JPanel03 jpanel03 = null; 
	
	public void ChangePanel(String panelName) {
		
		if(panelName.equals("panel01")) {
			getContentPane().removeAll();
			getContentPane().add(jpanel01);
			revalidate();
			repaint();
		}
		
		else if (panelName.equals("panel03")) {
			getContentPane().removeAll();
			getContentPane().add(jpanel03);
			revalidate();
			repaint();
		}
		
		else {
			getContentPane().removeAll();
			getContentPane().add(jpanel02);
			revalidate();
			repaint();
		}
	}
	
//	public RunChange(class panel) {
//		getContentPane().removeAll();
//		getContentPane().add(panel);
//		revalidate();
//		repaint();
//	}
//	
}
