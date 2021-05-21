package set;

import javax.swing.*;

import keypad.KeyPadPanel;
import text.TextPanel;

public class SettingCalculator extends JFrame{
	
	private JTextField calculatorDisplay = new JTextField("0");
	private JTextArea recordArea; 
	private JLabel showingProcess = new JLabel("À¸¾Ó"); 
	
	public SettingCalculator() {
		
		setTitle("°è»ê±â");
		setSize(350,500);
		
		TextPanel textPanel = new TextPanel();
		add(textPanel);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
	}
}
