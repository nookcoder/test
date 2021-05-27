package set;

import java.awt.BorderLayout;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.*;

import keypad.KeyPadPanel;
import text.TextPanel;

public class SettingCalculator extends JFrame{
	
	private Constants constats = new Constants(); 
	private JPanel contentPanel = new JPanel();
	public TextPanel textPanel; 
	
	public SettingCalculator() {
		this.textPanel = new TextPanel();
	
		setTitle("°è»ê±â");
		setSize(350,500);
		setMinimumSize(constats.dimension);
		
		if(getWidth() < 350 && getHeight() < 500)
		{
			setSize(350,500);
		}		
		
		contentPanel.setLayout(new BorderLayout());
		contentPanel.add(textPanel,BorderLayout.CENTER);
		add(contentPanel);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		textPanel.calculatorDisplay.requestFocusInWindow();
	}

}
