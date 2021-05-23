package set;
import java.awt.*;

import javax.swing.JButton;

public class Constants {

	public GridLayout textGridLayout = new GridLayout(0,1); 
	public GridLayout panelGridLayout = new GridLayout(0,2); 
	public BorderLayout KeyPadBorderLayout = new BorderLayout();
	public Font ButtonFont = new Font("µ¸À½", Font.BOLD, 20);
	
	public void setButtonFont(JButton btn) {
		btn.setFont(ButtonFont);
		btn.setBorderPainted(false);
		btn.setBackground(Color.WHITE);
	}
	
	public Dimension dimension = new Dimension(450,550);
}
