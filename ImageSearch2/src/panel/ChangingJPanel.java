package panel;

import java.awt.event.*;
import javax.swing.*;


public class ChangingJPanel extends JFrame{
	
	public FirstPage firstPage = null; 
	public SearchPage searchPage = null; 
	public LogPage logPage = null; 
	
	public void ChangePanel(String panelName) {
		
		if(panelName.equals("panel01")) {
			getContentPane().removeAll();
			getContentPane().add(firstPage);
			revalidate();
			repaint();
		}
		
		else if (panelName.equals("panel03")) {
			getContentPane().removeAll();
			getContentPane().add(logPage);
			revalidate();
			repaint();
		}
		
		else {
			getContentPane().removeAll();
			getContentPane().add(searchPage);
			revalidate();
			repaint();
		}
	}

}
