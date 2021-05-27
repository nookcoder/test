package set;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.*;

import keypad.KeyPadPanel;
import text.BigTextPanel;
import text.TextPanel;

public class SettingCalculator extends JFrame{
	
	private Constants constats = new Constants(); 
	
	public SettingCalculator() {
		
		setTitle("°è»ê±â");
		setSize(350,500);
		setMinimumSize(constats.dimension);
		if(getWidth() < 350 && getHeight() < 500)
		{
			setSize(350,500);
		}		
		TextPanel textPanel = new TextPanel();
		BigTextPanel bigTextPanel = new BigTextPanel();
		add(textPanel);
		this.addMouseMotionListener(new MouseMotionListener() {

			@Override
			public void mouseDragged(MouseEvent e) {
				// TODO Auto-generated method stub
				int width = getWidth();
				if(textPanel.get >= 600)
				{
					removeAll();
					add(bigTextPanel);
					revalidate();
					repaint();
					
				}
			}

			@Override
			public void mouseMoved(MouseEvent e) {
				// TODO Auto-generated method stub
				
			}
			
		});
		//add(bigTextPanel);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
	}
}
