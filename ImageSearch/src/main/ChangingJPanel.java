package main;

import java.awt.event.*;
import javax.swing.*;


public class ChangingJPanel extends JFrame{
	
	public JPanel01 jpanel01 = null; 
	public JPanel02 jpanel02 = null; 
	
	public void ChangePanel(String panelName) {
		
		if(panelName.equals("panel01")) {
			getContentPane().removeAll();
			getContentPane().add(jpanel01);
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
	
}
