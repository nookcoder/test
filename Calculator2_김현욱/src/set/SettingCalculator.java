package set;

import javax.swing.*;

import keypad.KeyPadPanel;
import text.TextPanel;

public class SettingCalculator extends JFrame{
	
	private Constants constats = new Constants(); 
	
	public SettingCalculator() {
		
		setTitle("°è»ê±â");
		setSize(350,500);
		JFrame j = new JFrame();
		setMinimumSize(constats.dimension);
		if(getWidth() < 350 && getHeight() < 500)
		{
			setSize(350,500);
		}
		
		TextPanel textPanel = new TextPanel();
		add(textPanel);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
	}
}
