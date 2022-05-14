package set;

import java.awt.BorderLayout;

import javax.swing.*;

import text.TextPanel;

public class SettingCalculator extends JFrame{
	
	private Constants constats = new Constants(); 
	private JPanel contentPanel = new JPanel();
	public TextPanel textPanel; 
	
	public SettingCalculator() {
		this.textPanel = new TextPanel();
	
		setTitle("계산기");
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
