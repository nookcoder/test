package view;

import java.awt.*;

import javax.swing.*;

import model.Constants;

public class ResignView extends JFrame{
	
	private Constants constants; 
	
	public JPasswordField password;
	public JPasswordField passwordCheck;
	public JButton okayButton;
	public JButton cansleButton;
	
	public ResignView() {
		this.constants = new Constants();
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400,300);
		setLayout(null);

		
		setVisible(true);
	}
	
	public void decorateButton(JButton btn)
	{
		btn.setBackground(constants.LIGHE_BLUE);
		btn.setForeground(Color.WHITE);
		btn.setFont(constants.LOGIN_FONT);
		btn.setBorder(BorderFactory.createCompoundBorder(
				BorderFactory.createRaisedBevelBorder(),
				BorderFactory.createEmptyBorder(2, 20, 2, 20)
				));
		btn.setMargin(new Insets(5,15,5,15));
		btn.setFocusPainted(false);
	}
}
