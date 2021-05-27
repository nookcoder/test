package set;

import java.awt.BorderLayout;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.*;

import keypad.KeyPadPanel;
import text.BigTextPanel;
import text.TextPanel;

public class SettingCalculator extends JFrame{
	
	private Constants constats = new Constants(); 
	private JPanel contentPanel = new JPanel();
	public TextPanel textPanel; 
	public BigTextPanel bigTextPanel;
	
	public SettingCalculator() {
		this.textPanel = new TextPanel();
		this.bigTextPanel = new BigTextPanel();
	
		setTitle("°è»ê±â");
		setSize(350,500);
		setMinimumSize(constats.dimension);
		
		if(getWidth() < 350 && getHeight() < 500)
		{
			setSize(350,500);
		}		
		
		contentPanel.setLayout(new BorderLayout());
		contentPanel.add(textPanel,BorderLayout.CENTER);
		contentPanel.addComponentListener(new SizeListener());
		//add(bigTextPanel);
		add(contentPanel);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		textPanel.calculatorDisplay.requestFocusInWindow();
	}
	
	private class SizeListener implements ComponentListener{
		@Override
		public void componentResized(ComponentEvent e) {
			// TODO Auto-generated method stub
			if(e.getComponent().getWidth() > 900)
			{
				contentPanel.removeAll();
				contentPanel.add(bigTextPanel,BorderLayout.CENTER);
				contentPanel.updateUI();
				contentPanel.repaint();
			}
			else if(e.getComponent().getWidth() <= 900) {
				contentPanel.removeAll();
				contentPanel.add(textPanel,BorderLayout.CENTER);
				contentPanel.updateUI();
				contentPanel.repaint();
			}
		}

		@Override
		public void componentMoved(ComponentEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void componentShown(ComponentEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void componentHidden(ComponentEvent e) {
			// TODO Auto-generated method stub
			
		}
	}
}
